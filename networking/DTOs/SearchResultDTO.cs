using SEP3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.Networking.DTOs
{
    public class SearchResultDTO
    {
        public List<Job> jobs { get; set; }
        public int numberOfJobs { get; set; }
    }
}
