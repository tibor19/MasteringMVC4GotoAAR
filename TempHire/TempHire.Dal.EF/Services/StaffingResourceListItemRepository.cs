using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TempHire.DomainModel;
using TempHire.DomainModel.Projections;
using TempHire.DomainModel.Services;

namespace TempHire.Dal.EF.Services
{
    public class StaffingResourceListItemRepository : Repository<StaffingResource>, IStaffingResourceListItemRepository
    {
        public StaffingResourceListItemRepository(DbContext context) : base(context)
        {
        }

        private class TempObject
        {
            public StaffingResource StaffingResource { get; set; }
            public Address PrimaryAddress { get; set; }
            public PhoneNumber PrimaryPhoneNumber { get; set; }
        }

        public new IQueryable<object> All()
        {
            var temp = base.All()
                       .Select(x => new TempObject()
                           {
                               StaffingResource = x,
                               PrimaryAddress = x.Addresses.FirstOrDefault(a => a.Primary),
                               PrimaryPhoneNumber = x.PhoneNumbers.FirstOrDefault(p => p.Primary)
                           });
            return temp.Select<IEnumerable< TempObject >, IQueryable< StaffingResourceListItem >> (x => new StaffingResourceListItem()
                           {
                               x.StaffingResource.Id,
                               FullName =
                                        !(x.StaffingResource.MiddleName == null ||
                                          x.StaffingResource.MiddleName.Trim() == string.Empty)
                                            ? x.StaffingResource.FirstName.Trim() + " " +
                                              x.StaffingResource.MiddleName.Trim() +
                                              " " + x.StaffingResource.LastName.Trim()
                                            : x.StaffingResource.FirstName.Trim() + " " +
                                              x.StaffingResource.LastName.Trim(),
                               x.PrimaryAddress.Address1,
                               x.PrimaryAddress.Address2,
                               x.PrimaryAddress.City,
                               State = x.PrimaryAddress.State.ShortName,
                               x.PrimaryAddress.Zipcode,
                               PhoneNumber = "(" + x.PrimaryPhoneNumber.AreaCode + ") " + x.PrimaryPhoneNumber.Number
                           });
        }

        //object IStaffingResourceListItemRepository.GetById(object key)
        //{
        //    return null;
        //}

        //StaffingResource IRepository<StaffingResource>.GetById(object key)
        //{
        //    return Context.Set<StaffingResource>().Find(key);
        //}
    }
}