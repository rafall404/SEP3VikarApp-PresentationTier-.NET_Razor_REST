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
        [BindProperty(SupportsGet = true)]
        public string searchString { get; set; }
        public List<Job> Jobs { get; set; }


        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 8;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));


        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;


        public async Task OnGetAsync()
        {
            long jobIdToShowFrom = (CurrentPage - 1) * PageSize;
            var url = $"http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/job/getJobs/?location={searchString}&id={jobIdToShowFrom}";

            var response = await Client.client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            SearchResultDTO searchResult = JsonSerializer.Deserialize<SearchResultDTO>(responseBody);

            Jobs = searchResult.jobs;
            Count = searchResult.numberOfJobs;
        }






    
}
}