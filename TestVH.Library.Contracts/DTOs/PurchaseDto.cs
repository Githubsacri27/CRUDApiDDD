using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVH.Library.Contracts.DTOs
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
