using System.Web.Mvc;

namespace LED.WebUI.Areas.SystemManagement
{
    public class SystemManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SystemManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SystemManagement_default",
                "SystemManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
