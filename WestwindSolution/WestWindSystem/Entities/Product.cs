using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.Entities
{
    [Table(name:"Products")]
    public class Product
    {
        [Key]
        [Column("ProductID")]
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        //[Column(TypeName="money")]
        public decimal UnitPrice { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
