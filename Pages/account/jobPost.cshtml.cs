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

        private string username;

        [BindProperty]
        public PostJobDTO NewJob { get; set; }

        public void OnGet()
        {
            var userInfoJson = HttpContext.Session.GetString("userInfo");
            AccountDTO account = JsonSerializer.Deserialize<AccountDTO>(userInfoJson);
            username = account.username;
            Console.WriteLine(userInfoJson+"%^$@#%%@&!^(#%@&*%#$@&*$)%@&*$%)@*$^@&*");
        }

        public async Task<IActionResult> OnPostNewJobAsync()
        {
            Console.WriteLine(username + NewJob.location + NewJob.price + NewJob.dateTime + NewJob.title + "*%%&($%&^%^&TG!@!#^$%^&%&(%($%^&($^&($^(&$^&(%");
            NewJob.username = username;
            var json = JsonSerializer.Serialize(NewJob);
            var DataToSever = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/job/create";

            var response = await Client.client.PostAsync(url, DataToSever);
            response.EnsureSuccessStatusCode();

            return RedirectToPage("jobManagement");
        }





    }
}