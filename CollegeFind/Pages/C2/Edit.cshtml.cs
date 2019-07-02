using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeFind.Core;
using CollegeFind.Data;

namespace CollegeFind.Pages.C2
{
    public class EditModel : PageModel
    {
        private readonly CollegeFind.Data.CollegeFindDBContext _context;

        public EditModel(CollegeFind.Data.CollegeFindDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public College College { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            College = await _context.Colleges.FirstOrDefaultAsync(m => m.Id == id);

            if (College == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(College).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollegeExists(College.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CollegeExists(int id)
        {
            return _context.Colleges.Any(e => e.Id == id);
        }
    }
}
