using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Domain.IRepository;
using MainProject.BLL.Interfaces.IServices;
using MainProject.Core;

namespace MainProject.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<PassingCourse> _passingCourseRepository;

        public UserService(IRepository<UserEntity> userRepository, IRepository<PassingCourse> passingCourseRepository)
        {
            _userRepository = userRepository;
            _passingCourseRepository = passingCourseRepository;

        }
        public async virtual Task<bool> UserRegistration(UserEntity entity, params Expression<Func<UserEntity, object>>[] includeProperties)
        {
            entity.RoleId = 2;
            return await _userRepository.AddAsync(entity);
        }
        public async virtual Task<IEnumerable<UserEntity>> GetUsersAsync(Func<UserEntity, bool> predicate,
            params Expression<Func<UserEntity, object>>[] includeProperties)
        {
            return await _userRepository.GetWithIncludeAsync(predicate,includeProperties);
        }

        public async virtual Task<IEnumerable<UserEntity>> GetUsersAsync(params Expression<Func<UserEntity, object>>[] includeProperties)
        {
            return await _userRepository.GetWithIncludeAsync(includeProperties);
        }

    }

}
