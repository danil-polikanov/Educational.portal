using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRefactoring.Entities;

namespace ProjectRefactoring.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Course> Courses { get; }
        IRepository<Material> Materials { get; }
        IRepository<Skill> Skills { get; }
        IRepository<CreatedCourse> CreatedCourses { get; }
        IRepository<PassingCourse> PassingCourses { get; }

        void Save();
    }

}
