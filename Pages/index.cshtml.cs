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

namespace SEP3.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public LoginDTO Login { get; set; }
        [BindProperty]
        public RegistDTO Regist { get; set; }

      



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
                string js = @"<Script language='JavaScript'>alert('{0}');history.go(-1);</Script>";
                await HttpContext.Response.WriteAsync(string.Format(js, "wrong username or password"));
            }

            await GetAccount();
            return RedirectToPage("./homepage");
        }
        


        public async Task<IActionResult> SendAsyncRegister(RegistDTO regist)
        {

            string errorMessage = Validation.ValidateRegist(regist);
            Console.WriteLine(errorMessage + "#######################################################");

            if (!errorMessage.Equals("none")) 
            {
                string js = @"<Script language='JavaScript'>alert('{0}');history.go(-1);</Script>";
                await HttpContext.Response.WriteAsync(string.Format(js, errorMessage));
            }

            var json = JsonSerializer.Serialize(regist);
            var DataToSever = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/account/register";

            var response = await Client.client.PostAsync(url, DataToSever);
            
            response.EnsureSuccessStatusCode();
            return RedirectToPage("./index");
        }





        private async Task GetAccount()
        {
            var json = JsonSerializer.Serialize(Login);
            var DataToSever = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/account/getAccount";

            var response = await Client.client.PostAsync(url, DataToSever);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            HttpContext.Session.SetString("userInfo", responseBody);
            Console.WriteLine(responseBody + "#######################################################");
        }







    }
}
