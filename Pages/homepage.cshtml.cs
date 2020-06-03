using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SEP3.Pages
{
    public class homepageModel : PageModel
    {
        [BindProperty]
        public string SearchString { get; set; }


        public IActionResult OnPost()
        {
            return RedirectToPage("./searchResult", new { searchString = SearchString, CurrentPage = 1 }) ;
        }
    }
}