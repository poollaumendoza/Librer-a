using Librería.Data.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Data
{
    public class MiInventario
    {
        Entidades.Compra eCompra = new Entidades.Compra();
        string Cn = Settings.Default.CadenaConexion;
        SqlConnection Cnx = null;
        SqlCommand Cmd = null;
        SqlDataAdapter Da = null;
        DataTable Dt = new DataTable();
        List<Entidades.MiInventario> oLista = new List<Entidades.MiInventario>();

        public List<Entidades.MiInventario> ListaProductos(bool existencia)
        {
            Dt.Columns.Clear();
            Dt.Rows.Clear();
            oLista.Clear();

            Cmd = new SqlCommand("dbo.sp_MiInventario_Existencia", new SqlConnection(Cn));
            Cmd.Parameters.AddWithValue("@valor", existencia);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            var query = (from a in Dt.Rows.Cast<DataRow>()
                         select a).ToList();

            foreach (var item in query)
            {
                oLista.Add(new Entidades.MiInventario()
                {
                    CodigoArticulo = item[0].ToString(),
                    RazonSocial = item[1].ToString(),
                    DescripcionArticulo = item[2].ToString(),
                    Inicial = Convert.ToInt32(item[3].ToString()),
                    Ingreso = Convert.ToInt32(item[4].ToString()),
                    Salida = Convert.ToInt32(item[5].ToString()),
                    Existencia = Convert.ToInt32(item[6].ToString()),
                });
            }

            return oLista;
        }
    }
}