using BusinessLogic.ApiModels.Accounts;
using Core.ApiModels.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAccountsService
    {
        Task RegisterAsync(RegisterRequest model);
        Task<LoginResponse> LoginAsync(LoginRequest model);
        Task LogoutAsync();
    }
}
