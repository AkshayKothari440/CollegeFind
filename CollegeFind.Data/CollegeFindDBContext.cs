using CollegeFind.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeFind.Data
{
    public class CollegeFindDBContext : DbContext
    {
        public CollegeFindDBContext(DbContextOptions<CollegeFindDBContext> options)
            :base(options)
        {

        }
        public DbSet<College> Colleges { get; set; }

    }
}
