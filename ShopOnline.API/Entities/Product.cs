using System;
namespace ShopOnline.API.Entities
{
	public class Product
	{
		public int Id { get; set; }
        public required string Name { get; set; }
		public string? Description { get; set; }
		public required string ImageURL { get; set; }
		public int Price { get; set; }
		public int Qty { get; set; }
		public int CategoryId { get; set; }
    }
}

