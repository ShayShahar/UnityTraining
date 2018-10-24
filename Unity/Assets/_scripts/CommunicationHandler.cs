using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;

using UnitiyAPI;

namespace Assets._scripts
{
    public class CommunicationHandler
    {
        public delegate void ObjectCommandReceived(ObjectManagement p_obj);
        public delegate void CameraControlCommandReceived(CameraView p_obj);

        public event ObjectCommandReceived ObjectCommandReceivedEvent;
        public event CameraControlCommandReceived CameraControlCommandReceivedEvent;

        private static CommunicationHandler m_communicationHandler = null;

        //private NetMQPoller m_poller;
        //private SubscriberSocket m_pullSocket;
        //private NetMQSocket m_pushSocket;


        private static object m_locker = new object();

        private CommunicationHandler()
        {
         //   //m_context = NetMQContext.Create();
         //   m_pullSocket = new SubscriberSocket();

         //   m_poller = new NetMQPoller();
         //   m_poller.Add(m_pullSocket);
         //   m_pullSocket.ReceiveReady += onMessageReceived;
         //   m_poller.Run();
         ////   m_poller.PollTillCancelledNonBlocking();

         //   m_pullSocket.Connect("tcp://127.0.0.1:40000");
         //   m_pullSocket.Subscribe("", Encoding.ASCII);

            //m_pushSocket = m_context.CreatePushSocket();
            //m_pushSocket.Connect("tcp://127.0.0.1:40001");
        }

        public static CommunicationHandler GetInstance()
        {
            lock (m_locker)
            {
                if (m_communicationHandler == null)
                {
                    m_communicationHandler = new CommunicationHandler();
                }

                return m_communicationHandler;
            }
        }

        //private void onMessageReceived(object p_sender, NetMQSocketEventArgs p_e)
        //{
        //    Debug.Print("asdasdasdas");
        //    var msg = UnityGlobalCommand.Parser.ParseFrom(p_e.Socket.ReceiveFrameBytes());

        //    switch (msg.OpCode)
        //    {
        //        case CommandOpCode.CameraControl:
        //            if (CameraControlCommandReceivedEvent != null)
        //            {
        //                CameraControlCommandReceivedEvent.Invoke(msg.CameraView);
        //            }
        //            break;
        //        case CommandOpCode.ObjectManagement:
        //            if (ObjectCommandReceivedEvent != null)
        //            {
        //                ObjectCommandReceivedEvent.Invoke(msg.ObjectManagement);
        //            }
        //            break;
        //    }
        //}

        //public void Send(UnityGlobalCommand p_msg)
        //{
        //    m_pushSocket.SendFrame(p_msg.ToByteArray());
        //}
    }
}
