using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.BLL.Models
{
    public class CourseVIewModel
    {
        [Required(ErrorMessage = "Не указан name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Не указан materials")]
        public string[] Materials { get; set; }
        [Required(ErrorMessage = "Не указан skills")]
        public string[] Skills { get; set; }
        [Required(ErrorMessage = "Не указан skills")]
        public string RequirmentLevel { get; set; }
    }
}
