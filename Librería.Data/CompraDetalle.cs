using Librería.Data.Properties;
using Librería.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Librería.Data
{
    public class CompraDetalle
    {
        Entidades.CompraDetalle eCompraDetalle = new Entidades.CompraDetalle();
        CompraDetalleCollection listaCompraDetalle = new CompraDetalleCollection();
        string Cn = Settings.Default.CadenaConexion;
        SqlConnection Cnx = null;
        SqlCommand Cmd = null;
        SqlDataAdapter Da = null;
        DataTable Dt = new DataTable();

        public void AgregarCompraDetalle(Entidades.CompraDetalle eCompraDetalle)
        {
            Cnx = new SqlConnection(Cn);
            Cmd = new SqlCommand("dbo.sp_CompraDetalle_AgregarCompraDetalle", Cnx);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@IdCompra", eCompraDetalle.IdCompra);
            Cmd.Parameters.AddWithValue("@Cantidad", eCompraDetalle.Cantidad);
            Cmd.Parameters.AddWithValue("@Descripcion", eCompraDetalle.Descripcion);
            Cmd.Parameters.AddWithValue("@Precio", eCompraDetalle.Precio);
            Cmd.Parameters.AddWithValue("@Importe", eCompraDetalle.Importe);
            Cmd.Parameters.AddWithValue("@IdEstado", eCompraDetalle.IdEstado);
            Cnx.Open();
            Cmd.ExecuteNonQuery();
            Cnx.Close();
        }
        public void EliminarCompraDetalle(Entidades.CompraDetalle eCompraDetalle)
        {
            Cnx = new SqlConnection(Cn);
            Cmd = new SqlCommand("dbo.sp_CompraDetalle_EliminarCompraDetalle", Cnx);
            Cmd.Parameters.AddWithValue("@IdCompraDetalle", eCompraDetalle.IdCompraDetalle);
            Cnx.Open();
            Cmd.ExecuteNonQuery();
            Cnx.Close();
        }
        public void EditarCompraDetalle(Entidades.CompraDetalle eCompraDetalle)
        {
            Cnx = new SqlConnection(Cn);
            Cmd = new SqlCommand("dbo.sp_CompraDetalle_ActualizarCompraDetalle", Cnx);
            Cmd.Parameters.AddWithValue("@IdCompraDetalle", eCompraDetalle.IdCompraDetalle);
            Cmd.Parameters.AddWithValue("@IdCompra", eCompraDetalle.IdCompra);
            Cmd.Parameters.AddWithValue("@Cantidad", eCompraDetalle.Cantidad);
            Cmd.Parameters.AddWithValue("@Descripcion", eCompraDetalle.Descripcion);
            Cmd.Parameters.AddWithValue("@Precio", eCompraDetalle.Precio);
            Cmd.Parameters.AddWithValue("@Importe", eCompraDetalle.Importe);
            Cmd.Parameters.AddWithValue("@IdEstado", eCompraDetalle.IdEstado);
            Cnx.Open();
            Cmd.ExecuteNonQuery();
            Cnx.Close();
        }
        public ObservableCollection<Entidades.CompraDetalle> ListaCompraDetalle()
        {
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaCompraDetalle.Clear();

            Da = new SqlDataAdapter(new SqlCommand("dbo.sp_CompraDetalle_ObtenerCompraDetalle", new SqlConnection(Cn)));
            Da.Fill(Dt);

            var query = (from a in Dt.Rows.Cast<DataRow>()
                         select a).ToList();

            foreach (var item in query)
            {
                listaCompraDetalle.Add(new Entidades.CompraDetalle()
                {
                    IdCompraDetalle = Convert.ToInt32(item[0].ToString()),
                    IdCompra = Convert.ToInt32(item[1].ToString()),
                    Cantidad = Convert.ToInt32(item[2].ToString()),
                    Descripcion = item[3].ToString(),
                    Precio = Convert.ToDecimal(item[4].ToString()),
                    Importe = Convert.ToDecimal(item[5].ToString()),
                    IdEstado = Convert.ToInt32(item[6].ToString())
                });
            }
            return listaCompraDetalle;
        }
        public List<Entidades.CompraDetalle> ListaCompraDetalle(string nombreObjeto, string valor)
        {
            List<Entidades.CompraDetalle> oLista = new List<Entidades.CompraDetalle>();

            switch (nombreObjeto)
            {
                case "IdCompraDetalle":
                    Cmd = new SqlCommand("dbo.sp_CompraDetalle_ObtenerPorIdCompraDetalle", new SqlConnection(Cn));
                    Cmd.Parameters.AddWithValue("@IdCompraDetalle", valor);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Da = new SqlDataAdapter(Cmd);
                    Da.Fill(Dt);

                    var q1 = (from a in Dt.Rows.Cast<DataRow>()
                              select a).ToList();

                    foreach (var item in q1)
                    {
                        oLista.Add(new Entidades.CompraDetalle()
                        {
                            IdCompraDetalle = Convert.ToInt32(item[0].ToString()),
                            IdCompra = Convert.ToInt32(item[1].ToString()),
                            Cantidad = Convert.ToInt32(item[2].ToString()),
                            Descripcion = item[3].ToString(),
                            Precio = Convert.ToDecimal(item[4].ToString()),
                            Importe = Convert.ToDecimal(item[5].ToString()),
                            IdEstado = Convert.ToInt32(item[6].ToString())
                        });
                    }
                    break;
                case "IdCompra":
                    Cmd = new SqlCommand("dbo.sp_CompraDetalle_ObtenerCompraDetallePorIdCompra", new SqlConnection(Cn));
                    Cmd.Parameters.AddWithValue("@IdCompra", valor);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Da = new SqlDataAdapter(Cmd);
                    Da.Fill(Dt);

                    var q2 = (from a in Dt.Rows.Cast<DataRow>()
                              select a).ToList();

                    foreach (var item in q2)
                    {
                        oLista.Add(new Entidades.CompraDetalle()
                        {
                            IdCompraDetalle = Convert.ToInt32(item[0].ToString()),
                            IdCompra = Convert.ToInt32(item[1].ToString()),
                            Cantidad = Convert.ToInt32(item[2].ToString()),
                            Descripcion = item[3].ToString(),
                            Precio = Convert.ToDecimal(item[4].ToString()),
                            Importe = Convert.ToDecimal(item[5].ToString()),
                            IdEstado = Convert.ToInt32(item[6].ToString())
                        });
                    }
                    break;
            }
            return oLista;
        }
        public ObservableCollection<Entidades.CompraDetalle> ListaCompraDetalle(Entidades.CompraDetalle eCompraDetalle)
        {
            listaCompraDetalle.Clear();

            if (eCompraDetalle.IdCompraDetalle != 0)
            {
                Cmd = new SqlCommand("dbo.sp_CompraDetalle_ObtenerCompraDetallePorIdCompraDetalle", new SqlConnection(Cn));
                Cmd.Parameters.AddWithValue("@IdCompraDetalle", eCompraDetalle.IdCompraDetalle);
                Cmd.CommandType = CommandType.StoredProcedure;
                Da = new SqlDataAdapter(Cmd);
                Da.Fill(Dt);

                var q1 = (from a in Dt.Rows.Cast<DataRow>()
                          select a).ToList();

                foreach (var item in q1)
                {
                    listaCompraDetalle.Add(new Entidades.CompraDetalle()
                    {
                        IdCompraDetalle = Convert.ToInt32(item[0].ToString()),
                        IdCompra = Convert.ToInt32(item[1].ToString()),
                        Cantidad = Convert.ToInt32(item[2].ToString()),
                        Descripcion = item[3].ToString(),
                        Precio = Convert.ToDecimal(item[4].ToString()),
                        Importe = Convert.ToDecimal(item[5].ToString()),
                        IdEstado = Convert.ToInt32(item[6].ToString())
                    });
                }
            }
            if (eCompraDetalle.IdCompra != 0)
            {
                Cmd = new SqlCommand("dbo.sp_CompraDetalle_ObtenerCompraDetallePorIdCompra", new SqlConnection(Cn));
                Cmd.Parameters.AddWithValue("@IdCompra", eCompraDetalle.IdCompra);
                Cmd.CommandType = CommandType.StoredProcedure;
                Da = new SqlDataAdapter(Cmd);
                Da.Fill(Dt);

                var q2 = (from a in Dt.Rows.Cast<DataRow>()
                          select a).ToList();

                foreach (var item in q2)
                {
                    listaCompraDetalle.Add(new Entidades.CompraDetalle()
                    {
                        IdCompraDetalle = Convert.ToInt32(item[0].ToString()),
                        IdCompra = Convert.ToInt32(item[1].ToString()),
                        Cantidad = Convert.ToInt32(item[2].ToString()),
                        Descripcion = item[3].ToString(),
                        Precio = Convert.ToDecimal(item[4].ToString()),
                        Importe = Convert.ToDecimal(item[5].ToString()),
                        IdEstado = Convert.ToInt32(item[6].ToString())
                    });
                }
            }
            return listaCompraDetalle;
        }
    }
}