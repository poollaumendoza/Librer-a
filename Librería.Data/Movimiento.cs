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
    public class Movimiento
    {
        Entidades.Movimiento eMovimiento = new Entidades.Movimiento();
        MovimientoCollection listaMovimiento = new MovimientoCollection();
        string Cn = Settings.Default.CadenaConexion;
        SqlConnection Cnx = null;
        SqlCommand Cmd = null;

        public int AgregarMovimiento(Entidades.Movimiento eMovimiento)
        {
            int resultado = 0;

            Cnx = new SqlConnection(Cn);
            Cmd = new SqlCommand("dbo.sp_Movimiento_AgregarMovimiento", Cnx);
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter IdMovimiento = new SqlParameter();
            IdMovimiento.ParameterName = "@IdMovimiento";
            IdMovimiento.Direction = ParameterDirection.Output;
            IdMovimiento.SqlDbType = SqlDbType.Int;

            Cmd.Parameters.Add(IdMovimiento);
            Cmd.Parameters.AddWithValue("@IdEmpresa", eMovimiento.IdEmpresa);
            Cmd.Parameters.AddWithValue("@IdTipoMovimiento", eMovimiento.IdTipoMovimiento);
            Cmd.Parameters.AddWithValue("@IdUsuario", eMovimiento.IdUsuario);
            Cmd.Parameters.AddWithValue("@FechaMovimiento", eMovimiento.FechaMovimiento);
            Cmd.Parameters.AddWithValue("@IdEstado", eMovimiento.IdEstado);
            Cnx.Open();
            Cmd.ExecuteNonQuery();
            Cnx.Close();

            resultado = Convert.ToInt32(IdMovimiento.Value);

            return resultado;
        }
    }
}