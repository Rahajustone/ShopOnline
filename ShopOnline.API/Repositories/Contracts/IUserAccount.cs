using System;
using ShopOnline.Models.Dtos;
using ShopOnline.Models.Responses;

namespace ShopOnline.API.Repositories.Contracts
{
	public interface IUserAccount
	{
		Task<RegistrationResponse> RegisterUserAsync(RegisterUserDto userDto);
		Task<LoginResponse> LoginUserAsync(LoginUserDto userDto);
    }
}

