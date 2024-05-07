using System;
namespace ShopOnline.Models.Responses
{
	public record RegistrationResponse(bool Flag=false, string Message=null!);
	public record LoginResponse(bool Flag=false, string Message=null!, string JWTToken=null!);
}

