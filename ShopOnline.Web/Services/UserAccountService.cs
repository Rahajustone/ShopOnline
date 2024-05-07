using System;
using System.Net.Http.Json;
using ShopOnline.Models.Dtos;
using ShopOnline.Models.Responses;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Services
{
	public class UserAccountService: IUserAccountService
    {
        private readonly HttpClient httpClient;

        public UserAccountService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<RegistrationResponse> RegisterAsync(RegisterUserDto userDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<RegisterUserDto>("api/UserAccount/login", userDto);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return default(RegistrationResponse);

                    return await response.Content.ReadFromJsonAsync<RegistrationResponse>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message-{message}");
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        public async Task<LoginResponse> LoginAsync(LoginUserDto userDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<LoginUserDto>("api/UserAccount/login", userDto);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return default(LoginResponse);

                    return await response.Content.ReadFromJsonAsync<LoginResponse>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message-{message}");
                }
            }
            catch (Exception)
            {
                throw;

            }
        }
    }
}

