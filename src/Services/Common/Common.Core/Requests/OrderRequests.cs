using System.ComponentModel.DataAnnotations;

namespace Common.Core.Requests
{
    public class OrderRequest
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
