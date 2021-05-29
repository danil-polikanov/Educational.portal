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
        public List<UserEntity> UserRegistration(string login, string password);
        public UserEntity UserAuthentication(string login, string password);
    }
}
