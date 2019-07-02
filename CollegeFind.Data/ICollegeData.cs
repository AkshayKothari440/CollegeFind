using CollegeFind.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeFind.Data
{
    public interface ICollegeData
    {
        IEnumerable<College> GetCollegesByName(string searchTerm);
        College GetById(int id); // find by Id in URL using
        College Update(College updatedCollege);
        College Add(College newCollege);
        College Delete(int Id);
        int GetCountOfColleges();
        int Commit();
    }
}
