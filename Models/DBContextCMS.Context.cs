﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomerManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBCustomerManagementSystemEntities : DbContext
    {
        public DBCustomerManagementSystemEntities()
            : base("name=DBCustomerManagementSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAgent> tblAgent { get; set; }
        public virtual DbSet<tblClient> tblClient { get; set; }
        public virtual DbSet<tblSource> tblSource { get; set; }
        public virtual DbSet<tblStatus> tblStatus { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
