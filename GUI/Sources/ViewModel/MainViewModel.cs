using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using UnitiyAPI;
using UnityUIWrapper.BL;
using UnityUIWrapper.Model;

namespace UnityUIWrapper.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private DataState m_state;

        public List<string> CameraViewTypes { get; set; }

        public MainViewModel()
        {
            m_state = DataState.Instance;
            m_state.PropertyUpdatedEvent.ObserveOnDispatcher().Subscribe(onPropertyUpdate);

            CameraViewTypes = new List<string>() { "Plan View", "Free Look" };
        }


        public List<EntityObject> ObjectTypeList
        {
            get { return m_state.ObjectTypeList; }
        }

        public bool HighlightEntities
        {
            get { return m_state.HighlightEntities;}
            set { m_state.HighlightEntities = value; }
        }


        private void onPropertyUpdate(Unit p_unit)
        {
            RaisePropertyChanged(() => ObjectTypeList);
            RaisePropertyChanged(() => HighlightEntities);
            RaisePropertyChanged(() => SelectedCameraView);
        }

        public string SelectedCameraView
        {
            get
            {
                if (m_state.SelectedCameraView == CameraView.FreeLook)
                {
                    return "Free Look";
                }
                else
                {
                    return "Plan View";
                }
            }
            set
            {
                if (value == "Free Look")
                {
                    m_state.SetSelectedCamera(CameraView.FreeLook);
                }
                else
                {
                    m_state.SetSelectedCamera(CameraView.PlanView);
                }

            }
        }

    }
}