using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NamelessApi.Domain;

namespace NamelessApi.Services
{
    public interface IUserService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string username, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);

    }
}
