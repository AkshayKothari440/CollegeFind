using Microsoft.AspNetCore.Mvc;
using CollegeFind.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeFind.Pages.ViewComponents
{
    public class CollegeCountViewComponent:ViewComponent
    {
        private readonly ICollegeData collegeData;
        public CollegeCountViewComponent(ICollegeData collegeData)
        {
            this.collegeData = collegeData;
        }
        public IViewComponentResult Invoke()
        {
            var count = collegeData.GetCountOfColleges();
            return View(count);
        }
    }
}
