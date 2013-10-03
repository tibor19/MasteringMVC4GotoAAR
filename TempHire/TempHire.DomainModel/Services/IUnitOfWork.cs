using System;
using System.Data.Entity;

namespace TempHire.DomainModel.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<StaffingResource> StaffingResources { get; }
        IRepository<Address> Addresses { get; }
        IRepository<AddressType> AddressTypes { get; }
        IRepository<PhoneNumber> PhoneNumbers { get; }
        IRepository<PhoneNumberType> PhoneNumberTypes { get; }
        IRepository<Rate> Rates { get; }
        IRepository<RateType> RateTypes { get; }
        IRepository<Skill> Skills { get; }
        IRepository<State> States { get; }

        DbContext Context{ get; }

        IRepository<WorkExperienceItem> WorkExperienceItems { get; }
        IStaffingResourceListItemRepository StaffingResourceListItems { get; }
        void Commit();
        void Dispose();
    }
}