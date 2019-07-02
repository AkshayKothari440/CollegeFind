using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeFind.Core;
using CollegeFind.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CollegeFind.Pages.Colleges
{
    public class DetailModel : PageModel
    {
        private readonly ICollegeData collegeData; // add for fetch Id
        [TempData]
        public string Message { get; set; } // add for show message "Restaurant Saved!" 
        public College College { get; set; }
        public DetailModel(ICollegeData collegeData) //add for fetch Id
        {
            this.collegeData = collegeData;
        }
        public IActionResult OnGet(int collegeId)
        {
            College = collegeData.GetById(collegeId);
            //Restaurant = new Restaurant();
            //Restaurant.Id = restaurantId;
            if (College == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}