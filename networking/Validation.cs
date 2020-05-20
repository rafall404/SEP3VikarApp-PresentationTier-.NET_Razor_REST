using SEP3.Networking.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SEP3.Networking
{
    public class Validation
    {
        public static string ValidateRegist(RegistDTO registDTO)
        {
            string errorMessage;

            var hasNumberAndletter = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

            if (!hasNumberAndletter.IsMatch(registDTO.password))
            {
                errorMessage = "Password must contain at least one letter and one number";
            }
            else if (!registDTO.password.Equals(registDTO.repeatPassword))
            {
                errorMessage = "Passwords don't match";
            }
            else if (registDTO.isNull())
            {
                errorMessage = "Any field can't be empty";
            }
            else
            {
                errorMessage = "none";
            }

            return errorMessage;
        }
    }
}
