using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NorthWnd.CORE.Abstractions;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;
using NorthWnd.CORE.Entities;
using NorthWnd.CORE.Enum;
using NorthWnd.CORE.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NorthWnd.BLL.Operations
{
    public class UserOperations : IUserOperations
    {

        private readonly IRepositoryManager _repositories;
        private readonly ILogger<UserOperations> logger;
        public UserOperations(IRepositoryManager repositories, ILogger<UserOperations> _logger)
        {
            logger = _logger;
            _repositories = repositories;
        }


        
        public UserViewModel Get(int id)
        {
            logger.LogInformation("UserOperation --- Get method started");

            var res = _repositories.Users.Get(id) ?? throw new LogicException("wrong User Id");

            logger.LogInformation("UserOperation --- Get method finished");

            return new UserViewModel
            {
                Id = res.Id,
                Email = res.Email,
                Password = res.Password,
                Role=res.Role
            };
        }


        
        public IEnumerable<UserViewModel> GetAll()
        {
            logger.LogInformation("UserOperation --- GetAll method started");

            var data = _repositories.Users.GetAll();
            var result = data.Select(x => new UserViewModel
            {
                Email = x.Email,
                Id = x.Id,
                Password = x.Password,
                Role=x.Role
            });
            logger.LogInformation("UserOperation --- Get method finished");

            return result;
        }


        
        public User Add(UserViewModel user)
        {
            logger.LogInformation("UserOperation --- Add method started");

            User us = new User
            {
                Email = user.Email,
                Id = user.Id,
                Password = user.Password,
                Role=Role.Admin
            };
            _repositories.Users.Add(us);
            _repositories.SaveChanges();

            logger.LogInformation("UserOperation --- Add method finished");

            return us;
        }


       
        public User Edit(UserViewModel user)
        {
            logger.LogInformation("UserOperation --- Edit method started");

            User user1 = new User
            {
                Id = user.Id,

            };
            if (user.Email != null && user.Password != null)
            {
                user1.Email = user.Email;
                user1.Password = user.Password;
                user1.Role = user.Role;
            }
            _repositories.Users.Update(user1);
            _repositories.SaveChanges();

            logger.LogInformation("UserOperation --- Edit method finished");

            return user1;
        }



        
        public void Remowe(int id)
        {
            logger.LogInformation("UserOperation ---Remove method started");

            var res = _repositories.Users.Get(id);
            _repositories.Users.Remove(res);
            _repositories.SaveChanges();

            logger.LogInformation("UserOperation --- Remove method finished");
        }


        
        public async Task Login(LoginModel model, HttpContext context)
        {
            logger.LogInformation("UserOperation --- Login method started");

            User user = _repositories.Users.GetSingle(u => u.Email == model.Email && u.Password == model.Password)
                ?? throw new LogicException("Wrong username or password");

            await Authenticate(user, context);

            logger.LogInformation("UserOperation --- Login method finished");
        }


        
        public async Task Logout(HttpContext context)
        {
            logger.LogInformation("UserOperation --- Logout method started");

            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            logger.LogInformation("UserOperation --- Logout method finished");
        }


        public async Task Register(RegisterModel model, HttpContext context)
        {
            logger.LogInformation("UserOperation --- Register method started");

            User user = _repositories.Users.GetSingle(u => u.Email == model.Email);
            if (user == null)
            {
                user = new User
                {
                    Email = model.Email,
                    Password = model.Password,
                    Role = Role.User
                };
                _repositories.Users.Add(user);
                await _repositories.SaveChangesAsync();

                await Authenticate(user, context);
            }
            else
            {
                throw new LogicException("User already exists");
            }

            logger.LogInformation("UserOperation --- Register method finished");
        }



        private async Task Authenticate(User user, HttpContext context)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,user.Role.ToString())
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}
