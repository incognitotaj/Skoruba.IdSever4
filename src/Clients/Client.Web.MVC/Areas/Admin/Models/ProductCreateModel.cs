using Microsoft.AspNetCore.Mvc.Rendering;

namespace Client.Web.MVC.Areas.Admin.Models
{
    public class ProductCreateModel
    {
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
