using System;
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
    public class IndexModel : PageModel
    {
        private readonly CollegeFind.Data.CollegeFindDBContext _context;

        public IndexModel(CollegeFind.Data.CollegeFindDBContext context)
        {
            _context = context;
        }

        public IList<College> College { get;set; }

        public async Task OnGetAsync()
        {
            College = await _context.Colleges.ToListAsync();
        }
    }
}
