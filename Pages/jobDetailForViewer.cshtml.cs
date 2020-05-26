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
    public class jobDetailForViewerModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string jobId { get; set; }
        public  JobDetailForViewerDTO detail { get; set; }
        


        public async Task OnGet()
        {
            var url = $"http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/job/getJobAndPoster/?jobId={jobId}";

            var response = await Client.client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var ResultFromServer = JsonSerializer.Deserialize<JobDetailForViewerDTO>(responseBody);
            detail = (JobDetailForViewerDTO) ResultFromServer;
        }



        public async Task<IActionResult> OnPostApplyAsync()
        {
            var userInfoJson = HttpContext.Session.GetString("userInfo");
            Account user = JsonSerializer.Deserialize<Account>(userInfoJson);

            long jobIdLong = long.Parse(jobId);

            ApplyJobDTO applyJob = new ApplyJobDTO(jobIdLong, user.userId) ;

            Console.WriteLine(jobIdLong + user.userId + "$%$%$%$%$%$%$%$%$%$%$%$%");
            
           

            var json = JsonSerializer.Serialize(applyJob);
            Console.WriteLine(json + "&&&&&&&&&&&&&&&");
            var DataToSever = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/apply/newApplication";
           

            var response = await Client.client.PostAsync(url,DataToSever);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var ResultFromServer = JsonSerializer.Deserialize<Boolean>(responseBody);

            if (!ResultFromServer)
            {
                return RedirectToPage("/account/profile");
            }

            return RedirectToPage("./homepage");
        }






    }
}