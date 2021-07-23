using MainProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MainProject.BLL.Interfaces.IServices
{
    public interface ISkillService
    {
        Task<bool> AddSkillAsync(SkillEntity entity, CancellationToken cancellationToken = default);
        Task<IEnumerable<SkillEntity>> GetSkills(Func<SkillEntity, bool> predicate,
         params Expression<Func<SkillEntity, object>>[] includeProperties);
        Task<IEnumerable<SkillEntity>> GetSkills(params Expression<Func<SkillEntity, object>>[] includeProperties);

        Task<bool> UpdateAsync(SkillEntity entity, CancellationToken cancellationToken = default);
    }
}
