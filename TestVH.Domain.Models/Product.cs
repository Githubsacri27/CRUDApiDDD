using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVH.Domain.Models
{
    class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [StringLength(255)]
        public string? Name { get; set; }

        [Column("price", TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Column("categoryId")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Products")]
        public virtual Category? Category { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

        [InverseProperty("Product")]
        public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    }
}
