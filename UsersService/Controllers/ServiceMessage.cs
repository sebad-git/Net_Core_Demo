using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersService.Model {
    public class ServiceMessage {
        public string Message { get; set; }
        public int Code { get; set; }

        public ServiceMessage(){}
        public ServiceMessage(string message) { Message = message; }


    }
}
