using System;
using System.Collections.Generic;
using Domain.Entity;

namespace BL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public List<UserEntity> UserRegistration(string login,string password)
        {
            return _userRepository.UserRegistration(login,password);
            
        }
        public UserEntity UserAuthentication(string login, string password)
        {
            return _userRepository.UserAuthentication(login, password);
        }
        public List<UserEntity> ShowUsers()
        {
            return null;
        }
    }

}
