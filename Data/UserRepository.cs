using Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserRepository
    {
        List<UserEntity> users = new List<UserEntity>();
        public List<UserEntity> ShowUsers()
        {
            return null;
        }
        public List<UserEntity> UserRegistration(string login, string password)
        {

            if (login == "Admin")
                throw new Exception("Login cant be Admin");
            if (users.Any(u => u.Login != null))
            {
                if (users.Any(u => u.Login == login))
                    throw new Exception("User with same name exists already.");
            }
            users.Add(new UserEntity(login, password));

            foreach (var a in users)
            {
                string temp = String.Join("~", a);
                if (temp == password)
                {
                    temp.Concat(",");
                }
                users.Append(a);
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var i in users)
            {
                stringBuilder.Append(i.Id + "~");
                stringBuilder.Append(i.Login + "~");
                stringBuilder.Append(i.Password + ",");
            }

            string filename = "Registered Users.txt";
            using (var file = new StreamWriter(filename))
            {
                file.Write(stringBuilder.ToString());
            }
            return users;
        }
        public UserEntity UserAuthentication(string login, string password)
        {
            var users = File.ReadAllText("Registered Users.txt").Split(',').ToList().Where(x => !String.IsNullOrWhiteSpace(x));

            List<UserEntity> myUsers = new List<UserEntity>();
            foreach (var user in users)
            {
                var information = user.Split('~');
                UserEntity temp = new UserEntity();
                temp.Id = int.Parse(information[0]);
                temp.Login = information[1].Trim();
                temp.Password = information[2].Trim();
                myUsers.Add(temp);
            }
            var selectedUser = myUsers.Where(x => x.Login == login && x.Password == password).SingleOrDefault();
            if (selectedUser != null)
                Console.WriteLine("Вы залогинились");
            else throw new Exception("Неверно введены данные или пользователя не существует");

            List<string> formatForFile = new List<string>();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(selectedUser.Id + "~");
            stringBuilder.Append(selectedUser.Login + "~");
            stringBuilder.Append(selectedUser.Password + ",");

            formatForFile.Add(stringBuilder.ToString());

            File.WriteAllLines("Loggined User.txt", formatForFile.ToArray());
            return selectedUser;
        }
    }
}
