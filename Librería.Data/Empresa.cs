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
	public class Empresa
	{
        public List<Entidades.Empresa> Listar()
        {
            List<Entidades.Empresa> lista = new List<Entidades.Empresa>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select em.IdEmpresa, em.IdTipoDocumento, td.NombreTipoDocumento, em.NroDocumento, em.RazonSocial, em.Direccion, em.Telefono, em.Email, em.IdEstado, es.NombreEstado from Empresa em join TipoDocumento td on em.IdTipoDocumento = td.IdTipoDocumento join Estado es on em.IdEstado = es.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new Entidades.Empresa()
                            {
                                IdEmpresa = Convert.ToInt32(Dr["IdEmpresa"]),
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
                lista = new List<Entidades.Empresa>();
            }

            return lista;
        }

        public int Registrar(Entidades.Empresa obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Empresa_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("NroDocumento", obj.NroDocumento);
                    Cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    Cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    Cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    Cmd.Parameters.AddWithValue("Email", obj.Email);
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

        public bool Editar(Entidades.Empresa obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Empresa_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.IdEmpresa);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("NroDocumento", obj.NroDocumento);
                    Cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    Cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    Cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    Cmd.Parameters.AddWithValue("Email", obj.Email);
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
                    SqlCommand Cmd = new SqlCommand("sp_Empresa_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEmpresa", id);
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