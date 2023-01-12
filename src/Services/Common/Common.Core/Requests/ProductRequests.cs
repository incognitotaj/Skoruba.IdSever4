using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Common.Core.Requests
{
    public class ProductPostRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ProductBrandId { get; set; }
        public int ProductTypeId { get; set; }
        public IFormFile Image { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)] 
        public string PictureUrl { get; set; }
    }


    public class ProductRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }

    public class ProductSearchRequestFromTo
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }
    }

    public class ProductSearchRequestAll
    {
        [Required]
        public string Name { get; set; }
    }

    public class OrderSearchRequestAsOf
    {
        [Required]
        public string Customer { get; set; }

        [Required]
        public DateTime On { get; set; }
    }
}
