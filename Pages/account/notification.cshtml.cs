﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SEP3.Pages
{
    public class notificationModel : PageModel
    {

        public ArrayList notifications = new ArrayList();




        public void OnGet()
        {

        }
    }
}