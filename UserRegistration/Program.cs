
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;


namespace UserRegistration
{

    class Program
    {

        static void Main(string[] args)
        {
            Type personType = typeof(User);
            User user1 = new User(1, "dany", "123");
            User user2 = new User(2, "qwerty", "432");
            User user3 = new User(3, "Sany", "555");
            List<User> Tempusers = new List<User>();
            Tempusers.Add(user1);
            Tempusers.Add(user2);
            Tempusers.Add(user3);
            //foreach (var a in Tempusers)
            //{
            //    string temp = a.PrepareForFile();
            //    Tempusers.Append(a);
            //}
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var i in Tempusers)
            {
                
                stringBuilder.Append(i.Id+ "~");
                stringBuilder.Append(i.Login+"~");
                stringBuilder.Append(i.Password+",");
            }

            string filename = "default.txt";
            using (var file = new StreamWriter(filename))
            {
                file.Write(stringBuilder.ToString());
            }





            var users = File.ReadAllText("default.txt").Split(',').ToList().Where(x => !String.IsNullOrWhiteSpace(x));

            List<User> myUsers = new List<User>();
            foreach (var user in users)
            {
                var information = user.Split('~');
                User temp = new User();
                temp.Id = int.Parse(information[0]);
                temp.Login = information[1].Trim();
                temp.Password = information[2].Trim();
                myUsers.Add(temp);
            }

            Console.WriteLine("Введите логин");
            string log = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string pas = Console.ReadLine();
            var selectedUser = myUsers.Where(x => x.Login == log).SingleOrDefault();
            if(selectedUser!=null)
               Console.WriteLine("Вы залогинились");
            else Console.WriteLine("Неверно введены данные или пользователя не существует");
            myUsers.Remove(selectedUser);
            selectedUser.Password = pas;
            myUsers.Add(selectedUser);

            List<string> formatForFile = new List<string>();
            foreach (var item in myUsers)
            {
                formatForFile.Add(item.PrepareForFile());
            }
            File.WriteAllLines("default.txt", formatForFile.ToArray());
        }
        public class User
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            List<User> users2;
            public User(int Id, string Login, string Password)
            {
                this.Id = Id;
               this.Login = Login;
                this.Password = Password;
            }

            public User()
            {
            }

            public string PrepareForFile()
            {
                return Id + "~" + Login + "~" + Password + ",";
            }

            public void EnterDataUser()
            {
                Console.WriteLine("Введите имя: ");
                Id = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите возраст: ");
                Login = Console.ReadLine();
                Console.WriteLine("Введите пароль: ");
                Password = Console.ReadLine();
            }
        }
       
    }
}