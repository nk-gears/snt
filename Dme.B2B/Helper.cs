using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dme.B2B
{
    static class Helper
    {
        public static string GetUserName()
        {
            return System.ServiceModel.ServiceSecurityContext.Current==null ? string.Empty : System.ServiceModel.ServiceSecurityContext.Current.WindowsIdentity.Name;
        }

        public static string GetAppVersion()
        {
            var an = Assembly.GetExecutingAssembly().GetName();
            return String.Format("{0} [{1}]",
                an.Name,
                an.Version.ToString());
        }
    }
}
