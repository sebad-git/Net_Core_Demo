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

        [HttpGet("newUser/{userName}/{password}")]
        public ServiceMessage CreateUser(string userName, string password) {
            try {
                User user = DummyDatabase.Instance.CreateUser(userName, password);
                return new ServiceMessage("User Created Successfully");
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

    }
}
