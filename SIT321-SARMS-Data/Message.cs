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
    
    public partial class Message
    {
        public int MessageID { get; set; }
        public int AlertID { get; set; }
        public System.DateTime DateTime { get; set; }
        public bool StudentSender { get; set; }
        public bool LecturerSender { get; set; }
        public string MessageBody { get; set; }
    
        public virtual Alert Alert { get; set; }
    }
}