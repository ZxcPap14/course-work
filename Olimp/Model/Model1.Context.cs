﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Olimp.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OLIMPEntities1 : DbContext
    {
        public OLIMPEntities1()
            : base("name=OLIMPEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Certificates> Certificates { get; set; }
        public virtual DbSet<Olympiads> Olympiads { get; set; }
        public virtual DbSet<Participation> Participation { get; set; }
        public virtual DbSet<Protocol> Protocol { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Students> Students { get; set; }
    }
}
