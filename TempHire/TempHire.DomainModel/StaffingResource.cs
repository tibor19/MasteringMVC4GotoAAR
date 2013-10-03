using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace TempHire.DomainModel
{
    [Table("StaffingResource")]
    public class StaffingResource : StaffingResourceEdit
    {
        /// <summary>Gets the Addresses. </summary>
        public ICollection<Address> Addresses { get; internal set; }

        /// <summary>Gets the PhoneNumbers. </summary>
        public ICollection<PhoneNumber> PhoneNumbers { get; internal set; }

        /// <summary>Gets the Rates. </summary>
        public ICollection<Rate> Rates { get; internal set; }

        /// <summary>Gets the WorkExperience. </summary>
        public ICollection<WorkExperienceItem> WorkExperience { get; internal set; }

        /// <summary>Gets the Skills. </summary>
        public ICollection<Skill> Skills { get; internal set; }

        /// <summary>Gets or sets the PrimaryAddress. </summary>
        [NotMapped]
        public Address PrimaryAddress
        {
            get { return Addresses != null ? Addresses.FirstOrDefault(a => a.Primary) : null; }
            set
            {
                if (value.StaffingResource != this)
                    throw new InvalidOperationException("Address is not associated with this StaffingResource.");

                Addresses.Where(a => a.Primary).ForEach(a => a.Primary = false);
                value.Primary = true;
            }
        }

        /// <summary>Gets or sets the PrimaryPhoneNumber. </summary>
        [NotMapped]
        public PhoneNumber PrimaryPhoneNumber
        {
            get { return PhoneNumbers != null ? PhoneNumbers.FirstOrDefault(a => a.Primary) : null; }
            set
            {
                if (value.StaffingResource != this)
                    throw new InvalidOperationException("PhoneNumber is not associated with this StaffingResource.");

                PhoneNumbers.Where(p => p.Primary).ForEach(p => p.Primary = false);
                value.Primary = true;
            }
        }
    }
}
