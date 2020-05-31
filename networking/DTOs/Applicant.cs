using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.Networking.DTOs
{
    public class Applicant
    {
        public long id { get; set; }
        public string username { get; set; }
        public string emailAddress { get; set; }
        public bool isAccepted { get; set; }
    }
}
