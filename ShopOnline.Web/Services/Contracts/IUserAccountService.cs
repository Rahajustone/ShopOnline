using System;
using ShopOnline.Models.Dtos;
using ShopOnline.Models.Responses;

namespace ShopOnline.Web.Services.Contracts
{
	public interface IUserAccountService
	{
		Task<RegistrationResponse> RegisterAsync(RegisterUserDto userDto);
		Task<LoginResponse> LoginAsync(LoginUserDto userDto);
    }
}

