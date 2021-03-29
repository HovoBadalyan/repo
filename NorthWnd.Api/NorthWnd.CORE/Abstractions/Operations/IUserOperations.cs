using Microsoft.AspNetCore.Http;
using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthWnd.CORE.Abstractions.Operations
{
    public interface IUserOperations
    {
        Task Logout(HttpContext context);
        Task Register(RegisterModel model, HttpContext context);
        Task Login(LoginModel model, HttpContext context);
        IEnumerable<UserViewModel> GetAll();
        UserViewModel Get(int id);
        void Remowe(int id);
        User Add(UserViewModel user);
        User Edit(UserViewModel user);

    }
}
