using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVH.Domain.Models
{
    class Buyer
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [StringLength(255)]
        public string? Name { get; set; }

        [Required]
        [Column("mail")]
        [StringLength(255)]
        public string? Mail { get; set; }

        [InverseProperty("Buyer")]
        public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
