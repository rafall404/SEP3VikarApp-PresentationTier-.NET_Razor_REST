using SEP3.Networking.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SEP3.Models
{
    public static class Validation
    {


        public static Boolean ValidateRegist(RegistDTO registDTO)
        {
            var hasNumberAndletter = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");


            return hasNumberAndletter.IsMatch(registDTO.password);
        }





    }
}
