using CollegeFind.Core;
using System.Collections.Generic;
using System.Linq;

namespace CollegeFind.Data
{
    public class InMemoryCollegeData:ICollegeData
    {
        readonly List<College> colleges;
        public InMemoryCollegeData()
        {
            colleges = new List<College>()
            {
               new College{Id=1, Name="Dominoze Pizza", Location="India", Cuisine=CuisineType.IT},
                new College{Id=2, Name="DZ-Pizza", Location="America", Cuisine=CuisineType.MBA},
                new College{Id=3, Name="Studio Pizza", Location="Canada", Cuisine=CuisineType.BBA}
            };
        }

        public IEnumerable<College> GetAll()
        {
            return from r in colleges
                   orderby r.Name
                   select r;
        }
        public College GetById(int id)
        {
            return colleges.SingleOrDefault(r => r.Id == id); //id is incoming Id value
        }
        //using for Add new restaurant details v
        public College Add(College newCollege)
        {
            colleges.Add(newCollege);
            newCollege.Id = colleges.Max(r => r.Id) + 1;//only for using this line testing and devloping but not real time use this line
            return newCollege;
        }
        //using for Update restaurant details v
        public College Update(College updatedCollege)
        {
            var college = colleges.SingleOrDefault(r => r.Id == updatedCollege.Id);
            if (college != null)
            {
                college.Name = updatedCollege.Name;
                college.Location = updatedCollege.Location;
                college.Cuisine = updatedCollege.Cuisine;
            }
            return college;
        }
        public int Commit()
        {
            return 0;
        }
        public IEnumerable<College> GetCollegesByName(string name = null)
        {
            return from r in colleges
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
        public College Delete(int Id)
        {
            int id = 0;
            var college = colleges.FirstOrDefault(r => r.Id == id);
            if (college != null)
            {
                colleges.Remove(college);
            }
            return college;
        }
        public int GetCountOfColleges()
        {
            return colleges.Count();
        }
    }
}
