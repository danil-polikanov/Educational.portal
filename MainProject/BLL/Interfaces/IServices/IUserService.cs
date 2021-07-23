using MainProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.BLL.Interfaces.IServices
{
    public interface IUserService
    {
        public Task<IEnumerable<UserEntity>> GetUsersAsync(params Expression<Func<UserEntity, object>>[] includeProperties);
        public Task<IEnumerable<UserEntity>> GetUsersAsync(Func<UserEntity, bool> predicate, params Expression<Func<UserEntity, object>>[] includeProperties);
        public Task<bool> UserRegistration(UserEntity user, params Expression<Func<UserEntity, object>>[] includeProperties);
        //public Task<bool> AddPassingCourse(int userId, string name, CancellationToken cancellationToken = default);
    }
}
