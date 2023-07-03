using Librería.Data.Properties;
using Librería.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Librería.Data
{
    public class VentaDetalle
    {
        public List<Entidades.VentaDetalle> Listar()
        {
            List<Entidades.VentaDetalle> lista = new List<Entidades.VentaDetalle>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select cd.IdVentaDetalle, cd.IdVenta, c.NroDocumento, cd.IdArticulo, a.DescripcionArticulo, cd.Cantidad, cd.Precio, cd.Importe, cd.IdEstado, e.NombreEstado from VentaDetalle cd join Venta c on cd.IdVenta = c.IdVenta join Articulo a on cd.IdArticulo = a.IdArticulo join Estado e on cd.IdEstado = e.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new Entidades.VentaDetalle()
                            {
                                IdVentaDetalle = Convert.ToInt32(Dr["IdVentaDetalle"]),
                                oVenta = new Entidades.Venta()
                                {
                                    IdVenta = Convert.ToInt32(Dr["IdVenta"]),
                                    NroDocumento = Dr["NroDocumento"].ToString()
                                },
                                oArticulo = new Entidades.Articulo()
                                {
                                    IdArticulo = Convert.ToInt32(Dr["IdArticulo"]),
                                    DescripcionArticulo = Dr["DescripcionArticulo"].ToString()
                                },
                                Cantidad = Convert.ToInt32(Dr["Cantidad"]),
                                Precio = Convert.ToDecimal(Dr["Precio"]),
                                Importe = Convert.ToDecimal(Dr["Importe"]),
                                oEstado = new Entidades.Estado()
                                {
                                    IdEstado = Convert.ToInt32(Dr["IdEstado"]),
                                    NombreEstado = Dr["NombreEstado"].ToString()
                                }
                            });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Entidades.VentaDetalle>();
            }

            return lista;
        }

        public int Registrar(Entidades.VentaDetalle obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_VentaDetalle_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdVenta", obj.oVenta.IdVenta);
                    Cmd.Parameters.AddWithValue("IdArticulo", obj.oArticulo.IdArticulo);
                    Cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
                    Cmd.Parameters.AddWithValue("Precio", obj.Precio);
                    Cmd.Parameters.AddWithValue("Importe", obj.Importe);
                    Cmd.Parameters.AddWithValue("IdEstado", obj.oEstado.IdEstado);
                    Cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    Cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cnx.Open();
                    Cmd.ExecuteNonQuery();

                    IdAutogenerado = Convert.ToInt32(Cmd.Parameters["Resultado"].Value);
                    Mensaje = Cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                IdAutogenerado = 0;
                Mensaje = ex.Message;
            }
            return IdAutogenerado;
        }

        public bool Editar(Entidades.VentaDetalle obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_VentaDetalle_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdVentaDetalle", obj.IdVentaDetalle);
                    Cmd.Parameters.AddWithValue("IdVenta", obj.oVenta.IdVenta);
                    Cmd.Parameters.AddWithValue("IdArticulo", obj.oArticulo.IdArticulo);
                    Cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
                    Cmd.Parameters.AddWithValue("Precio", obj.Precio);
                    Cmd.Parameters.AddWithValue("Importe", obj.Importe);
                    Cmd.Parameters.AddWithValue("IdEstado", obj.oEstado.IdEstado);
                    Cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    Cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cnx.Open();
                    Cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(Cmd.Parameters["Resultado"].Value);
                    Mensaje = Cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_VentaDetalle_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("IdVentaDetalle", id);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cnx.Open();
                    resultado = Cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }
    }
}