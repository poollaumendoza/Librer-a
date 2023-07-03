using System.Collections.ObjectModel;

namespace Librería.Entidades
{
    public class VentaDetalle
    {
        public int IdVentaDetalle { get; set; }
        public Venta oVenta { get; set; }
        public Articulo oArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
        public Estado oEstado { get; set; }
    }
}