//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class MovimientoDetalle
    {
        public int IdMovimientoDetalle { get; set; }
        public Nullable<int> IdMovimiento { get; set; }
        public Nullable<int> IdArticulo { get; set; }
        public Nullable<int> StockInicial { get; set; }
        public Nullable<int> Ingreso { get; set; }
        public Nullable<int> Salida { get; set; }
        public Nullable<int> StockActual { get; set; }
        public Nullable<int> IdEstado { get; set; }
    
        public virtual Articulo Articulo { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Movimiento Movimiento { get; set; }
    }
}
