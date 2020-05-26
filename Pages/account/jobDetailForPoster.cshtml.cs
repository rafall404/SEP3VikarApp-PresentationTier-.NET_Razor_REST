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

namespace SEP3.Pages.account
{
    public class jobDetailForPosterModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string jobId { get; set; }
        public Job Job { get; set; }



        public void OnGet()
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
        }




    }
}