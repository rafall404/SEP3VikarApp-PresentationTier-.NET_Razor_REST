using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3.Models;

namespace SEP3.Pages
{
    public class JobsModel : PageModel
    {
        public ArrayList jobs = new ArrayList();


        
        public void OnGet()
        {

        }
    }
}