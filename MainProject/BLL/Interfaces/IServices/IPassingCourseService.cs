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
    public interface IPassingCourseService
    {
        Task<IEnumerable<PassingCourse>> GetCoursesAsync(Func<PassingCourse, bool> predicate,
         params Expression<Func<PassingCourse, object>>[] includeProperties);
        Task<IEnumerable<PassingCourse>> GetCoursesAsync(params Expression<Func<PassingCourse, object>>[] includeProperties);

        Task<bool> UpdateAsync(PassingCourse entity, CancellationToken cancellationToken = default);
        Task<bool> AddPassingCourse(CourseEntity entity, UserEntity user, CancellationToken cancellationToken = default);
        Task<bool> PassCourse(PassingCourse entity,UserEntity user,int materialId, CancellationToken cancellationToken = default);

    }
}
