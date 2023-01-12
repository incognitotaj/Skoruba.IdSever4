using Microsoft.AspNetCore.Http;
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
}
