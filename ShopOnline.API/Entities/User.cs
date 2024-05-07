using System;
using Microsoft.AspNetCore.Identity;
using ShopOnline.Model.Enums;

namespace ShopOnline.API.Entities
{
	public class User : IdentityUser
    {
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string Email { get; set; }
		public string Password { get; set; }
		public required string UserName { get; set; }

		public Role Role { get; set; }
	}
}

