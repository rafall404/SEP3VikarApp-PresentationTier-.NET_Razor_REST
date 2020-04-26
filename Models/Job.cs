using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.Models
{
    public class Job
    {
        public string title{ get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string location { get; set; }
        public string wages { get; set; }
        public DateTime time { get; set; }

    }
}
