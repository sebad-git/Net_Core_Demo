using System;

namespace UsersService.Model {
    public class User {
        public string UserName { get; protected set; }
        public string Password { get; protected set; }

        public User() { }
        public User(string userName,string password) { UserName = userName; Password = password; }

    }
}
