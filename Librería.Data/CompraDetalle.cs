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
    public class CompraDetalle
    {
        public List<Entidades.CompraDetalle> Listar()
        {
            List<Entidades.CompraDetalle> lista = new List<Entidades.CompraDetalle>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select cd.IdCompraDetalle, cd.IdCompra, c.NroDocumento, cd.IdArticulo, a.DescripcionArticulo, cd.Cantidad, cd.Precio, cd.Importe, cd.IdEstado, e.NombreEstado from CompraDetalle cd join Compra c on cd.IdCompra = c.IdCompra join Articulo a on cd.IdArticulo = a.IdArticulo join Estado e on cd.IdEstado = e.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new Entidades.CompraDetalle()
                            {
                                IdCompraDetalle = Convert.ToInt32(Dr["IdCompraDetalle"]),
                                oCompra = new Entidades.Compra()
                                {
                                    IdCompra = Convert.ToInt32(Dr["IdCompra"]),
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
                lista = new List<Entidades.CompraDetalle>();
            }

            return lista;
        }

        public int Registrar(Entidades.CompraDetalle obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_CompraDetalle_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdCompra", obj.oCompra.IdCompra);
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

        public bool Editar(Entidades.CompraDetalle obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_CompraDetalle_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdCompraDetalle", obj.IdCompraDetalle);
                    Cmd.Parameters.AddWithValue("IdCompra", obj.oCompra.IdCompra);
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
                    SqlCommand Cmd = new SqlCommand("sp_CompraDetalle_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("IdCompraDetalle", id);
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