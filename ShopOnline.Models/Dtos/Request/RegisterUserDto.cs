using System.ComponentModel.DataAnnotations;
using ShopOnline.Model.Enums;

namespace ShopOnline.Models.Dtos
{
	public class RegisterUserDto:LoginUserDto
	{
        [Required]
        public required string Name { get; set; }

        [Required, Compare(nameof(Password)), DataType(DataType.Password)]
        public required string ConfirmPassword { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public required string UserName { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}