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
	public class Venta
	{
        public List<Entidades.Venta> Listar()
        {
            List<Entidades.Venta> lista = new List<Entidades.Venta>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select v.IdVenta, v.IdEmpresa, em.RazonSocial[NombreEmpresa], v.IdEntidad, en.RazonSocial[NombreEntidad], v.IdTipoDocumento, td.NombreTipoDocumento, v.IdUsuario, u.NombreUsuario, v.IdCorrelativo, cr.NroCorrelativo, v.NroDocumento, v.FechaVenta, v.FechaRegistro, v.SubTotal, v.Impuesto, v.Total, v.IdEstado, es.NombreEstado from Venta v join Empresa em on v.IdEmpresa = em.IdEmpresa join Entidad en on v.IdEntidad = en.IdEntidad join TipoDocumento td on v.IdTipoDocumento = td.IdTipoDocumento join Usuario u on v.IdUsuario = u.IdUsuario join Correlativo cr on v.IdCorrelativo = cr.IdCorrelativo join Estado es on v.IdEstado = es.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new Entidades.Venta()
                            {
                                IdVenta = Convert.ToInt32(Dr["IdVenta"]),
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
                                oCorrelativo = new Entidades.Correlativo()
                                {
                                    IdCorrelativo = Convert.ToInt32(Dr["IdCorrelativo"]),
                                    NroCorrelativo = Convert.ToInt32(Dr["NroCorrelativo"])
                                },
                                FechaVenta = Dr["FechaVenta"].ToString(),
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
                lista = new List<Entidades.Venta>();
            }

            return lista;
        }

        public int Registrar(Entidades.Venta obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Venta_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.oEntidad.IdEntidad);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    Cmd.Parameters.AddWithValue("IdCorrelativo", obj.oCorrelativo.IdCorrelativo);
                    Cmd.Parameters.AddWithValue("NroDocumento", obj.NroDocumento);
                    Cmd.Parameters.AddWithValue("FechaVenta", obj.FechaVenta);
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

        public bool Editar(Entidades.Venta obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Venta_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdVenta", obj.IdVenta);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.oEntidad.IdEntidad);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    Cmd.Parameters.AddWithValue("IdCorrelativo", obj.oCorrelativo.IdCorrelativo);
                    Cmd.Parameters.AddWithValue("NroDocumento", obj.NroDocumento);
                    Cmd.Parameters.AddWithValue("FechaVenta", obj.FechaVenta);
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
                    SqlCommand Cmd = new SqlCommand("sp_Venta_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("IdVenta", id);
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