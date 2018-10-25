using UnityEngine;
using System.Collections;
using UnitiyAPI;
using UnityEngine.UI;

public class MoveCamera : MonoBehaviour
{

    public ClientObject Client;

    public float turnSpeed = 2.0f;      // Speed of camera turning when mouse moves in along an axis
    public float panSpeed = 2.0f;       // Speed of the camera when being panned
    public float zoomSpeed = 4.0f;      // Speed of the camera going back and forth

    private Vector3 mouseOrigin;    // Position of cursor when mouse dragging starts
    private bool isPanning;     // Is the camera being panned?
    private bool isRotating;    // Is the camera being rotated?
    private bool isZooming;     // Is the camera zooming?

    private CameraView m_mode;
    //private Dropdown m_cameraModeDropDown;
    private Vector3 m_freeCamPosition;
    private Vector3 m_freeCamEuler;
    // private int m_currentDtValue = 0;
    private bool m_valueChanged = false;

   // private Button m_tank;

    public MoveCamera()
    {
        //m_commHandler = CommunicationHandler.GetInstance();
        //m_commHandler.CameraControlCommandReceivedEvent += onCameraControlEvent;
    }

    private void Start()
    {
        m_mode = CameraView.PlanView;

        Client.CameraControlCommandReceivedEvent += onCameraControlEvent;

        //m_cameraModeDropDown = GameObject.Find("CameraDropdown").GetComponent<Dropdown>();

        //if (m_cameraModeDropDown == null)
        //    throw new System.Exception();

        m_freeCamPosition = new Vector3(1000, 1000, 1000);
        m_freeCamEuler = new Vector3(45, 0, 0);

    //    m_tank = GameObject.Find("AddTank").GetComponent<Button>();
    }

    private void onCameraControlEvent(UnitiyAPI.CameraView p_obj)
    {
        if (p_obj != m_mode)
        {
            m_mode = p_obj;
            m_valueChanged = true;
        }
    }

    //
    // UPDATE
    //

    void Update()
    {
        //if (m_cameraModeDropDown.value != m_currentDtValue)
        //{
        //    m_currentDtValue = m_cameraModeDropDown.value;
        //    m_valueChanged = true;
        //} 

        if (m_valueChanged && m_mode == CameraView.PlanView)
        {
          //  m_mode = CameraMode.PLANE_VIEW;

            m_freeCamPosition.x = transform.position.x;
            m_freeCamPosition.y = transform.position.y;
            m_freeCamPosition.z = transform.position.z;
            m_freeCamEuler.x = transform.rotation.x;
            m_freeCamEuler.y = transform.rotation.y;
            m_freeCamEuler.z = transform.rotation.z;

            transform.eulerAngles = new Vector3(90, 0, 0);
            transform.position = new Vector3(1000, 1000, 1000);
          //  m_tank.interactable = true;
            m_valueChanged = false;
        }
        else if (m_valueChanged && m_mode == CameraView.FreeLook)
        {
            transform.position = new Vector3(m_freeCamPosition.x, m_freeCamPosition.y, m_freeCamPosition.z);
            transform.eulerAngles = new Vector3(m_freeCamEuler.x, m_freeCamEuler.y, m_freeCamEuler.z);
            m_valueChanged = false;

            //   m_tank.interactable = false;
            //m_mode = CameraMode.FREE;
        }


        // 
        //Get the left mouse button
        if (Input.GetMouseButtonDown(1) && m_mode != CameraView.PlanView)
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }

        // Get the right mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isPanning = true;
        }

        // Get the middle mouse button
        if (Input.GetMouseButtonDown(2))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isZooming = true;
        }

        // Disable movements on button release
        if (!Input.GetMouseButton(1)) isRotating = false;
        if (!Input.GetMouseButton(0)) isPanning = false;
        if (!Input.GetMouseButton(2)) isZooming = false;

        // Rotate camera along X and Y axis
        if (isRotating)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
            transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
        }

        // Move the camera on it's XY plane
        if (isPanning)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(mouseOrigin - Input.mousePosition);

            Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
            transform.Translate(move, Space.Self);
        }

        // Move the camera linearly along Z axis
        if (isZooming)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = pos.y * zoomSpeed * transform.forward;
            transform.Translate(move, Space.World);
        }

    }
}