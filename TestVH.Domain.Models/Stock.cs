using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVH.Domain.Models
{
    class Stock
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("productId")]
        public int? ProductId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("Stocks")]
        public virtual Product? Product { get; set; }
    }
}
