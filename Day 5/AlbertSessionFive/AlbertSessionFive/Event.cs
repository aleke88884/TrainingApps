//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlbertSessionFive
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public int event_id { get; set; }
        public int location_id { get; set; }
        public string name { get; set; }
        public System.DateTime start { get; set; }
        public System.DateTime end { get; set; }
        public decimal price { get; set; }
        public int discount_percent { get; set; }
    
        public virtual Location Location { get; set; }
    }
}
