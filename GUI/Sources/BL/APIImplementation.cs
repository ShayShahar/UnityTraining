using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using UnitiyAPI;
using UnityUIWrapper.Model;

namespace UnityUIWrapper.BL
{
    public class APIImplementation
    {
        private readonly CommunicationHandler m_commHandler;
        private static APIImplementation s_api = null;

        private  APIImplementation()
        {
            m_commHandler = CommunicationHandler.Instance;
        }

        public static APIImplementation Instance
        {
            get
            {
                if (s_api == null)
                {
                    s_api = new APIImplementation();
                }

                return s_api;
            }
        }

        public void ToggleEntitiesHighlight(bool p_enable)
        {
            UnityGlobalCommand command = new UnityGlobalCommand();
            command.OpCode = CommandOpCode.ObjectManagement;

            command.ObjectManagement = new ObjectManagement();
            command.ObjectManagement.Highlight = p_enable;
            command.ObjectManagement.OpCode = ObjectControlOpCode.HighlightObjects;

            m_commHandler.Send(command.ToByteArray());
        }

        public void AddEntity(EntityObject p_entity)
        {
            UnityGlobalCommand command = new UnityGlobalCommand();
            command.OpCode = CommandOpCode.ObjectManagement;

            command.ObjectManagement = new ObjectManagement();
            command.ObjectManagement.ObjectType = p_entity.TypeId;
            command.ObjectManagement.OpCode = ObjectControlOpCode.Add;

            m_commHandler.Send(command.ToByteArray());

        }

        internal void CreateRoute()
        {
            var builder = new UnityGlobalCommand
            {
                OpCode = CommandOpCode.TacticalObject,
                TacticalObjectManagement = new TacticalObjectManagement {OpCode = TacticalObjectOpCode.CreateRoute}
            };

            m_commHandler.Send(builder.ToByteArray());
        }

        public void SetCameraView(CameraView p_view)
        {
            var builder = new UnityGlobalCommand();
            builder.OpCode = CommandOpCode.CameraControl;
            builder.CameraView = p_view;

            m_commHandler.Send(builder.ToByteArray());
        }
    }
}
