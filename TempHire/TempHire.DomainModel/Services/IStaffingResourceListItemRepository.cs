using System.Linq;
using TempHire.DomainModel.Projections;

namespace TempHire.DomainModel.Services
{
    public interface IStaffingResourceListItemRepository : IRepository<object>
    {
        // IQueryable<object> All();
    }
}