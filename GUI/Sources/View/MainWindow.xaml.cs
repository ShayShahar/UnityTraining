using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using Google.Protobuf;
using MahApps.Metro.Controls;
using NetMQ;
using NetMQ.Sockets;
using UnitiyAPI;
using UnityUIWrapper.BL;

namespace UnityUIWrapper.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly CommunicationHandler m_commHandler;

        public MainWindow()
        {
            InitializeComponent();
            m_commHandler = CommunicationHandler.Instance;

            //CameraChange.IsReadOnly = true;
            //CameraChange.ItemsSource = new List<string>(){"Plan View", "Free Look"};
            //CameraChange.SelectedValue = "Plan View";
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            m_commHandler.Close();

            base.OnClosing(e);
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (CameraChange.SelectedValue == null)
            //    return;

            //string type = CameraChange.SelectedValue.ToString();

            //var builder = new UnityGlobalCommand();
            //builder.OpCode = CommandOpCode.CameraControl;

            //if (type == "Plan View")
            //{
            //    builder.CameraView = CameraView.PlanView;
            //}
            //else if (type == "Free Look")
            //{
            //    builder.CameraView = CameraView.FreeLook;
            //}

            //m_commHandler.Send(builder.ToByteArray());
        }
    }
}
