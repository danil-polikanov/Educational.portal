
using ProjectRefactoring.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRefactoring.Entities;

namespace ProjectRefactoring.EF
{
    public class UserContext : System.Data.Entity.DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Course> Orders { get; set; }
        public DbSet<CreatedCourse> createdCourses { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<PassingCourse> PassingCourses { get; set; }

        static UserContext()
        {
            Database.SetInitializer<UserContext>(new StoreDbInitializer());
        }
        public UserContext(string connectionString)
            : base(connectionString)
        {
        }
        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<UserContext>
        {
            protected override void Seed(UserContext db)
            {
                db.SaveChanges();
            }
        }
    }
}
