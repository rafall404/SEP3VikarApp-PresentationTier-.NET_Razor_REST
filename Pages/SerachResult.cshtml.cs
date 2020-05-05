using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Models;
using System.Text.Json;
using SEP3.networking;
using System.Net.Http;
using System.Text;

namespace SEP3.Pages
{
    public class SerachResultModel : PageModel
    {
        public String searchString;
        public List<Job> Jobs;


        [BindProperty]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 8;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));


        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;


        public async Task OnGetAsync(string searchString)
        {
            Count = await GetCount();
            Jobs = await GetPaginatedResult();
        }



        private async Task<List<Job>> GetPaginatedResult()
        {
            int jobResultToShowFrom = CurrentPage * PageSize + 1;
            var url = "";
           
            
            var response = await Client.client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<Job> jobs = JsonSerializer.Deserialize<List<Job>>(responseBody);

            return jobs;
        }


        private async Task<int> GetCount()
        {
            var url = "";

            var response = await Client.client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            int count = JsonSerializer.Deserialize<int>(responseBody);

            return count;
        }










    }
}