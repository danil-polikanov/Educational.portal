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

      static int counter = 1;
        public UserEntity()
        {

        }
        public UserEntity(string Login,string Password)
        {
            this.Id = counter;
            this.Login = Login;
            this.Password = Password;
            counter++;
        }
    }
}
