﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeteorologyStationApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MeteorologyStationEntities : DbContext
    {
        public MeteorologyStationEntities()
            : base("name=MeteorologyStationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<data> data { get; set; }
        public virtual DbSet<devices> devices { get; set; }
        public virtual DbSet<members> members { get; set; }
        public virtual DbSet<regions> regions { get; set; }
    }
}
