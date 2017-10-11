using System.Configuration;

namespace Hostmaker.Selenium.Utility
{
    public static class HostmakerEnvironmentManager
    {
        public static string WebUrl => ConfigurationManager.AppSettings["WebUrl"];

        public static string SeleniumGridHubUrl => ConfigurationManager.AppSettings["SeleniumGridHubUrl"];

        public static string Browser => ConfigurationManager.AppSettings["Browser"];
    }
}