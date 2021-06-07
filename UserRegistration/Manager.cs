using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Reflection;
using System.Collections;
using BL;

namespace EducationPortal
{
    class Manager
    {
        public void Manage()
        { 
            SkillRepository skillRepository = new SkillRepository();
            SkillService skillService = new SkillService(skillRepository);
            MaterialsRepository materialsRepository = new MaterialsRepository();
            MaterialService materialsService = new MaterialService(materialsRepository);
            CourseRepository courseRepository = new CourseRepository();
            CourseService courseService = new CourseService(courseRepository, materialsRepository,skillRepository);
            UserRepository userRepository = new UserRepository();
            UserService userService = new UserService(userRepository, courseRepository, materialsRepository, skillRepository);

            string command = null;
            UserEntity user = new UserEntity();
            Console.WriteLine("нажмите 1 чтобы зарегистрироваться");
            Console.WriteLine("нажмите 2 чтобы залогиниться");
            Console.WriteLine("нажмите 3 показать пользователей");
            Console.WriteLine("Чтоб выйти введите exit");
            while (command != "exit")
            {
                Console.WriteLine("Введите команду");
                command = Console.ReadLine();
                if (command == "1")
                {
                    Console.WriteLine("Введите Логин");
                    string login = Console.ReadLine();
                    Console.WriteLine("Введите пароль");
                    string password = Console.ReadLine();
                    var registrationResult = userService.UserRegistration(login, password);
                    if (registrationResult) Console.WriteLine("Регистрация прошла успешно");
                    else Console.WriteLine("Регистрация неудалась");
                }
                if (command == "2")
                {
                    Console.WriteLine("Введите Логин");
                    string login = Console.ReadLine();
                    Console.WriteLine("Введите пароль");
                    string password = Console.ReadLine();
                    user = userService.UserAuthentication(login, password);
                    if (user != null)
                    {
                        Console.WriteLine("Вы залогинились");
                        break;
                    }
                    else Console.WriteLine("Неверно введены данные или пользователя не существует");
                }
                if (command == "3")
                {
                    var logins = userService.ShowUsers();
                    int x = 1;
                    foreach (var i in logins)
                    {
                        Console.WriteLine($"Пользователь:{x}\t" + i.Login);
                        x++;
                    }
                }

                //else Console.WriteLine("Введена неправильная команда");
                
            }
            Console.WriteLine("Чтоб выйти введите exit");
            string materialName = null;
            Console.WriteLine("Введите 1 чтобы добавить видеоматериал");
            Console.WriteLine("Введите 2 чтобы добавить интернет заметку");
            Console.WriteLine("Введите 3 чтобы добавить интернет публикацию");
            Console.WriteLine("Введите 4 чтобы добавить уменией");
            Console.WriteLine("Введите 5 чтобы добавить курс");
            Console.WriteLine("Введите 6 чтобы посмотреть список материалов");
            Console.WriteLine("Введите 7 чтобы посмотреть список курсов");
            Console.WriteLine("Введите 8 чтобы посмотреть список умений");
            Console.WriteLine("Введите 9 чтобы записаться на курс");
            Console.WriteLine("Введите 10 чтобы проходить курс");
            do
            {
                Console.WriteLine("Введите команду");
                command = Console.ReadLine();
                if (command == "1" || command == "2" || command == "3")
                {
                    Console.WriteLine("Введите имя материала");
                    materialName = Console.ReadLine();
                }
                if (command == "1")
                {
                    Console.WriteLine("Введите длительность видео в формате hh:mm:ss");
                    string duraction = Console.ReadLine();
                    Console.WriteLine("Введите качество фильма");
                    string quality = Console.ReadLine();
                    string[] properties = new string[] { materialName, duraction, quality };
                    var addingMaterialResult = materialsService.AddMaterial(user.Id, properties, "VideoResource");
                    if (addingMaterialResult == true)
                    {
                        Console.WriteLine("Материал успешно добавлен");
                    }
                    else Console.WriteLine("Неверно введены данные или такой материал уже существует");
                }
                if (command == "2")
                {
                    Console.WriteLine("Введите дату публикации заметки в формате yyyy:mm:dd");
                    string dateOfPublication = Console.ReadLine();
                    Console.WriteLine("Введите сайт заметки");
                    string wiki = Console.ReadLine();
                    string[] properties = new string[] { materialName, dateOfPublication, wiki };
                    var addingMaterialResult = materialsService.AddMaterial(user.Id, properties, "InternetArticle");
                    if (addingMaterialResult == true)
                    {
                        Console.WriteLine("Материал успешно добавлен");
                    }
                    else Console.WriteLine("Неверно введены данные или такой материал уже существует");
                }
                if (command == "3")
                {
                    Console.WriteLine("Введите имена авторов через запятую");
                    string authorsName = Console.ReadLine();
                    Console.WriteLine("Введите количество страниц");
                    string pageNumbers = Console.ReadLine();
                    Console.WriteLine("Введите формат документа");
                    string format = Console.ReadLine();
                    Console.WriteLine("Введите год публикации");
                    string yearOfPublication = Console.ReadLine();
                    string[] properties = new string[] { materialName, authorsName, pageNumbers, format, yearOfPublication };
                    var addingMaterialResult = materialsService.AddMaterial(user.Id, properties, "ElectronicPublication");
                    if (addingMaterialResult == true)
                    {
                        Console.WriteLine("Материал успешно добавлен");

                    }
                    else Console.WriteLine("Неверно введены данные или такой материал уже существует");
                }
                if (command == "4")
                {
                    Console.WriteLine("Введите название умения");
                    string skillName = Console.ReadLine();
                    var addingSkillResult = skillService.AddSkill(user.Id, skillName);
                    if (addingSkillResult == true)
                    {
                        Console.WriteLine("Умение успешно добавлено");                     
                    }
                    else Console.WriteLine("Неверно введены данные или такое умение уже существует");
                }
                if (command == "5")
                {
                    Console.WriteLine("Введите имя курса");
                    string courseName = Console.ReadLine();
                    Console.WriteLine("Введите описание для курса");
                    string description = Console.ReadLine();
                    Console.WriteLine("Введите названия материалов,которые хотите добавить через запятую");
                    string materialCourseName = Console.ReadLine();
                    Console.WriteLine("Введите название умений,а после : и уровень умений,которые хотите добавить через запятую");
                    string skillName = Console.ReadLine();
                    var addingCourseResult = courseService.AddCourse(user.Id, courseName, description, materialCourseName,skillName);
                    if (addingCourseResult == true)
                    {
                        Console.WriteLine("Курс успешно добавлен");

                    }
                    else Console.WriteLine("Неверно введены данные или такой курс уже существует");
                }
                if (command == "6")
                {
                    var materials = materialsService.ShowMaterials();
                    int x = 1;
                    foreach (var i in materials)
                    {
                        Console.WriteLine($"Материал:{x}\t" + i.Name);
                        x++;
                    }
                }
                if (command == "7")
                {
                    var courses = courseService.ShowCourses();
                    int x = 1;
                    foreach (var i in courses)
                    {
                        Console.WriteLine($"Курс:{x}\t" + i.Name);
                        x++;
                    }
                }
                if (command == "8")
                {
                    var skills = skillService.ShowSkills();
                    int x = 1;
                    foreach (var i in skills)
                    {
                        Console.WriteLine($"Умение:{x}\t" + i.Name);
                        x++;

                    }
                }
                if (command == "9")
                {
                    Console.WriteLine("Введите имя курса");
                    string userCourseName = Console.ReadLine();
                    var passingCourse = userService.AddPassingCourse(user.Id, userCourseName);
                    if (passingCourse == true)
                    {
                        Console.WriteLine("Курс для прохождения успешно добавлен");

                    }
                    else Console.WriteLine("Неверно введены данные");
                }
                if (command == "10")
                {
                    Console.WriteLine("Введите имя курса");
                    string userPassingCourseName = Console.ReadLine();
                    var selectedCourse = user.PassingCourse.Where(x => x.Name == userPassingCourseName).Where(x=>x.isComplete!=true).FirstOrDefault();
                    if (selectedCourse == null)
                    {
                        Console.WriteLine("Такого курса не существует или курс уже пройден");
                        break;
                    }
                    var coursedMaterials=selectedCourse.Materials;
                    foreach(var i in coursedMaterials)
                    {
                        if (user.FinishedMaterials.Select(x => x.Name == i.Name).Count() > 0)
                        {
                            Console.WriteLine("Материал курса уже пройден: " + i.Name);
                        }
                        else Console.WriteLine("Материал курса: " + i.Name);
                    }
                    Console.WriteLine("Введите имя материала курса,который хотите пройти");
                    var userPassingMaterialName = Console.ReadLine();
                    var userPassingMaterialId = coursedMaterials.Where(x => x.Name == userPassingMaterialName).FirstOrDefault();
                    var passingCourseResult = userService.PassCourse(user.Id,selectedCourse.Id, userPassingMaterialId.Id);
                    if (passingCourseResult == true)
                    {
                        Console.WriteLine("Материал курса пройден");

                    }
                    else Console.WriteLine("Неверно введены данные");
                }
            } while (command != "exit");
            Console.ReadKey();
        }
    }
}
