using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Models;
using SEP3.Networking;
using SEP3.Networking.DTOs;

namespace SEP3.Pages
{
    public class searchResultModel : PageModel
    {
        [BindProperty]
        public string SearchString { get; set; }
        public List<Job> Jobs { get; set; }


        [BindProperty]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; } = 100;
        public int PageSize { get; set; } = 8;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));


        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;


        public async Task OnGetAsync(string SearchString)
        {
            long jobIdToShowFrom = (CurrentPage - 1) * PageSize;
            var url = $"http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/job/getJobs/?location={SearchString}&id={jobIdToShowFrom}";

            var response = await Client.client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            SearchResultDTO searchResult = JsonSerializer.Deserialize<SearchResultDTO>(responseBody);

            Jobs = searchResult.jobs;
            Count = searchResult.numberOfJobs;
        }






    
}
}