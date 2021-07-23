using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Core
{
    public class InternetArticleEntity : MaterialEntity
    {
        [Required(ErrorMessage = "Не указана дата публикации")]
        [Display(Name = "Год публикации")]
        public DateTime DateOfPublication { get; set; }
        [Required(ErrorMessage = "Не указаны вики")]
        [Display(Name = "Вики")]
        public string Wiki { get; set; }
        public InternetArticleEntity(string materialName, DateTime DateOfPublication, string Wiki, int CreatedByUserId)
        {
            CreatedUserId = CreatedByUserId;
            Name = materialName;
            this.DateOfPublication = DateOfPublication;
            this.Wiki = Wiki;
        }
        public InternetArticleEntity()
        {
        }
    }
}