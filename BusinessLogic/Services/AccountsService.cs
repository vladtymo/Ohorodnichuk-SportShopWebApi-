using BusinessLogic.ApiModels.Accounts;
using BusinessLogic.Exceptions;
using BusinessLogic.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using System.Resources;
using Core.Resources;
using Core.Interfaces;
using Core.ApiModels.Accounts;

namespace BusinessLogic.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IJwtService jwtService;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AccountsService(SignInManager<User> signInManager, UserManager<User> userManager, IJwtService jwtService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.jwtService = jwtService;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest model)
        {
            var user = await userManager.FindByNameAsync(model.Email);
            if (user == null || !await userManager.CheckPasswordAsync(user, model.Password)) 
            {
                throw new HttpException(ExceptionMessages.AccountBadRequest, HttpStatusCode.BadRequest);
            }
            await signInManager.SignInAsync(user, true);

            return new()
            {
                Token = jwtService.CreateToken(jwtService.GetClaims(user))
            };
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task RegisterAsync(RegisterRequest model)
        {
            var user = new User()
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                BirthDate = model.BirthDate
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if(!result.Succeeded)
            {
                var message = String.Join(", ", result.Errors.Select(x => x.Description));
                throw new HttpException(ExceptionMessages.AccountBadRequest, HttpStatusCode.BadRequest);
            }
        }
    }
}
