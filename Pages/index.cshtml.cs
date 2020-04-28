using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SEP3.Models;
using System.Text.Json;
using System.Text;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SEP3.networking;

namespace SEP3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient client = new HttpClient();

        [BindProperty]
        public Login Login { get; set; }
        [BindProperty]
        public Regist Regist { get; set; }



        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        
      



        public async Task<IActionResult> OnPostLoginAsync()
        {
            return await SendAsyncLogin(Login);
        }

        public async Task<IActionResult> OnPostRegistAsync()
        {
            return await SendAsyncRegister(Regist);
        }


        public async Task<IActionResult> SendAsyncLogin(Login login)
        {
            
            // Call asynchronous network methods in a try/catch block to handle exceptions.
           
            var json = JsonSerializer.Serialize(login);
            var DataToSever = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/account/login" ;

            var response = await client.PostAsync(url, DataToSever);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var ResultFromServer = JsonSerializer.Deserialize<Boolean>(responseBody);
            Console.WriteLine(ResultFromServer + "################");
            if (!ResultFromServer)
            {
                Console.WriteLine("I came here");
                return RedirectToPage("./Popup");
            }
            return RedirectToPage("./homepage");
        }
        
        public async Task<IActionResult> SendAsyncRegister(Regist regist)
        {
            
            // Call asynchronous network methods in a try/catch block to handle exceptions.
           Console.WriteLine(regist.username+", "+regist.password);
            var json = JsonSerializer.Serialize(regist);
            var DataToSever = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/account/register" ;

            var response = await client.PostAsync(url, DataToSever);
            response.EnsureSuccessStatusCode();
            
            return RedirectToPage("./login");
        }














    }
}
