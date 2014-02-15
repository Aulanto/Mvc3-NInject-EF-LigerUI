using System;
using System.Collections.Generic;

 namespace LED.Domain.Entities
{
    public  class t_role
    {
        public t_role()
        {
            this.t_resources = new List<t_resources>();
            this.t_user = new List<t_user>();
        }
        public int roleid { get; set; }
        public string rolename { get; set; }
        public virtual ICollection<t_resources> t_resources { get; set; }
        public virtual ICollection<t_user> t_user { get; set; }
    }
}
