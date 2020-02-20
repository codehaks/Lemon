using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portal.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portal.Web.Areas.Admin.Pages.Users
{
    public class IndexModel : PageModel
    {
     

        private readonly UserManager<ApplicationUser> _userManager;


        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
           
        }

    

        public IList<ApplicationUser> List { get; set; }
        public string Term { get; set; }

        public void OnGet(string term = "")
        {
            
            if (string.IsNullOrEmpty(term))
            {
                List = _userManager
                .Users
             
                .ToList();
            }
            else
            {
                List = _userManager
                .Users
                .Where(u => u.UserName.StartsWith(term))
                .ToList();
            }

            Term = term;
         
        }
    }
}