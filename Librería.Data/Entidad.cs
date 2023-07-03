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
	public class Entidad
	{
        public List<Entidades.Entidad> Listar()
        {
            List<Entidades.Entidad> lista = new List<Entidades.Entidad>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select en.IdEntidad, en.IdEmpresa, em.RazonSocial, en.IdTipoDocumento, td.NombreTipoDocumento, en.NroDocumento, en.RazonSocial, en.Direccion, en.Telefono, en.Email, en.EsCliente, en.EsProveedor, en.IdEstado, es.NombreEstado from Entidad en join Empresa em on en.IdEmpresa = em.IdEmpresa join TipoDocumento td on en.IdTipoDocumento = td.IdTipoDocumento join Estado es on en.IdEstado = es.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new Entidades.Entidad()
                            {
                                IdEntidad = Convert.ToInt32(Dr["IdEntidad"]),
                                oEmpresa = new Entidades.Empresa()
                                {
                                    IdEmpresa = Convert.ToInt32(Dr["IdEmpresa"]),
                                    RazonSocial = Dr["RazonSocial"].ToString()
                                },
                                oTipoDocumento = new Entidades.TipoDocumento()
                                {
                                    IdTipoDocumento = Convert.ToInt32(Dr["IdTipoDocumento"]),
                                    NombreTipoDocumento = Dr["NombreTipoDocumento"].ToString()
                                },
                                NroDocumento = Dr["NroDocumento"].ToString(),
                                RazonSocial = Dr["RazonSocial"].ToString(),
                                Direccion = Dr["Direccion"].ToString(),
                                Telefono = Dr["Telefono"].ToString(),
                                Email = Dr["Email"].ToString(),
                                EsCliente = Convert.ToBoolean(Dr["EsCliente"]),
                                EsProveedor = Convert.ToBoolean(Dr["EsProveedor"]),
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
                lista = new List<Entidades.Entidad>();
            }

            return lista;
        }

        public int Registrar(Entidades.Entidad obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Entidad_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("NroDocumento", obj.NroDocumento);
                    Cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    Cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    Cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    Cmd.Parameters.AddWithValue("Email", obj.Email);
                    Cmd.Parameters.AddWithValue("EsCliente", obj.EsCliente);
                    Cmd.Parameters.AddWithValue("EsProveedor", obj.EsProveedor);
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

        public bool Editar(Entidades.Entidad obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Entidad_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.IdEntidad);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("NroDocumento", obj.NroDocumento);
                    Cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    Cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    Cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    Cmd.Parameters.AddWithValue("Email", obj.Email);
                    Cmd.Parameters.AddWithValue("EsCliente", obj.EsCliente);
                    Cmd.Parameters.AddWithValue("EsProveedor", obj.EsProveedor);
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
                    SqlCommand Cmd = new SqlCommand("sp_Entidad_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEntidad", id);
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