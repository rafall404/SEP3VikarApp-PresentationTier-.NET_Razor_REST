using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Models;
using SEP3.Networking;
using SEP3.Networking.DTOs;

namespace SEP3.Pages
{
    public class accountModel : PageModel
    {
        public Account Account { get; set; }


        public void OnGet()
        {
            var userInfoJson = HttpContext.Session.GetString("userInfo");
            Account = JsonSerializer.Deserialize<Account>(userInfoJson);
        }

















    }
}