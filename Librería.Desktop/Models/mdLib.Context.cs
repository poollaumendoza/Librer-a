﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Librería.Desktop.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbLibEntities : DbContext
    {
        public DbLibEntities()
            : base("name=DbLibEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Almacen> Almacen { get; set; }
        public virtual DbSet<Articulo> Articulo { get; set; }
        public virtual DbSet<ClasificacionTipoDocumento> ClasificacionTipoDocumento { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<CompraDetalle> CompraDetalle { get; set; }
        public virtual DbSet<Correlativo> Correlativo { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Entidad> Entidad { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Movimiento> Movimiento { get; set; }
        public virtual DbSet<MovimientoDetalle> MovimientoDetalle { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoMovimiento> TipoMovimiento { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<VentaDetalle> VentaDetalle { get; set; }
    }
}
