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

namespace SEP3.Pages.account
{
    public class jobPostModel : PageModel
    {

        [BindProperty]
        public PostJobDTO NewJob { get; set; }

    

        public async Task<IActionResult> OnPostNewJobAsync()
        {
            var userInfoJson = HttpContext.Session.GetString("userInfo");
            Console.WriteLine(userInfoJson + "&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            AccountDTO  account = JsonSerializer.Deserialize<AccountDTO>(userInfoJson);
            NewJob.username = account.username;

            Console.WriteLine(NewJob.username + "qqqqqqqqqqqq"+ NewJob.location + "qqqqqqqqqqqq" + NewJob.price + "qqqqqqqqqqqq" + NewJob.dateTime + "qqqqqqqqqqqq" + NewJob.title + " *%%&($%&^%^&TG!@!#^$%^&%&(%($%^&($^&($^(&$^&(%");
            
            var json = JsonSerializer.Serialize(NewJob);
            
            var DataToSever = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/job/create";

            Console.WriteLine(json  + "json %%%%%%%%%%%%%%%%%%");
            var response = await Client.client.PostAsync(url, DataToSever);
            response.EnsureSuccessStatusCode();

            return RedirectToPage("jobManagement");
        }





    }
}