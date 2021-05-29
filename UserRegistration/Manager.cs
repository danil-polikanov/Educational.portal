using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace EducationPortal
{
    class Manager
    {
        public void Manage()
        {
            UserRepository userRepository = new UserRepository();
            string command = null;
            while (command != "exit")
            {
                Console.WriteLine("нажмите 1 чтобы зарегистрироваться");
                Console.WriteLine("нажмите 2 чтобы залогиниться");
                Console.WriteLine("Чтоб выйти введите exit");
                command = Console.ReadLine();
                if (command == "1")
                {
                    Console.WriteLine("Введите Логин");
                    string login = Console.ReadLine();
                    Console.WriteLine("Введите пароль");
                    string password = Console.ReadLine();
                    var users = userRepository.UserRegistration(login, password);
                }
                if (command == "2")
                {
                    Console.WriteLine("Введите Логин");
                    string login = Console.ReadLine();
                    Console.WriteLine("Введите пароль");
                    string password = Console.ReadLine();
                    var user= userRepository.UserAuthentication(login, password);
                    break;
                }
            }
        }
    }
}
