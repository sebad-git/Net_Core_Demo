using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersService.Model {
    public class DummyDatabase {

        private static DummyDatabase instance;
        public static DummyDatabase Instance { 
            get { 
                if (instance == null) { instance = new DummyDatabase(); } return instance; 
            }
        }

        private List<User> users;
        private DummyDatabase() { users = new List<User>();  }

        public User CreateUser(string userName, string password) {
            if (users.Exists(us => us.UserName.Equals(userName) && us.Password.Equals(password))) {
                throw new Exception(string.Format("User [{0}] already exists."));
            }
            User newUser = new User(userName, password);
            users.Add(newUser);
            return newUser;
        }

        public User GetUser(string userName,string password) {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userName)) { return null; }
            return users.Find(us=> us.UserName.Equals(userName) && us.Password.Equals(password) );
        }
        
    }
}
