using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.BusinessModels;
using System.Threading.Tasks;

namespace NorthWnd.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserOperations _userOperations;

        public UsersController(IUserOperations userOperations)
        {
            _userOperations = userOperations;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                await _userOperations.Login(model, HttpContext);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                await _userOperations.Register(model, HttpContext);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userOperations.Logout(HttpContext);
            return Ok();
        }


        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var result = _userOperations.GetAll();
            return Ok(result);
        }

        [Authorize(Roles =("Admin"))]
        [HttpGet("{id}")]
        public IActionResult GetUser([FromRoute] int id)
        {
            var result = _userOperations.Get(id);
            return Ok(result);
        }

        [Authorize(Roles =("Admin"))]
        [HttpDelete("{id}")]
        public IActionResult RemoveUser([FromRoute] int id)
        {
            _userOperations.Remowe(id);
            return Ok();
        }


        [Authorize(Roles =("Admin"))]
        [HttpPost("addadmin")]
        public IActionResult Add([FromBody] UserViewModel user)
        {
            var res = _userOperations.Add(user);
            return Created("", res);
        }


        [Authorize(Roles =("Admin"))]
        [HttpPut]
        public IActionResult Edit([FromBody] UserViewModel user)
        {
            var res = _userOperations.Edit(user);
            return Ok(res);

        }

    }
}
