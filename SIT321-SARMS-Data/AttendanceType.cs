//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIT321_SARMS_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class AttendanceType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AttendanceType()
        {
            this.Attendances = new HashSet<Attendance>();
        }
    
        public int AttendanceTypeID { get; set; }
        public string AttendanceTypeName { get; set; }
        public bool AttendanceTypeApproved { get; set; }
        public bool AttendanceTypeActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
