//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PassQuestions.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class payment
    {
        public string id { get; set; }
        public string userid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Nullable<System.DateTime> paymentdate { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<System.DateTime> duedate { get; set; }
    
        public virtual useraccount useraccount { get; set; }
    }
}
