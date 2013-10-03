using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempHire.DomainModel
{
    [Table("StaffingResource")]
    public class StaffingResourceEdit : AuditEntityBase
    {
        /// <summary>Gets or sets the Id. </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the FirstName. </summary>
        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        /// <summary>Gets or sets the MiddleName. </summary>
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        /// <summary>Gets or sets the LastName. </summary>
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(25)]
        public string LastName { get; set; }

        /// <summary>Gets or sets the Summary. </summary>
        [Required]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }
    }
}