using System.Windows.Controls;
using UnityUIWrapper.BL;

namespace UnityUIWrapper
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
