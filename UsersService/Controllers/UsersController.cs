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
        public ServiceMessage Get() { return new ServiceMessage("Service Ready"); }

        [HttpPost("create")]
        public ServiceMessage CreateUserPost([FromBody] User newUser) {
            try {
                User user = DummyDatabase.Instance.CreateUser(newUser.UserName, newUser.Password);
                return new ServiceMessage(String.Format("User {0} Created Successfully.",user.UserName));
            }
            catch (Exception e) { return new ServiceMessage(e.Message.ToString()); }
        }

        [HttpGet("login/{userName}/{password}")]
        public ServiceMessage Login(string userName, string password) {
            ServiceMessage serviceMessage = new ServiceMessage();
            User user = DummyDatabase.Instance.GetUser(userName, password);
            if (user == null) { serviceMessage.Message = "Login failed."; return serviceMessage; }
            serviceMessage.Message = string.Format("Welcome: {0}", user.UserName);
            return serviceMessage;
        }

        /*
         [HttpPost("test")]
        public async Task<ActionResult<ServiceResponse>> Method([FromBody] Data data) {
            
        }
         */

    }
}
