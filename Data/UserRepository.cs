using Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{
    public class UserRepository : IUserRepository
    {
        List<UserEntity> allUsers = new List<UserEntity>();
        List<UserEntity> logginedUsers = new List<UserEntity>();
        private readonly string defaultPathRegisteredUsers = "Registered Users.txt";
        private readonly string defaultPathLogginedUsers = "Loggined User.txt";
        public List<UserEntity> ShowUsers()
        {
            var userList = File.ReadAllText("Registered Users.txt").Split(',').ToList().Where(x => !String.IsNullOrWhiteSpace(x));

            var result = new List<UserEntity>();
            if (!File.Exists(defaultPathRegisteredUsers))
            {
                File.Create(defaultPathRegisteredUsers).Close();
            }
            string jsonString;
            jsonString = File.ReadAllText(defaultPathRegisteredUsers);
            if (jsonString != "")
            {
                result.AddRange(JsonSerializer.Deserialize<List<UserEntity>>(jsonString));
            }
            return result;
        }
        public bool UserRegistration(UserEntity user)
        {
            var userList = ShowUsers();
            userList.Add(user);
            string jsonString;
            jsonString = JsonSerializer.Serialize(userList.OfType<UserEntity>());
            File.WriteAllText(defaultPathRegisteredUsers, jsonString);
            return true;
        }
        public UserEntity UserAuthentication(string login, string password)
        {
            var userList = ShowUsers();

            var selectedUser = userList.Where(x => x.Login == login && x.Password == password).SingleOrDefault();
            if (selectedUser == null)
                return null;
            string jsonString;
            jsonString = JsonSerializer.Serialize(selectedUser);
            File.WriteAllText(defaultPathLogginedUsers, jsonString);
            return selectedUser;
        }
        public bool AddPassingCourse(UserEntity selectedUser)
        {
            var userList = ShowUsers();
            var NewUserList = userList.Where(x => x.Id != selectedUser.Id).Select(x => x).Append(selectedUser);
            string jsonString;
            jsonString = JsonSerializer.Serialize(NewUserList.OfType<UserEntity>());
            File.WriteAllText(defaultPathRegisteredUsers, jsonString);
            jsonString = JsonSerializer.Serialize(selectedUser);
            File.WriteAllText(defaultPathLogginedUsers, jsonString);
            return true;
        }
        public bool PassCourse(UserEntity selectedUser)
        {
            var userList = ShowUsers();
            var NewUserList = userList.Where(x => x.Id != selectedUser.Id).Select(x => x).Append(selectedUser);
            string jsonString;
            jsonString = JsonSerializer.Serialize(NewUserList.OfType<UserEntity>());
            File.WriteAllText(defaultPathRegisteredUsers, jsonString);
            jsonString = JsonSerializer.Serialize(selectedUser);
            File.WriteAllText(defaultPathLogginedUsers, jsonString);
            return true;
        }
        //public bool AddSkills(SkillEntity skill)
        //{
        //    skills.Add(skill);
        //    SaveList();
        //    return true;
        //}
    }
}
