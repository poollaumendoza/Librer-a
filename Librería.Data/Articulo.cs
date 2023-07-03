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
    public class Articulo
    {
        public List<Entidades.Articulo> Listar()
        {
            List<Entidades.Articulo> lista = new List<Entidades.Articulo>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select art.IdArticulo, art.IdEmpresa, em.RazonSocial[NombreEmpresa], art.IdEntidad, en.RazonSocial[NombreEntidad], art.CodigoArticulo, art.DescripcionArticulo, art.Cantidad, art.PrecioCompra, art.PrecioVenta, art.IdEstado, es.NombreEstado from Articulo art join Empresa em on art.IdEmpresa = em.IdEmpresa join Entidad en on art.IdEntidad = en.IdEntidad join Estado es on art.IdEstado = es.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new Entidades.Articulo()
                            {
                                IdArticulo = Convert.ToInt32(Dr["IdArticulo"]),
                                oEmpresa = new Entidades.Empresa()
                                {
                                    IdEmpresa = Convert.ToInt32(Dr["IdEmpresa"]),
                                    RazonSocial = Dr["NombreEmpresa"].ToString()
                                },
                                oEntidad = new Entidades.Entidad()
                                {
                                    IdEntidad = Convert.ToInt32(Dr["IdEntidad"]),
                                    RazonSocial = Dr["NombreEntidad"].ToString()
                                },
                                CodigoArticulo = Dr["CodigoArticulo"].ToString(),
                                DescripcionArticulo = Dr["DescripcionArticulo"].ToString(),
                                Cantidad = Convert.ToInt32(Dr["Cantidad"]),
                                PrecioCompra = Convert.ToDecimal(Dr["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(Dr["PrecioVenta"]),
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
                lista = new List<Entidades.Articulo>();
            }

            return lista;
        }

        public int Registrar(Entidades.Articulo obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Articulo_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.oEntidad.IdEntidad);
                    Cmd.Parameters.AddWithValue("CodigoArticulo", obj.CodigoArticulo);
                    Cmd.Parameters.AddWithValue("DescripcionArticulo", obj.DescripcionArticulo);
                    Cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
                    Cmd.Parameters.AddWithValue("PrecioCompra", obj.PrecioCompra);
                    Cmd.Parameters.AddWithValue("PrecioVenta", obj.PrecioVenta);
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

        public bool Editar(Entidades.Articulo obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Articulo_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdArticulo", obj.IdArticulo);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.oEntidad.IdEntidad);
                    Cmd.Parameters.AddWithValue("CodigoArticulo", obj.CodigoArticulo);
                    Cmd.Parameters.AddWithValue("DescripcionArticulo", obj.DescripcionArticulo);
                    Cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
                    Cmd.Parameters.AddWithValue("PrecioCompra", obj.PrecioCompra);
                    Cmd.Parameters.AddWithValue("PrecioVenta", obj.PrecioVenta);
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
                    SqlCommand Cmd = new SqlCommand("sp_Articulo_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("IdArticulo", id);
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