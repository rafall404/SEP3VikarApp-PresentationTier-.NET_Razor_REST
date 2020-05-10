using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.Models
{
    public class Job
    {
        public long id { get; set; }
        public string title{ get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string location { get; set; }
        public Double wages { get; set; }
        public DateTime time { get; set; }
        public string status { get; set; }

    }
}
