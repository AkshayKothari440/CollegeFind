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
    public class DeleteModel : PageModel
    {
        private readonly ICollegeData collegeData;
        public DeleteModel(ICollegeData collegeData)
        {
            this.collegeData = collegeData;
        }
        public College College { get; set; }
        public IActionResult OnGet(int collegeId)
        {
            College = collegeData.GetById(collegeId);
            if (College == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(int collegeId)
        {
            var college = collegeData.Delete(collegeId);
            collegeData.Commit();
            if (college == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{college.Name} Deleted.";
            return RedirectToPage("./List");
        }
    }
}