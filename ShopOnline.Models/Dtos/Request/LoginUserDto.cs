using System;
using System.ComponentModel.DataAnnotations;
using ShopOnline.Model.Enums;

namespace ShopOnline.Models.Dtos
{
	public class LoginUserDto
    {
        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public required string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

