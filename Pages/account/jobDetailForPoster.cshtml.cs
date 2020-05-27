using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Models;
using SEP3.Networking;
using SEP3.Networking.DTOs;

namespace SEP3.Pages.account
{
    public class jobDetailForPosterModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string jobId { get; set; }
        public Job Job { get; set; }
        public List<Applicant> applicants { get; set; }



        public async Task OnGetAsync()
        {
            var jobsJson = HttpContext.Session.GetString("posterJobs");
            List<Job> jobs = JsonSerializer.Deserialize<List<Job>>(jobsJson);
            foreach(Job job in jobs)
            {
                if(job.id== long.Parse(jobId))
                {
                    Job = job;
                }
            }

            var url = $"http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/job/getApplicants/?jobId={jobId}";
            
            var response = await Client.client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody + "^^^^^^^^^^^^^^^^^^^");
            applicants = JsonSerializer.Deserialize<List<Applicant>>(responseBody);
        }


        public IActionResult OnPostEdit()
        {
            return RedirectToPage("./searchResult", new { jobId = jobId });
        }


        public async Task OnGetDeleteAsync()
        {
            var url = $"http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/";

            var response = await Client.client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();


        }




    }
}