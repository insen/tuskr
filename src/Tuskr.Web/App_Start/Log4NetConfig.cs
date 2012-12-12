namespace Tuskr.Web.App_Start
{
    public static class Log4NetConfig
    {
        public static void RegisterLog4NetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}