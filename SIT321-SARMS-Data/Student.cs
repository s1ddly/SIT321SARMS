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
    
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.Attendances = new HashSet<Attendance>();
            this.Alerts = new HashSet<Alert>();
        }
    
        public int ID { get; set; }
        public string UID { get; set; }
        public string Pword { get; set; }
        public string Role { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Lec1 { get; set; }
        public string Lec2 { get; set; }
        public string Lec3 { get; set; }
        public string Lec4 { get; set; }
        public string Lec5 { get; set; }
        public string Lec6 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alert> Alerts { get; set; }
    }
}
