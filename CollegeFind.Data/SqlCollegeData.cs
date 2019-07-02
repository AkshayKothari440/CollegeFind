using CollegeFind.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeFind.Data
{
    public class SqlCollegeData:ICollegeData
    {
        private readonly CollegeFindDBContext db;
        public SqlCollegeData(CollegeFindDBContext db)
        {
            this.db = db;
        }
        public College Add(College newCollege)
        {
            db.Add(newCollege);
            return newCollege;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public College Delete(int id)
        {
            var college = GetById(id);
            if (college != null)
            {
                db.Colleges.Remove(college);
            }
            return college;
        }

        public College GetById(int id)
        {
            return db.Colleges.Find(id);
        }
        public int GetCountOfColleges()
        {
            return db.Colleges.Count();
        }

        public IEnumerable<College> GetCollegesByName(string name)
        {
            var query = from r in db.Colleges
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public College Update(College updatedCollege)
        {
            var entity = db.Colleges.Attach(updatedCollege);
            entity.State = EntityState.Modified;
            return updatedCollege;
        }
    }
}
