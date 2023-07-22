using System.ComponentModel.DataAnnotations;

namespace Infra_Mart.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public long UserCartId { get; set; }
        public int ProductCartId { get; set; }
    }
}
