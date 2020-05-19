﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
    public class jobDetailModel : PageModel
    {

        public Job Job { get; set; }


        public async void OnGet(string jobId)
        {
            var url = "http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api";

            var response = await Client.client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

        }



        public async Task<IActionResult> OnPostAsyn()
        {
            var userInfoJson = HttpContext.Session.GetString("userInfo");
            Account user = JsonSerializer.Deserialize<Account>(userInfoJson);

            ApplyJobDTO applyJob = new ApplyJobDTO(Job.id,user.userId);
            var json = JsonSerializer.Serialize(applyJob);
            var DataToSever = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:8080/BusinessLogicProofOfConcept-1.0-SNAPSHOT/api/apply/newApplication";
           

            var response = await Client.client.PostAsync(url,DataToSever);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var ResultFromServer = JsonSerializer.Deserialize<Boolean>(responseBody);

            if (!ResultFromServer)
            {
                return RedirectToPage("./Popup");
            }

            return RedirectToPage("./homepage");
        }






    }
}