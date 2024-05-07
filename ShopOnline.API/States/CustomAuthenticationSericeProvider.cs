using System;
using Microsoft.AspNetCore.Components.Authorization;

namespace ShopOnline.API.States
{
	public class CustomAuthenticationSericeProvider : AuthenticationStateProvider
	{
		public CustomAuthenticationSericeProvider()
		{
		}

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }
    }
}

