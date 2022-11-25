using Microsoft.EntityFrameworkCore;
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
            // Enforce business rule where CategoryName must be unique
            bool exists = _dbContext.Categories.Any(c => c.CategoryName == newCategory.CategoryName);
            if (exists)
            {
                throw new ArgumentException($"The Category Name {newCategory.CategoryName} already exists!");
            }

            _dbContext.Categories.Add(newCategory);
            _dbContext.SaveChanges();
            return newCategory.Id;
        }

        public int UpdateCategory(Category existingCategory)
        {
            _dbContext.Categories.Attach(existingCategory).State = EntityState.Modified;
            int rowsUpdated = _dbContext.SaveChanges();
            return rowsUpdated;
        }

        //public int DeleteCategory(int categoryID) //this is hard delete and will actually get rid of the data in the database
        //{
        //    Category existingCategory = _dbContext.Categories
        //        .Where(c => c.Id == categoryID)
        //        .Include(c => c.Products)
        //        .FirstOrDefault();

        //    if (existingCategory == null)
        //    {
        //        throw new ArgumentException($"CategoryID {categoryID} does not exists.");
        //    }
        //    int categoryProductCount = existingCategory.Products.Count();
        //    if (categoryProductCount > 0)
        //    {
        //        throw new Exception("This categories has products and cannot be deleted.");
        //    }

        //    _dbContext.Categories.Remove(existingCategory);
        //    int rowsDeleted = _dbContext.SaveChanges();
        //    return rowsDeleted;
        //}

        public List<Category> Category_List()
        {
            var query = _dbContext
                .Categories
                .OrderBy(item => item.CategoryName);

            return query.ToList();
        }

        public Dictionary<int, string> Dictionary()
        {
            var query = _dbContext
                .Categories
                .OrderBy(item => item.CategoryName)
                .Select(item => new { item.Id, item.CategoryName });
            return query.ToDictionary(item => item.Id, item => item.CategoryName);
        }

    }
}
