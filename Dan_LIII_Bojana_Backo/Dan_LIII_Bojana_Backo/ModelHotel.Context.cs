﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dan_LIII_Bojana_Backo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HotelDBEntities : DbContext
    {
        public HotelDBEntities()
            : base("name=HotelDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblEmployee> tblEmployees { get; set; }
        public virtual DbSet<tblManager> tblManagers { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<vwEmployee> vwEmployees { get; set; }
        public virtual DbSet<vwManager> vwManagers { get; set; }
    }
}
