using System;
using System.Collections.Generic;

namespace LED.Domain.Entities
{
    public class t_user
    {
        public t_user()
        {
            this.role = new List<t_role>();
        }

        public string userid { get; set; }
        public string loginuser { get; set; }
        public string name { get; set; }
        public string orgcode { get; set; }
        public string password { get; set; }
        public virtual t_org org { get; set; }
        public virtual ICollection<t_role> role { get; set; }
    }
}
