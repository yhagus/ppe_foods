﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ppe_foods.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBFoodsEntities : DbContext
    {
        public DBFoodsEntities()
            : base("name=DBFoodsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Barang> Barangs { get; set; }
        public virtual DbSet<Karyawan> Karyawans { get; set; }
        public virtual DbSet<Pelanggan> Pelanggans { get; set; }
        public virtual DbSet<Penjualan> Penjualans { get; set; }
    }
}