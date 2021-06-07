using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class VideoResourceEntity:MaterialEntity
    {
        public TimeSpan Duration { get; set; }
        public string Quality { get; set; }
        public VideoResourceEntity(int userId,string materialName, TimeSpan Duration, string Quality)
        {
            this.UserId = userId;
            this.Id = counter;
            this.Name = materialName;
            this.Duration = Duration;
            this.Quality = Quality;
            counter++;
        }

        public VideoResourceEntity()
        {
        }
    }
}
