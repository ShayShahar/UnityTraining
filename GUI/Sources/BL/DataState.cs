using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using UnitiyAPI;
using UnityUIWrapper.Model;

namespace UnityUIWrapper.BL
{
    public class DataState
    {
        private static DataState s_state = null;

        private APIImplementation m_api;
        private readonly ISubject<Unit> m_propertyUpdatedEvent = new Subject<Unit>();
        private bool m_highlightObjects = false;
        private CameraView m_cameraView = CameraView.PlanView;

        public List<EntityObject> ObjectTypeList { get; set; }

        public bool HighlightEntities
        {
            get { return m_highlightObjects; }
            set
            {
                if (m_highlightObjects == value)
                    return;

                m_highlightObjects = value;
                m_propertyUpdatedEvent.OnNext(new Unit());

                m_api.ToggleEntitiesHighlight(m_highlightObjects);
            }
        }

        public IObservable<Unit> PropertyUpdatedEvent
        {
            get { return m_propertyUpdatedEvent; }
        }

        public void SetSelectedCamera(CameraView p_camera)
        {
            if (p_camera == m_cameraView)
                return;

            m_cameraView = p_camera;
            m_api.SetCameraView(m_cameraView);
            m_propertyUpdatedEvent.OnNext(new Unit());
        }

        public CameraView SelectedCameraView
        {
            get { return m_cameraView; }
        }

        private DataState()
        {
            m_api = APIImplementation.Instance;


            ObjectTypeList = new List<EntityObject>();

            ObjectTypeList.Add(new EntityObject
            {
                Name = "T-72 Tank",
                TypeId = 1
            });
        }

        public static DataState Instance
        {
            get
            {
                if (s_state == null)
                {
                    s_state = new DataState();
                }

                return s_state;
            }
        }
    }
}
