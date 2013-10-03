using System;
using Breeze.WebApi;
using Breeze.WebApi.EF;
using Newtonsoft.Json.Linq;
using TempHire.DomainModel;
using TempHire.DomainModel.Services;

namespace TempHire.Dal.EF.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TempHireDbContext _context;

        public UnitOfWork()
        {
            _context = new TempHireDbContext();

            StaffingResources = new Repository<StaffingResource>(_context);
            Addresses = new Repository<Address>(_context);
            AddressTypes = new Repository<AddressType>(_context);
            PhoneNumbers = new Repository<PhoneNumber>(_context);
            PhoneNumberTypes = new Repository<PhoneNumberType>(_context);
            Rates = new Repository<Rate>(_context);
            RateTypes = new Repository<RateType>(_context);
            Skills = new Repository<Skill>(_context);
            States = new Repository<State>(_context);
            WorkExperienceItems = new Repository<WorkExperienceItem>(_context);

            // StaffingResourceListItems = new StaffingResourceListItemRepository(_context);
        }

        public IRepository<StaffingResource> StaffingResources { get; private set; }
        public IRepository<Address> Addresses { get; private set; }
        public IRepository<AddressType> AddressTypes { get; private set; }
        public IRepository<PhoneNumber> PhoneNumbers { get; private set; }
        public IRepository<PhoneNumberType> PhoneNumberTypes { get; private set; }
        public IRepository<Rate> Rates { get; private set; }
        public IRepository<RateType> RateTypes { get; private set; }
        public IRepository<Skill> Skills { get; private set; }
        public IRepository<State> States { get; private set; }
        public IRepository<WorkExperienceItem> WorkExperienceItems { get; private set; }

        public IStaffingResourceListItemRepository StaffingResourceListItems { get; private set; }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}