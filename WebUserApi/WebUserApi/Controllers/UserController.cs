using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebuUserApi.DB;

namespace WebuUserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult GetUser()
        {
            List<User> users;
            using (var dbcontext = new DB1SlackContext())
            {
                users = dbcontext.Users.ToList();
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Getid([FromRoute] int id)
        {
            User users;
            using (var dbContext = new DB1SlackContext())
            {
                users = dbContext.Users.Find(id);
            }
            return Ok(users);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (var dbContext = new DB1SlackContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
            return Created("",user);
        }

        [HttpPut]
        public IActionResult EditUser([FromBody] User user)
        {
            using (var dbContext=new DB1SlackContext())
            {
                var usertoedit = dbContext.Users.Find(user.Id);
                if (usertoedit==null)
                {
                    return BadRequest();
                }
                usertoedit.Name = user.Name;
                usertoedit.Messages = user.Messages;
                usertoedit.Participants = user.Participants;
                dbContext.Users.Update(usertoedit);
                dbContext.SaveChanges();
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveUser([FromRoute]int id)
        {
            using (var dbContext=new DB1SlackContext())
            {
                var user = dbContext.Users.Find(id);
                if (user==null)
                {
                    return BadRequest();
                }
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
                return Ok(user);
            }
        }

    }
}
