using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Testing_Sending_Email.Business
{
    public static class AppSettings
    {
        public static string To
        {
            get 
            {
                return System.Configuration.ConfigurationSettings.AppSettings["To"];
            }
        }
    }
}
