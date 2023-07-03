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
	public class Persona
	{
        public List<Entidades.Persona> Listar()
        {
            List<Entidades.Persona> lista = new List<Entidades.Persona>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select p.IdPersona, p.IdTipoDocumento, TD.NombreTipoDocumento, p.ApellidoPaterno, p.ApellidoMaterno, p.PrimerNombre, p.SegundoNombre, p.Direccion, p.Telefono, p.Email, p.IdEstado, es.NombreEstado from Persona p join TipoDocumento td on p.IdTipoDocumento = td.IdTipoDocumento join Estado es on p.IdEstado = es.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new Entidades.Persona()
                            {
                                IdPersona = Convert.ToInt32(Dr["IdPersona"]),
                                oTipoDocumento = new Entidades.TipoDocumento()
                                {
                                    IdTipoDocumento = Convert.ToInt32(Dr["IdTipoDocumento"]),
                                    NombreTipoDocumento = Dr["NombreTipoDocumento"].ToString()
                                },
                                NroDocumento = Dr["NroDocumento"].ToString(),
                                ApellidoPaterno = Dr["ApellidoPaterno"].ToString(),
                                ApellidoMaterno = Dr["ApellidoMaterno"].ToString(),
                                PrimerNombre = Dr["PrimerNombre"].ToString(),
                                SegundoNombre = Dr["SegundoNombre"].ToString(),
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
                lista = new List<Entidades.Persona>();
            }

            return lista;
        }

        public int Registrar(Entidades.Persona obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Persona_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("NroDocumento", obj.NroDocumento);
                    Cmd.Parameters.AddWithValue("ApellidoPaterno", obj.ApellidoPaterno);
                    Cmd.Parameters.AddWithValue("ApellidoMaterno", obj.ApellidoMaterno);
                    Cmd.Parameters.AddWithValue("PrimerNombre", obj.PrimerNombre);
                    Cmd.Parameters.AddWithValue("SegundoNombre", obj.SegundoNombre);
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

        public bool Editar(Entidades.Persona obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Persona_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdPersona", obj.IdPersona);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("NroDocumento", obj.NroDocumento);
                    Cmd.Parameters.AddWithValue("ApellidoPaterno", obj.ApellidoPaterno);
                    Cmd.Parameters.AddWithValue("ApellidoMaterno", obj.ApellidoMaterno);
                    Cmd.Parameters.AddWithValue("PrimerNombre", obj.PrimerNombre);
                    Cmd.Parameters.AddWithValue("SegundoNombre", obj.SegundoNombre);
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
                    SqlCommand Cmd = new SqlCommand("sp_Persona_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("IdPersona", id);
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