using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public interface IUserRepository
    {
        public List<UserEntity> ShowUsers();
        public bool UserRegistration(UserEntity user);
        public UserEntity UserAuthentication(string login, string password);
        public bool AddPassingCourse(UserEntity user);
        public bool PassCourse(UserEntity selectedUser);
    }
}
