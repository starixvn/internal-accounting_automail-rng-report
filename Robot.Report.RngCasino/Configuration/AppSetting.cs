// -----------------------------------------------------------------------
// <copyright file="AppSetting.cs" company="Nexcel">
// TODO: Mapping Application setting to class
// </copyright>
// -----------------------------------------------------------------------

namespace Robot.Report.RngCasino.Configuration
{
    /// <summary>
    /// TODO: Mapping application setting.
    /// </summary>
    public static class AppSetting
    {
        public static int TimeInterval
        {
            get { return Fanex.Common.Converter.ToInt(System.Configuration.ConfigurationManager.AppSettings["TimeInterval"]); }
        }

        public static bool Testing
        {
            get
            {
                return Fanex.Common.Converter.ToBool(System.Configuration.ConfigurationManager.AppSettings["Testing"]);
            }
        }
    }
}
