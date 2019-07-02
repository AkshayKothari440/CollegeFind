﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CollegeFind.Core;
using CollegeFind.Data;

namespace CollegeFind.Pages.C2
{
    public class DeleteModel : PageModel
    {
        private readonly CollegeFind.Data.CollegeFindDBContext _context;

        public DeleteModel(CollegeFind.Data.CollegeFindDBContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            College = await _context.Colleges.FindAsync(id);

            if (College != null)
            {
                _context.Colleges.Remove(College);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
