using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CollegeFind.Core;
using CollegeFind.Data;

namespace CollegeFind.Pages.C2
{
    public class CreateModel : PageModel
    {
        private readonly CollegeFind.Data.CollegeFindDBContext _context;

        public CreateModel(CollegeFind.Data.CollegeFindDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public College College { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Colleges.Add(College);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}