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
    
    public partial class BuildingStatus
    {
        public BuildingStatus()
        {
            this.Buildings = new HashSet<Building>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Building> Buildings { get; set; }
    }
}
