using System.Collections.Generic;
using System.Windows.Controls;
using Google.Protobuf;
using MahApps.Metro.Controls;
using NetMQ;
using NetMQ.Sockets;
using UnityUIWrapper.Messages;

namespace UnityUIWrapper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private NetMQContext m_context;
        private PublisherSocket m_pushSocket;

        public MainWindow()
        {
            InitializeComponent();

            m_context = NetMQContext.Create();
            m_pushSocket = m_context.CreatePublisherSocket();
            m_pushSocket.Bind("tcp://127.0.0.1:12345");

            CameraChange.IsReadOnly = true;
            CameraChange.ItemsSource = new List<string>(){"Plan View", "Free Look"};
            CameraChange.SelectedValue = "Plan View";
        }


        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CameraChange.SelectedValue == null)
                return;

            string type = CameraChange.SelectedValue.ToString();

            var builder = new UnityGlobalCommand();
            builder.OpCode = CommandOpCode.CameraControl;

            if (type == "Plan View")
            {
                builder.CameraView = CameraView.PlanView;
            }
            else if (type == "Free Look")
            {
                builder.CameraView = CameraView.FreeLook;
            }

            m_pushSocket.SendFrame(builder.ToByteArray());
        }
    }
}
