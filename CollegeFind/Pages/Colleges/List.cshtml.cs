using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeFind.Core;
using CollegeFind.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CollegeFind.Pages.Colleges
{
    [Authorize]
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly ICollegeData collegeData;
        private readonly ILogger<ListModel> logger;
        public string Message { get; set; }

        public IEnumerable<College> Colleges { get; set; }
        [BindProperty(SupportsGet = true)] // Use kro k na kro chale
        public string SearchTerm { get; set; } //Add 1

        public ListModel(IConfiguration congif,ICollegeData collegeData, ILogger<ListModel> logger)
        {
            this.config = congif;
            this.collegeData = collegeData;
            this.logger = logger;
        }
        public void OnGet()
        {
            logger.LogError("Executing ListModel");
            Message = config["Message"];
            Colleges = collegeData.GetCollegesByName(SearchTerm);

        }
    }
}