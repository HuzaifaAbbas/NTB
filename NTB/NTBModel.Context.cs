﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NTBEntities : DbContext
    {
        public NTBEntities()
            : base("name=NTBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<BuildingStatus> BuildingStatuses { get; set; }
        public virtual DbSet<BuildingType> BuildingTypes { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<FloorType> FloorTypes { get; set; }
        public virtual DbSet<LandHistory> LandHistories { get; set; }
        public virtual DbSet<Land> Lands { get; set; }
        public virtual DbSet<LandStatus> LandStatuses { get; set; }
        public virtual DbSet<PaymentMode> PaymentModes { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SalesStatus> SalesStatuses { get; set; }
        public virtual DbSet<StampDutyRegistration> StampDutyRegistrations { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
