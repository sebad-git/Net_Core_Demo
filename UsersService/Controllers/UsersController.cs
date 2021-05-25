using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersService.Model;

namespace UsersService.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase {

        private readonly ILogger<UsersController> _logger;
        public UsersController(ILogger<UsersController> logger) { _logger = logger; }

        [HttpGet("")]
        public IEnumerable<string> Get() { yield return "Service Ready"; }

        [HttpGet("newUser/{userName}/{password}")]
        public IEnumerable<string> CreateUser(string userName, string password) {
            string serviceMessage="";
            try {
                User user = DummyDatabase.Instance.CreateUser(userName, password);
                serviceMessage = "User Created Successfully";
            }
            catch (Exception e) { serviceMessage = e.Message.ToString(); }
            yield return serviceMessage;
        }

        [HttpGet("login/{userName}/{password}")]
        public IEnumerable<string> Login(string userName, string password) {
            User user = DummyDatabase.Instance.GetUser(userName, password);
            if(user==null) { yield return "Login failed."; }
            yield return string.Format("Welcome: {0}",user.UserName);
        }

    }
}
