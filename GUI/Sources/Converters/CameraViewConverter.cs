using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UnitiyAPI;

namespace UnityUIWrapper.Converters
{
    public class CameraViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            var lst = (List<CameraView>)value;

            if (lst == null)
                return null;

            List<string> res = new List<string>();

            foreach (var t in lst)
            {
                switch (t)
                {
                    case CameraView.FreeLook:
                        res.Add("Free Look");
                        break;
                    default:
                        res.Add("Plan View");
                        break;
                }
            }

            return res;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
