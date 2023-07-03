using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Librería.Data
{
    public class Usuario
    {
        public List<Entidades.Usuario> Listar()
        {
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select u.IdUsuario, u.IdPersona, CONCAT(p.ApellidoPaterno, ' ', p.ApellidoMaterno, ', ', p.PrimerNombre, ' ', p.SegundoNombre)[NombreCompleto], u.NombreUsuario, u.Contraseña, u.IdEstado, e.NombreEstado from Usuario u join Persona p on u.IdPersona = p.IdPersona join Estado e on u.IdEstado = e.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new Entidades.Usuario()
                            {
                                IdUsuario = Convert.ToInt32(Dr["IdUsuario"]),
                                oPersona = new Entidades.Persona()
                                {
                                    IdPersona = Convert.ToInt32(Dr["IdPersona"]),
                                    NombreCompleto = Dr["NombreCompleto"].ToString()
                                },
                                NombreUsuario = Dr["NombreUsuario"].ToString(),
                                Contraseña = _Util.Decrypt(Dr["Contraseña"].ToString(), false),
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
                lista = new List<Entidades.Usuario>();
            }

            return lista;
        }

        public int Registrar(Entidades.Usuario obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Usuario_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdPersona", obj.oPersona.IdPersona);
                    Cmd.Parameters.AddWithValue("NombreUsuario", obj.NombreUsuario);
                    Cmd.Parameters.AddWithValue("Contraseña", _Util.Encrypt(obj.Contraseña, false));
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

        public bool Editar(Entidades.Usuario obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Usuario_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    Cmd.Parameters.AddWithValue("IdPersona", obj.oPersona.IdPersona);
                    Cmd.Parameters.AddWithValue("NombreUsuario", obj.NombreUsuario);
                    Cmd.Parameters.AddWithValue("Contraseña", _Util.Encrypt(obj.Contraseña, false));
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
                    SqlCommand Cmd = new SqlCommand("sp_Usuario_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdUsuario", id);
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