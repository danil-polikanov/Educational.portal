using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class InternetArticleEntity : MaterialEntity
    {
        public DateTime DateOfPublication { get; set; }
        public string Wiki { get; set; }
        public InternetArticleEntity(int userId, string materialName, DateTime DateOfPublication, string Wiki)
        {
            this.UserId = userId;
            this.Id = counter;
            this.Name = materialName;
            this.DateOfPublication = DateOfPublication;
            this.Wiki = Wiki;
            counter++;
        }

        public InternetArticleEntity()
        {
        }
    }
}