using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Core
{
    public class VideoResourceEntity : MaterialEntity
    {
        [Required(ErrorMessage = "Не указана продолжительность")]
        [Display(Name = "Продолжительность")]
        public TimeSpan Duration { get; set; }
        [Required(ErrorMessage = "Не указано качество сьемки")]
        [Display(Name = "Качество")]
        public string Quality { get; set; }
        public VideoResourceEntity(string materialName, TimeSpan Duration, string Quality, int CreatedByUserId)
        {
            CreatedUserId = CreatedByUserId;
            Name = materialName;
            this.Duration = Duration;
            this.Quality = Quality;
        }
        public VideoResourceEntity()
        {
        }
    }
}
