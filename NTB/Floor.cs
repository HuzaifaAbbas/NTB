//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NTB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Floor
    {
        public Floor()
        {
            this.Rooms = new HashSet<Room>();
        }
    
        public int Id { get; set; }
        public Nullable<int> FloorNo { get; set; }
        public Nullable<int> BuildingId { get; set; }
        public Nullable<int> FloorTypeId { get; set; }
    
        public virtual Building Building { get; set; }
        public virtual FloorType FloorType { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
