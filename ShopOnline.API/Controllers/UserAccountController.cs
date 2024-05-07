using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Repositories.Contracts;
using ShopOnline.Models.Dtos;
using ShopOnline.Models.Responses;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccount userAccount;

        public UserAccountController(IUserAccount userAccount)
        {
            this.userAccount = userAccount;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegisterUserDto userDto)
        {
            var result = await userAccount.RegisterUserAsync(userDto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginUserAsync(LoginUserDto loginUser)
        {
            var result = await userAccount.LoginUserAsync(loginUser);
            return Ok(result);
        }

    }
}

