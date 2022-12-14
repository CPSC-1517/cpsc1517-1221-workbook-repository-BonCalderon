using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WestwindSystem.Entities;
using WestWindSystem.Entities;

namespace WestWindSystem.DAL
{
    internal class WestwindContext : DbContext
    {
       
        public WestwindContext(DbContextOptions<WestwindContext> options) : base(options)//base is the constructor of DbContext
        {

        }
        //set no duplicates unlike arrays

        public DbSet<BuildVersion> BuildVersions => Set<BuildVersion>();

        public DbSet<Category> Categories => Set<Category>();

        public DbSet<Product> Products => Set<Product>();


        public DbSet<Region> Regions => Set<Region>();

        public DbSet<Supplier> Suppliers => Set<Supplier>();

        public DbSet<Territory> Territories => Set<Territory>();



    }
      
}
