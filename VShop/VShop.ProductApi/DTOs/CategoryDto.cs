using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }

        public ICollection<ProductDto>? Products { get; set; }
    }
}
