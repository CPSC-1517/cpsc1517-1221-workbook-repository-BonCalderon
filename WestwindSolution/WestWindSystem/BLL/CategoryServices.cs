using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class CategoryServices
    {
        // Step 1: Define a readonly data field for the custom DbContext class

        private readonly WestwindContext _dbContext;

        // Step 2: Setup constructor for dependency injection for the custom DbContext type
        internal CategoryServices(WestwindContext context)
        {
            _dbContext = context;
        }

        // Step 3: Define methods to query and save instances of the entity
        public List<Category> List()
        {
            IEnumerable<Category> query = _dbContext // a category represents context of a single row 
                .Categories
                .OrderBy(item => item.CategoryName);
            return query.ToList(); //ToList is to execute the query and return the entity
        }

        public Dictionary<int, string> DictionaryOfSelectItem() //dictionary is collection of key value pairs. dicionary is like list and arrays but faster
        {               //int=key , string=value(CategoryName)
            var query = _dbContext
                .Categories
                .OrderBy(item => item.CategoryName)
                .Select(item => new { item.Id, item.CategoryName }); //select transform the object form one type to another
            return query.ToDictionary(item => item.Id, item => item.CategoryName);
        }

        public Category? GetById(int categoryId)
        {
            var query = _dbContext
                .Categories
                .Where(item => item.Id == categoryId);
            return query.FirstOrDefault();
        }

        public Category? FindByName(string categoryName)
        {
            var query = _dbContext
                .Categories
                .Where(item => item.CategoryName == categoryName);
            return query.FirstOrDefault();
        }

        public List<Category> FindByPariialDescription(string partialDescription) // to search for something with partial description
        {
            var query = _dbContext
                .Categories
                .Where(item => item.Description.Contains(partialDescription));
            return query.ToList();
        }

        public int AddCategory(Category newCategory)
        {
            bool exists = _dbContext.Categories.Any(categories => categories.CategoryName == categories.CategoryName);
            if (exists)
            {
                throw new Exception("The Category name already exists");
            }
            _dbContext.Categories.Add(newCategory);
            _dbContext.SaveChanges();
            return newCategory.Id;
        }
    }
}
