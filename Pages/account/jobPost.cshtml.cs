using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Models;
using SEP3.Networking;

namespace SEP3.Pages.account
{
    public class jobPostModel : PageModel
    {


        [BindProperty]
        public Job NewJob { get; set; }



        public async Task<IActionResult> OnPostNewJobAsync()
        {
            var json = JsonSerializer.Serialize(NewJob);
            var DataToSever = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/job/create/";

            var response = await Client.client.PostAsync(url, DataToSever);
            response.EnsureSuccessStatusCode();

            return RedirectToPage("./jobManagement");
        }





    }
}