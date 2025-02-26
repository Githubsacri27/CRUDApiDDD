using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVH.Domain.Models
{
    class Purchase
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("buyerId")]
        public int? BuyerId { get; set; }

        [Column("productId")]
        public int? ProductId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [ForeignKey("BuyerId")]
        [InverseProperty("Purchases")]
        public virtual Buyer? Buyer { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("Purchases")]
        public virtual Product? Product { get; set; }
    }
}
