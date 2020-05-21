using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.Models
{
    public class Account
    {
        public long userId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstName{ get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public DateTime birthDate { get; set; }



    }
}
