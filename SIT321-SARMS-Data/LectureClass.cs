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
    
    public partial class LectureClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LectureClass()
        {
            this.Attendances = new HashSet<Attendance>();
        }
    
        public int ClassID { get; set; }
        public string W1 { get; set; }
        public string W2 { get; set; }
        public string W3 { get; set; }
        public string W4 { get; set; }
        public string W5 { get; set; }
        public string W6 { get; set; }
        public string W7 { get; set; }
        public Nullable<int> L1 { get; set; }
        public Nullable<int> L2 { get; set; }
        public Nullable<int> L3 { get; set; }
        public Nullable<int> L4 { get; set; }
        public Nullable<int> L5 { get; set; }
        public Nullable<int> L6 { get; set; }
        public Nullable<int> L7 { get; set; }
        public Nullable<int> UnitID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
