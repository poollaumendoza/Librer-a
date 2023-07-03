using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Librería.Entidades;
using Librería.Data.Properties;
using System.Configuration;

namespace Librería.Data
{
	public class Compra
	{
        public List<Entidades.Compra> Listar()
        {
            List<Entidades.Compra> lista = new List<Entidades.Compra>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select c.IdCompra, c.IdEmpresa, em.RazonSocial[NombreEmpresa], c.IdEntidad, en.RazonSocial[NombreEntidad], c.IdTipoDocumento, td.NombreTipoDocumento, c.IdUsuario, u.NombreUsuario, c.FechaCompra, c.FechaRegistro, c.SubTotal, c.Impuesto, c.Total, c.IdEstado, es.NombreEstado from Compra c join Empresa em on c.IdEmpresa = em.IdEmpresa join Entidad en on c.IdEntidad = en.IdEntidad join TipoDocumento td on c.IdTipoDocumento = td.IdTipoDocumento join Usuario u on c.IdUsuario = u.IdUsuario join Estado es on c.IdEstado = es.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new Entidades.Compra()
                            {
                                IdCompra = Convert.ToInt32(Dr["IdCompra"]),
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
                                oTipoDocumento = new Entidades.TipoDocumento()
                                {
                                    IdTipoDocumento = Convert.ToInt32(Dr["IdTipoDocumento"]),
                                    NombreTipoDocumento = Dr["NombreTipoDocumento"].ToString()
                                },
                                oUsuario = new Entidades.Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(Dr["IdUsuario"]),
                                    NombreUsuario = Dr["NombreUsuario"].ToString()
                                },
                                FechaCompra = Dr["FechaCompra"].ToString(),
                                FechaRegistro = Dr["FechaRegistro"].ToString(),
                                SubTotal = Convert.ToDecimal(Dr["SubTotal"]),
                                Impuesto = Convert.ToDecimal(Dr["Impuesto"]),
                                Total = Convert.ToDecimal(Dr["Total"]),
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
                lista = new List<Entidades.Compra>();
            }

            return lista;
        }

        public int Registrar(Entidades.Compra obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Compra_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.oEntidad.IdEntidad);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    Cmd.Parameters.AddWithValue("NroDocumento", obj.NroDocumento);
                    Cmd.Parameters.AddWithValue("FechaCompra", obj.FechaCompra);
                    Cmd.Parameters.AddWithValue("FechaRegistro", obj.FechaRegistro);
                    Cmd.Parameters.AddWithValue("SubTotal", obj.SubTotal);
                    Cmd.Parameters.AddWithValue("Impuesto", obj.Impuesto);
                    Cmd.Parameters.AddWithValue("Total", obj.Total);
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

        public bool Editar(Entidades.Compra obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Compra_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdCompra", obj.IdCompra);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.oEntidad.IdEntidad);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    Cmd.Parameters.AddWithValue("NroDocumento", obj.NroDocumento);
                    Cmd.Parameters.AddWithValue("FechaCompra", obj.FechaCompra);
                    Cmd.Parameters.AddWithValue("FechaRegistro", obj.FechaRegistro);
                    Cmd.Parameters.AddWithValue("SubTotal", obj.SubTotal);
                    Cmd.Parameters.AddWithValue("Impuesto", obj.Impuesto);
                    Cmd.Parameters.AddWithValue("Total", obj.Total);
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
                    SqlCommand Cmd = new SqlCommand("sp_Compra_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("IdCompra", id);
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