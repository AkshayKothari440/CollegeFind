using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeFind.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CollegeFind.Core;

namespace CollegeFind.Pages.Colleges
{
    public class EditModel : PageModel
    {
        private readonly ICollegeData collegeData;
        private readonly IHtmlHelper htmlHelper;  // use for edit 

        [BindProperty]
        public College College { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }  // use for edit 

        public EditModel(ICollegeData collegeData, IHtmlHelper htmlHelper /*use for edit*/)
        {
            this.collegeData = collegeData;
            this.htmlHelper = htmlHelper;   // use for edit 
        }
        public IActionResult OnGet(int? collegeId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>(); // use for edit menu wise
            if (collegeId.HasValue)
            {
                College = collegeData.GetById(collegeId.Value);
            }
            else
            {
                College = new College();
            }
            //Restaurant = restaurantData.GetById(restaurantId);
            if (College == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();

                //restaurantData.Update(Restaurant);
                //restaurantData.Commit();
                //return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });

            }
            //  Restaurant=restaurantData.Update(Restaurant); // use for update
            //   restaurantData.Update(Restaurant);    // use for update
            // return update page 
            if (College.Id > 0)
            {
                collegeData.Update(College);
            }
            else
            {
                collegeData.Add(College);
            }
            collegeData.Commit();
            TempData["Message"] = "College Saved!";
            return RedirectToPage("./Detail", new { collegeId = College.Id });
        }
    }
}