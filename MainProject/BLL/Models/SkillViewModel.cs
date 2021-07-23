using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.BLL.Models
{
    public class SkillViewModel
    {
            [Required(ErrorMessage = "Не указан название")]
            [Display(Name = "Название")]
            public string Name { get; set; }
    }
}
