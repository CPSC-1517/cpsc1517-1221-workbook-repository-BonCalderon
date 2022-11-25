using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestwindSystem.Entities;

namespace WestWindSystem.Entities
{
    [Table(name:"Products")]
    public class Product
    {
        [Key]
        [Column("ProductID")]
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public string QuantityPerUnit { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public int UnitsOnOrder { get; set; }

        public bool Discontinued { get; set; }

        public int SupplierId { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!; // connects to category entity and allows you to navigate into category, would still work without this property.

        public virtual Supplier Supplier { get; set; } = null!; //connects to supplier entity and allows you to navigate into supplier
    }
}
