using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.Networking.DTOs
{
    public class PostJobDTO
    {
        public long id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string location { get; set; }
        public Double price { get; set; }
        public DateTime dateTime { get; set; }
        public string username { get; set; }



    }
}
