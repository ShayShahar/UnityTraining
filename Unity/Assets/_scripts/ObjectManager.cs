using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DIS1998net;
using UnitiyAPI;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._scripts
{
    public class ObjectManager : MonoBehaviour
    {
        class GameObjectData
        {
            public GameObject m_object;
            public GameObject m_marker;
            public bool IsSelected;
            public GameObject m_selection;
            public GameObject ListItem;
            public Button SelectionButton;
        }

        class UnityEntityType
        {
            public int TypeId { get; set; }
            public GameObject ObjectType { get; set; }
            public EntityType EsType { get; set; }
        }

        public ClientObject Client;

        public GameObject TankObject;
        public GameObject HaloPref;
        public GameObject WaypointObj;
        public GameObject HaloSelected;

        private bool m_putTank = false;
        private bool m_createRoute = false;
        public RouteDisplay routeDisplayPrefab;

        private int m_currentInsdex = 0;
        private EspduSender m_disSender;

        private Camera m_mainCamera;
        private List<GameObjectData> m_tanksList;
        private List<RouteData> m_routeList;
        private List<Vector3> m_currentRoute;

        private bool m_markEntities;


        void Start()
        {
            m_mainCamera = Camera.main;

            //register incoming messages here
            Client.ObjectCommandReceivedEvent += onObjectCommandReceivedEvent;
            Client.TacticalCommandReceivedEvent += onTacticalCommandReceivedEvent;


            m_tanksList = new List<GameObjectData>();
            m_disSender = new EspduSender(1, 1, 1, 5);
            m_routeList = new List<RouteData>();
            m_currentRoute = new List<Vector3>();
        }

        private void onTacticalCommandReceivedEvent(TacticalObjectManagement p_obj)
        {
            switch (p_obj.OpCode)
            {
                case TacticalObjectOpCode.CreateRoute:
                    onCreateRoute();
                    break;

            }
        }

        private void onObjectCommandReceivedEvent(ObjectManagement p_obj)
        {
            switch (p_obj.OpCode)
            {
                case ObjectControlOpCode.Add:
                    //check type here
                    onAddTank();
                    break;
                case ObjectControlOpCode.HighlightObjects:
                    m_markEntities = p_obj.Highlight;
                    break;
            }
        }

        private void publishEntities()
        {
            foreach (var tank in m_tanksList)
            {
                var type = new DIS1998net.EntityType
                {
                    EntityKind = 1,    
                    Country = 255,    
                    Domain = 1,     
                    Category = 1,      
                    Subcategory = 1,   
                    Specific = 3,
                    Extra = 1
                };

                var location = new Vector3Double
                {
                    X = tank.m_object.transform.localPosition.x,
                    Y = tank.m_object.transform.localPosition.z,
                    Z = tank.m_object.transform.localPosition.y,
                };

                var orient = new Orientation
                {
                    Phi = tank.m_object.transform.eulerAngles.x,
                    Psi = tank.m_object.transform.eulerAngles.z,
                    Theta = tank.m_object.transform.eulerAngles.y,
                };

                var rb = tank.m_object.GetComponent<Rigidbody>();

                var vel = new Vector3Float
                {
                    X = rb.velocity.x,
                    Y = rb.velocity.z,
                    Z = rb.velocity.y,
                };

                m_disSender.PublishEntityState((ushort)m_tanksList.IndexOf(tank), type, location, orient, vel);
            }
        }
    
        // Update is called once per frame
        void Update()
        {
            handleObjectAddition();
            handleObjectSelection();
            updateMarkers(m_markEntities);
            testMovment();
            publishEntities();
        }

        void testMovment()
        {
            if (m_tanksList.Count < 1 || m_routeList.Count == 0 || m_routeList[0].m_waypoints.Length <= m_currentInsdex)
                return;


            var current = m_routeList[0].m_waypoints[m_currentInsdex];

            if (Vector3.Distance(m_tanksList[0].m_object.transform.position, current) < 10)
            {
                m_currentInsdex++;

                if (m_currentInsdex == m_routeList[0].m_waypoints.Length)
                    return;

                current = m_routeList[0].m_waypoints[m_currentInsdex];
            }

            m_tanksList[0].m_object.transform.position = Vector3.MoveTowards(m_tanksList[0].m_object.transform.position, current, 10 * Time.deltaTime);
            var rotate = Quaternion.LookRotation(current - m_tanksList[0].m_object.transform.position);
            m_tanksList[0].m_object.transform.rotation = Quaternion.Slerp(m_tanksList[0].m_object.transform.rotation, rotate, 2 * Time.deltaTime);

        }

        void onAddTank()
        {
            m_putTank = true;
            stopRouteEdit();
        }

        private void stopRouteEdit()
        {
            m_createRoute = false;
            if (m_currentRoute.Count > 0)
            {
                var route = new RouteData(m_currentRoute);
                m_routeList.Add(route);
                m_currentRoute.Clear();
                //drawRoute(route);
                var r = Instantiate(routeDisplayPrefab) as RouteDisplay;
                r.Waypoints = route.m_waypoints.ToList();
            }
        }

        void onCreateRoute()
        {
            m_createRoute = true;
            m_putTank = false;
        }

        void handleObjectSelection()
        {
            if (Input.GetMouseButtonDown(0) && !m_putTank)
            {
                RaycastHit hit;
                Ray ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (!hit.collider.CompareTag("Entity"))
                        return; //ignore

                    var parent = hit.collider.gameObject.transform.parent.gameObject;
                    var obj = m_tanksList.FirstOrDefault(p => p.m_object == parent);

                    if (obj == null)
                        return;

                    onSelectionButtonClick(obj);
                }
            }

            var selected = m_tanksList.FirstOrDefault(o => o.IsSelected);
            if (selected == null)
                return;

            if (selected.m_selection == null)
            {
                selected.m_selection = Instantiate(HaloSelected, new Vector3(selected.m_object.transform.position.x, selected.m_object.transform.position.y, selected.m_object.transform.position.z), Quaternion.identity);
            }
            else
            {
                selected.m_selection.transform.position = new Vector3(selected.m_object.transform.position.x, selected.m_object.transform.position.y, selected.m_object.transform.position.z);
            }
        }

        //void objectScaling(bool p_scale)
        //{
        //    if (p_scale)
        //    {
        //        foreach (var obj in m_tanksList)
        //        {
        //            obj.m_object.transform.localScale = new Vector3(m_scaleValue, m_scaleValue, m_scaleValue);
        //        }
        //    }
        //    else
        //    {
        //        foreach (var obj in m_tanksList)
        //        {
        //            obj.m_object.transform.localScale = new Vector3(1, 1, 1);
        //        }
        //    }
        //}

        void updateMarkers(bool p_mark)
        {
            foreach (var obj in m_tanksList)
            {
                if (p_mark && !obj.IsSelected)
                {
                    if (obj.m_marker == null)
                    {
                        obj.m_marker = Instantiate(HaloPref, new Vector3(obj.m_object.transform.position.x, obj.m_object.transform.position.y, obj.m_object.transform.position.z), Quaternion.identity);
                    }
                    else
                    {
                        obj.m_marker.transform.position = new Vector3(obj.m_object.transform.position.x, obj.m_object.transform.position.y, obj.m_object.transform.position.z);
                    }
                }
                else
                {
                    if (obj.m_marker == null)
                        continue;
                    else
                    {
                        Destroy(obj.m_marker);
                        obj.m_marker = null;
                    }
                }
            }
        }

        void handleObjectAddition()
        {
            if (Input.GetMouseButtonDown(0) && m_putTank)
            {
                RaycastHit hit;
                Ray ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    var t = Instantiate(TankObject, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                    GameObjectData data = new GameObjectData();
                    data.m_object = t;
                    m_tanksList.Add(data);
                }
            }

            else if (Input.GetMouseButtonDown(0) && m_createRoute)
            {
                RaycastHit hit;
                Ray ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    var t = Instantiate(WaypointObj, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                    m_currentRoute.Add(hit.point);
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                m_putTank = false;
                stopRouteEdit();
            }

        }

        private void onSelectionButtonClick(GameObjectData p_obj)
        {
            p_obj.IsSelected = !p_obj.IsSelected;

            foreach (var o in m_tanksList)
            {
                if (o == p_obj && p_obj.IsSelected)
                    continue;

                o.IsSelected = false;

                if (o.m_selection != null)
                {
                    Destroy(o.m_selection);
                    o.m_selection = null;
                }
            }
        }

    }

    public class RouteData
    {
        public Vector3[] m_waypoints;

        public RouteData(IList<Vector3> p_waypoints)
        {
            m_waypoints = p_waypoints.ToArray();
        }
    }
}