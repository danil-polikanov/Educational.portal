using Domain.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class CourseEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
