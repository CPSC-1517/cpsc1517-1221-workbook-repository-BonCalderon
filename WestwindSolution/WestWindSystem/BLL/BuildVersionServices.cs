using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.Entities;


namespace WestWindSystem.BLL
{
    public class BuildVersionServices
    {
        // Step 1: Define a readonly data field for the custom DbContext type
        private readonly WestwindContext _dbContext;

        // Step 2: Setup constructor for dependency injection for the custom DbContext type
        internal BuildVersionServices(WestwindContext context)
        {
            _dbContext = context;
        }

        // Step 3: Define methods to query and save instances of the entity
        public BuildVersion GetBuildVersion()
        {
            var query = _dbContext.BuildVersions;

            return query.FirstOrDefault()!;
        }
    }
}
