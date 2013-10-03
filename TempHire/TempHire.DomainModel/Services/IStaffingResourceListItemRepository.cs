using System.Linq;
using TempHire.DomainModel.Projections;

namespace TempHire.DomainModel.Services
{
    public interface IStaffingResourceListItemRepository
    {
        IQueryable<object> All();
    }
}