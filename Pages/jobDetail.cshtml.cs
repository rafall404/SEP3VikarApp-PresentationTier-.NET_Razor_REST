using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Models;
using SEP3.networking;

namespace SEP3.Pages
{
    public class jobDetailModel : PageModel
    {

        public Job Job { get; set; }





        public async void OnGetAsyn()
        {
            var url = "";

            var response = await Client.client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            Job = JsonSerializer.Deserialize<Job>(responseBody);
        }






    }
}