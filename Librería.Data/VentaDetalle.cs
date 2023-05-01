using Librería.Data.Properties;
using Librería.Entidades;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Librería.Data
{
    public class VentaDetalle
    {
        Entidades.VentaDetalle eVentaDetalle = new Entidades.VentaDetalle();
        VentaDetalleCollection listaVentaDetalle = new VentaDetalleCollection();
        string Cn = Settings.Default.CadenaConexion;
        SqlConnection Cnx = null;
        SqlCommand Cmd = null;
        SqlDataAdapter Da = null;
        DataTable Dt = new DataTable();

        public void AgregarVentaDetalle(Entidades.VentaDetalle eVentaDetalle)
        {
            Cnx = new SqlConnection(Cn);
            Cmd = new SqlCommand("dbo.sp_VentaDetalle_AgregarVentaDetalle", Cnx);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@IdVenta", eVentaDetalle.IdVenta);
            Cmd.Parameters.AddWithValue("@Cantidad", eVentaDetalle.Cantidad);
            Cmd.Parameters.AddWithValue("@Descripcion", eVentaDetalle.Descripcion);
            Cmd.Parameters.AddWithValue("@Precio", eVentaDetalle.Precio);
            Cmd.Parameters.AddWithValue("@Importe", eVentaDetalle.Importe);
            Cmd.Parameters.AddWithValue("@IdEstado", eVentaDetalle.IdEstado);
            Cnx.Open();
            Cmd.ExecuteNonQuery();
            Cnx.Close();
        }
        public void EliminarVentaDetalle(Entidades.VentaDetalle eVentaDetalle)
        {
            Cnx = new SqlConnection(Cn);
            Cmd = new SqlCommand("dbo.sp_VentaDetalle_EliminarVentaDetalle", Cnx);
            Cmd.Parameters.AddWithValue("@IdVentaDetalle", eVentaDetalle.IdVentaDetalle);
            Cnx.Open();
            Cmd.ExecuteNonQuery();
            Cnx.Close();
        }
        public void EditarVentaDetalle(Entidades.VentaDetalle eVentaDetalle)
        {
            Cnx = new SqlConnection(Cn);
            Cmd = new SqlCommand("dbo.sp_VentaDetalle_ActualizarVentaDetalle", Cnx);
            Cmd.Parameters.AddWithValue("@IdVentaDetalle", eVentaDetalle.IdVentaDetalle);
            Cmd.Parameters.AddWithValue("@IdVenta", eVentaDetalle.IdVenta);
            Cmd.Parameters.AddWithValue("@Cantidad", eVentaDetalle.Cantidad);
            Cmd.Parameters.AddWithValue("@Descripcion", eVentaDetalle.Descripcion);
            Cmd.Parameters.AddWithValue("@Precio", eVentaDetalle.Precio);
            Cmd.Parameters.AddWithValue("@Importe", eVentaDetalle.Importe);
            Cmd.Parameters.AddWithValue("@IdEstado", eVentaDetalle.IdEstado);
            Cnx.Open();
            Cmd.ExecuteNonQuery();
            Cnx.Close();
        }
        public ObservableCollection<Entidades.VentaDetalle> ListaVentaDetalle()
        {
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaVentaDetalle.Clear();

            Da = new SqlDataAdapter(new SqlCommand("dbo.sp_VentaDetalle_ObtenerVentaDetalle", new SqlConnection(Cn)));
            Da.Fill(Dt);

            var query = (from a in Dt.Rows.Cast<DataRow>()
                         select a).ToList();

            foreach (var item in query)
            {
                listaVentaDetalle.Add(new Entidades.VentaDetalle()
                {
                    IdVentaDetalle = Convert.ToInt32(item[0].ToString()),
                    IdVenta = Convert.ToInt32(item[1].ToString()),
                    Cantidad = Convert.ToInt32(item[2].ToString()),
                    Descripcion = item[3].ToString(),
                    Precio = Convert.ToDecimal(item[4].ToString()),
                    Importe = Convert.ToDecimal(item[5].ToString()),
                    IdEstado = Convert.ToInt32(item[6].ToString())
                });
            }
            return listaVentaDetalle;
        }

        public ObservableCollection<Entidades.VentaDetalle> ListaVentaDetalle(Entidades.VentaDetalle eVentaDetalle)
        {
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaVentaDetalle.Clear();

            if(eVentaDetalle.IdVentaDetalle != 0)
            {
                Cmd = new SqlCommand("dbo.sp_VentaDetalle_ObtenerVentaDetallePorIdVentaDetalle", new SqlConnection(Cn));
                Cmd.Parameters.AddWithValue("@IdVentaDetalle", eVentaDetalle.IdVentaDetalle);
                Cmd.CommandType = CommandType.StoredProcedure;
                Da = new SqlDataAdapter(Cmd);
                Da.Fill(Dt);

                var query = (from a in Dt.Rows.Cast<DataRow>()
                             select a).ToList();

                foreach (var item in query)
                {
                    listaVentaDetalle.Add(new Entidades.VentaDetalle()
                    {
                        IdVentaDetalle = Convert.ToInt32(item[0].ToString()),
                        IdVenta = Convert.ToInt32(item[1].ToString()),
                        Cantidad = Convert.ToInt32(item[2].ToString()),
                        Descripcion = item[3].ToString(),
                        Precio = Convert.ToDecimal(item[4].ToString()),
                        Importe = Convert.ToDecimal(item[5].ToString()),
                        IdEstado = Convert.ToInt32(item[6].ToString())
                    });
                }
            }
            if(eVentaDetalle.IdVenta != 0)
            {
                Cmd = new SqlCommand("dbo.sp_VentaDetalle_ObtenerVentaDetallePorIdVenta", new SqlConnection(Cn));
                Cmd.Parameters.AddWithValue("@IdVenta", eVentaDetalle.IdVenta);
                Cmd.CommandType = CommandType.StoredProcedure;
                Da = new SqlDataAdapter(Cmd);
                Da.Fill(Dt);

                var query = (from a in Dt.Rows.Cast<DataRow>()
                             select a).ToList();

                foreach (var item in query)
                {
                    listaVentaDetalle.Add(new Entidades.VentaDetalle()
                    {
                        IdVentaDetalle = Convert.ToInt32(item[0].ToString()),
                        IdVenta = Convert.ToInt32(item[1].ToString()),
                        Cantidad = Convert.ToInt32(item[2].ToString()),
                        Descripcion = item[3].ToString(),
                        Precio = Convert.ToDecimal(item[4].ToString()),
                        Importe = Convert.ToDecimal(item[5].ToString()),
                        IdEstado = Convert.ToInt32(item[6].ToString())
                    });
                }
            }
            return listaVentaDetalle;
        }
    }
}