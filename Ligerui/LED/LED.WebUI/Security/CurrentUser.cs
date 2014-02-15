using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LED.WebUI.Security
{
    public class CurrentUser
    {
        public static string UserId {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return HttpContext.Current.User.Identity.Name;
                }
                return null;
            }
        }
    }
}