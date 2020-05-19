using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text;
using System.Net.Http;
using SEP3.Networking;
using SEP3.Networking.DTOs;
using Microsoft.AspNetCore.Http;
using SEP3.Models;

namespace SEP3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public LoginDTO Login { get; set; }
        [BindProperty]
        public RegistDTO Regist { get; set; }



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


        public async Task<IActionResult> SendAsyncLogin(LoginDTO login)
        {
            
            // Call asynchronous network methods in a try/catch block to handle exceptions.
           
            var json = JsonSerializer.Serialize(login);
            var DataToSever = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/account/login/";

            var response = await Client.client.PostAsync(url, DataToSever);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var ResultFromServer = JsonSerializer.Deserialize<Boolean>(responseBody);
            Console.WriteLine(ResultFromServer + "################");
            if (!ResultFromServer)
            {
                return RedirectToPage("./Popup");
            }

            GetAccount();
            return RedirectToPage("./homepage");
        }
        


        public async Task<IActionResult> SendAsyncRegister(RegistDTO regist)
        {
            
            // Call asynchronous network methods in a try/catch block to handle exceptions.
           Console.WriteLine(regist.username+", "+regist.password);

            if (!Validation.ValidateRegist(regist)) 
            {
                return RedirectToPage("./index");
            }

            var json = JsonSerializer.Serialize(regist);
            var DataToSever = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/account/register";

            var response = await Client.client.PostAsync(url, DataToSever);
            response.EnsureSuccessStatusCode();
            return RedirectToPage("./index");
        }





        private async void GetAccount()
        {
            var url = $"http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/account/getAccount/?username={Login.username}";

            var response = await Client.client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            HttpContext.Session.SetString("userInfo", responseBody);

        }







    }
}
