using System;
using System.Collections.Generic;

namespace LED.Domain.Entities
{
    public  class t_resources
    {
        public t_resources()
        {
            this.role = new List<t_role>();
        }

        public int rid { get; set; }
        public string resources { get; set; }
        public string url { get; set; }
        public int? type { get; set; }
        public int? parentrid { get; set; }
        public int? tindex { get; set; }
        public string name { get; set; }

        public virtual ICollection<t_role> role { get; set; }
    }
}
