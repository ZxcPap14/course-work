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
    
    public partial class OLIMPEntities16 : DbContext
    {
        public OLIMPEntities16()
            : base("name=OLIMPEntities16")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Olympiads> Olympiads { get; set; }
        public virtual DbSet<Participation> Participation { get; set; }
        public virtual DbSet<Protocol> Protocol { get; set; }
        public virtual DbSet<Protocolss> Protocolss { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Certifikat> Certifikat { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Registrations_on_olimpiad> Registrations_on_olimpiad { get; set; }
    }
}
