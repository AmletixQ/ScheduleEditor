using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ScheduleEditor
{
    public static class UserManager
    {
        private const string UsersFilePath = "users.txt";

        public static bool Authenticate(string login ,  string password)
        {
            var users = LoadUsers();
            return users.Exists(u => u.Login == login && u.Password == password);
        }


        public static void AddUser(string login , string password)
        {
            var users = LoadUsers();
            users.Add(new User(login , password));
            SaveUsers(users);

        }
        

        private static List<User> LoadUsers()
        {
            var users = new List<User>();

            if (File.Exists(UsersFilePath)) 
            {
                var lines = File.ReadAllLines(UsersFilePath);
                foreach (var line in lines) 
                {
                    var parts = line.Split('|');

                    if (parts.Length == 2)
                    {
                        users.Add(new User(parts[0], parts[1]));
                    }
                }
            }

            return users;
        }

        private static void SaveUsers(List<User>  users)
        {
            var lines = new List<string>();
            foreach (var user in users) 
            {
                lines.Add($"{user.Login}|{user.Password}");
            }
            File.WriteAllLines(UsersFilePath , lines);
        }
    }
    
    public class User
    {
        public string Login { get;}
        public string Password { get;}

        public User(string login, string password)
        {
            Login = login; Password = password;
        }
    }
}
