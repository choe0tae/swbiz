using Bizentro.Swbiz.DAL.Models;
using Bizentro.Swbiz.DAL.Models.Login;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;

namespace Bizentro.BlazorApp.Swbiz.Services
{
    public class SwbizAuthStateProvider : AuthenticationStateProvider
    {
        private CurrentUser _currentUser;
        public CurrentUser CurrentUser { get => _currentUser;  }
        //public override Task<AuthenticationState> GetAuthenticationStateAsync()
        //{
        //    //var identity = new ClaimsIdentity(new[]
        //    //{
        //    //    new Claim(ClaimTypes.Name, "mrfibuli"),
        //    //    }, "Fake authentication type");
        //    var identity = new ClaimsIdentity();

        //    var user = new ClaimsPrincipal(identity);

        //    return Task.FromResult(new AuthenticationState(user));
        //}
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var userInfo = await GetCurrentUser();
                if (userInfo.IsAuthenticated)
                {
                    //var claims = new[] { new Claim(ClaimTypes.Name, _currentUser.UserName) }.Concat(_currentUser.Claims.Select(c => new Claim(c.Key, c.Value)));
                    identity = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, _currentUser.UserName),
                        }, "Users");
                    //identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        private async Task<CurrentUser> GetCurrentUser()
        {
            if (_currentUser != null && _currentUser.IsAuthenticated) return _currentUser;
            _currentUser = new CurrentUser
            {
                IsAuthenticated = false, // User.Identity.IsAuthenticated,
                UserName = "Guest", // User.Identity.Name,
                Claims = null //User.Claims.ToDictionary(c => c.Type, c => c.Value)
            };
            await Task.Delay(100);
            return _currentUser;
        }

        public async Task Logout()
        {
            //await api.Logout();
            await Task.Delay(100);
            _currentUser = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task<bool> Login(LoginRequest loginParameters)
        {
            bool result = false;
            //await api.Login(loginParameters);
            await Task.Delay(100);
            if (loginParameters.UserName.Equals("wonho.choe"))
            {
                _currentUser = new CurrentUser
                {
                    IsAuthenticated = true, // User.Identity.IsAuthenticated,
                    UserName = loginParameters.UserName, // User.Identity.Name,
                    Claims = null //User.Claims.ToDictionary(c => c.Type, c => c.Value)
                };

                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
                result = true;
            }

            return result;
        }
    }
}
