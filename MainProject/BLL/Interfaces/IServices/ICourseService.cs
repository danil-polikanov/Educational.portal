using MainProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public interface ICourseService 
    {
        Task<bool> AddCourseAsync(CourseEntity entity, CancellationToken cancellationToken = default);
        Task<IEnumerable<CourseEntity>> GetCoursesAsync(Func<CourseEntity, bool> predicate,
         params Expression<Func<CourseEntity, object>>[] includeProperties);
        Task<IEnumerable<CourseEntity>> GetCoursesAsync(params Expression<Func<CourseEntity, object>>[] includeProperties);

        Task<bool> UpdateAsync(CourseEntity entity, CancellationToken cancellationToken = default);
    }
}
