using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;

namespace Client.Web.MVC.Areas.Admin.Models
{
    public class ProductUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int ProductBrandId { get; set; }
        public IEnumerable<SelectListItem> ProductBrands { get; set; }
        public int ProductTypeId { get; set; }
        public IEnumerable<SelectListItem>  ProductTypes { get; set; }
    }
}
