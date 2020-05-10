using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Models;
using SEP3.Networking;

namespace SEP3.Pages
{
    public class accountModel : PageModel
    {
        public Account Account { get; set; }


        public void OnGet()
        {

        }





        public async Task<IActionResult> OnPostLoginAsync()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            Console.WriteLine(Account.username + ", " + Account.password);
            var json = JsonSerializer.Serialize(Account);
            var DataToSever = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "";

            var response = await Client.client.PostAsync(url, DataToSever);
            response.EnsureSuccessStatusCode();

            return RedirectToPage("./profile");
        }













    }
}