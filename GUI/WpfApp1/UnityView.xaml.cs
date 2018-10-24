using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for UnityView.xaml
    /// </summary>
    public partial class UnityView : UserControl
    {

        public UnityView()
        {
            InitializeComponent();

            //-possibly -other 
            UnityContainer.Children.Add(new UnityHwndHost("New Unity Project (2).exe", "-arguments"));
        }
    }
}
