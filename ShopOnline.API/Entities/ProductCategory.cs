using System;
namespace ShopOnline.API.Entities
{
	public class ProductCategory
    {
		public int Id { get; set; }
        public required string Name { get; set; }
        public string? IconCSS { get; set; }
        
    }
}

