using Librería.Data.Properties;
using Librería.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Data
{
    public class MovimientoDetalle
    {
        Entidades.MovimientoDetalle eMovimientoDetalle = new Entidades.MovimientoDetalle();
        MovimientoDetalleCollection listaMovimientoDetalle = new MovimientoDetalleCollection();
        string Cn = Settings.Default.CadenaConexion;
        SqlConnection Cnx = null;
        SqlCommand Cmd = null;

        public void AgregarMovimientoDetalle(Entidades.MovimientoDetalle eMovimientoDetalle)
        {
            Cnx = new SqlConnection(Cn);
            Cmd = new SqlCommand("dbo.sp_MovimientoDetalle_AgregarMovimientoDetalle", Cnx);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@IdMovimiento", eMovimientoDetalle.IdMovimiento);
            Cmd.Parameters.AddWithValue("@IdArticulo", eMovimientoDetalle.IdArticulo);
            Cmd.Parameters.AddWithValue("@StockInicial", eMovimientoDetalle.StockInicial);
            Cmd.Parameters.AddWithValue("@Ingreso", eMovimientoDetalle.Ingreso);
            Cmd.Parameters.AddWithValue("@Salida", eMovimientoDetalle.Salida);
            Cmd.Parameters.AddWithValue("@IdEstado", eMovimientoDetalle.IdEstado);
            Cnx.Open();
            Cmd.ExecuteNonQuery();
            Cnx.Close();
        }
    }
}