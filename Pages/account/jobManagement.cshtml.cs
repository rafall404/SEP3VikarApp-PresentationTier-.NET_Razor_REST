using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public class JobsModel : PageModel
    {

        public List<Job> Jobs { get; set; }
        public AccountDTO account;


        [BindProperty]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 8;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        


        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;


        public async Task OnGetAsync(string SearchString)
        {
            var userInfoJson = HttpContext.Session.GetString("userInfo");
            account = JsonSerializer.Deserialize<AccountDTO>(userInfoJson);

            Count = account.postedJobsNo;
            Jobs = await GetPaginatedResult();
        }



        private async Task<List<Job>> GetPaginatedResult()
        {
            int jobResultToShowFrom = (CurrentPage - 1) * PageSize + 1;
            var url = $"http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/account/UserJobs?idUser={account.userId}&idJob={jobResultToShowFrom}";


            var response = await Client.client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<Job> jobs = JsonSerializer.Deserialize<List<Job>>(responseBody);

            return jobs;
        }


        
    }
}