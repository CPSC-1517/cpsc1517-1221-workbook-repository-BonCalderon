using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestwindSystem.Entities;
using WestWindSystem.DAL;

namespace WestWindSystem.BLL
{
    public class SupplierServices
    {
        private readonly WestwindContext _dbContext;

        internal SupplierServices (WestwindContext context)
        {
            _dbContext = context;
        }

        public List<Supplier> List()
        {
            var query = _dbContext
                .Suppliers
                .OrderBy(currenSupplier => currenSupplier.CompanyName)
                .ThenBy(currentSupplier => currentSupplier.ContactName); //sorted orderby Comany name Then by contactname ascendingly
            return query.ToList();
        }


    }
}
