using Domain.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class UserEntity : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        static public int counter = 1;

        public List<MaterialEntity> FinishedMaterials{ get; set; }
        public List<SkillEntity> UserSKills { get; set; }    
        public List<PassingCourse> PassingCourse { get; set; }
        public UserEntity()
        {

        }
        public UserEntity(string Login, string Password)
        {
            this.Id = counter;
            this.Login = Login;
            this.Password = Password;
            this.FinishedMaterials = new List<MaterialEntity>();
            this.PassingCourse = new List<PassingCourse>();
            this.UserSKills = new List<SkillEntity>();
            counter++;  
        }
        public UserEntity(string Login, string Password, List<MaterialEntity> passingMaterials, List<PassingCourse> passingCourse, List<SkillEntity> userSKills)
        {
            this.Id = counter;
            this.Login = Login;
            this.Password = Password;
            this.FinishedMaterials = passingMaterials;
            this.PassingCourse = passingCourse;
            this.UserSKills = userSKills;
            counter++;
        }
    }
}
