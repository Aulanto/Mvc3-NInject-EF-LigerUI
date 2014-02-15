using System;
using System.Collections.Generic;

namespace LED.Domain.Entities
{
    public  class t_org
    {
        public string orgcode { get; set; }
        public string name { get; set; }
        public string parentCode { get; set; }
        public int? orgtype { get; set; }
    }
}
