﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class ProductServices
    {
        private readonly WestwindContext _dbContext;

        internal ProductServices(WestwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> FindProductsByCategoryId(int categoryId)
        {
            var query = _dbContext
                .Products
                .Where(currentProduct => currentProduct.CategoryId == categoryId);
            return query.ToList();
        }

        public List<Product> FindProductsByProductName(string partialProductName)
        {
            var query = _dbContext
                .Products
                .Where(currentProduct => currentProduct.ProductName.Contains(partialProductName));
            return query.ToList();
        }

        public int AddProduct (Product newProduct)
        {
            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();
            return newProduct.ProductName;
        }
    }
}
