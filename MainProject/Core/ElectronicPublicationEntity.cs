using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Core
{
    public class ElectronicPublicationEntity : MaterialEntity
    {
        [Required(ErrorMessage = "Не указаны авторы")]
        [Display(Name = "Авторы")]
        public string Authors { get; set; }
        [Required(ErrorMessage = "Не указаны страницы")]
        [Display(Name = "Страницы")]
        public int NumberOfPages { get; set; }
        [Required(ErrorMessage = "Не указан формат")]
        [Display(Name = "Формат")]
        public string Format { get; set; }
        [Required(ErrorMessage = "Не указан год публикации")]
        [Display(Name = "Год публикации")]
        public int YearOfPublishing { get; set; }
        public ElectronicPublicationEntity(string materialName, string Authors, int NumberOfPages, string Format, int YearOfPublishing, int CreatedByUserId)
        {
            CreatedUserId = CreatedByUserId;
            Name = materialName;
            this.Authors = Authors;
            this.NumberOfPages = NumberOfPages;
            this.Format = Format;
            this.YearOfPublishing = YearOfPublishing;
        }

        public ElectronicPublicationEntity()
        {
        }
    }
}
