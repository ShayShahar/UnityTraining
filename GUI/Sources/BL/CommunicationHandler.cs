using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;

namespace UnityUIWrapper.BL
{
    public class CommunicationHandler
    {
        private static CommunicationHandler s_commHandler = null;

        private NetMQContext m_context;
        private PublisherSocket m_pushSocket;


        private CommunicationHandler()
        {
            m_context = NetMQContext.Create();
            m_pushSocket = m_context.CreatePublisherSocket();
            m_pushSocket.Bind("tcp://127.0.0.1:40000");

        }

        public void Close()
        {
            m_pushSocket.Unbind("tcp://127.0.0.1:40000");
        }

        public static CommunicationHandler Instance
        {
            get
            {
                if (s_commHandler == null)
                {
                    s_commHandler = new CommunicationHandler();
                }

                return s_commHandler;
            }
        }

        public void Send(byte[] p_msg)
        {
            m_pushSocket.SendFrame(p_msg);
        }
    }
}
