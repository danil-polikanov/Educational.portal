using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public interface IUserService
    {
        public List<UserEntity> ShowUsers();
        public bool UserRegistration(string login,string password);
        public UserEntity UserAuthentication(string login, string password);
        public bool AddPassingCourse(int userId, string name);
        public bool PassCourse(int userId,int courseId, int materialId);
    }
}
