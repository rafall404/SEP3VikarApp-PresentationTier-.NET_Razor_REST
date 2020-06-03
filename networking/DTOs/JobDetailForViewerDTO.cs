﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.Networking.DTOs
{
    public class JobDetailForViewerDTO
    {
        public long jobId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string location { get; set; }
        public double wages { get; set; }
        public DateTime time { get; set; }
        public string status { get; set; }


        public string username { get; set; }
        public string email { get; set; }
    }
}
