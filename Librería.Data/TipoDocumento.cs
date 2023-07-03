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
	public class TipoDocumento
	{
        public List<Entidades.TipoDocumento> Listar()
        {
            List<Entidades.TipoDocumento> lista = new List<Entidades.TipoDocumento>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select td.IdTipoDocumento, ctd.IdClasificacionTipoDocumento, ctd.NombreClasificacionTipoDocumento, " +
                        "td.NombreTipoDocumento, td.IdEstado, e.NombreEstado from TipoDocumento td join ClasificacionTipoDocumento " +
                        "ctd on td.IdClasificacionTipoDocumento = ctd.IdClasificacionTipoDocumento join Estado e on td.IdEstado = " +
                        "e.IdEstado where ctd.IdEstado = (Select IdEstado from Estado where NombreEstado = 'ACTIVO')";

                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new Entidades.TipoDocumento()
                            {
                                IdTipoDocumento = Convert.ToInt32(Dr["IdTipoDocumento"]),
                                NombreTipoDocumento = Dr["NombreTipoDocumento"].ToString(),
                                oClasificacionTipoDocumento = new Entidades.ClasificacionTipoDocumento()
                                {
                                    IdClasificacionTipoDocumento = Convert.ToInt32(Dr["IdClasificacionTipoDocumento"]),
                                    NombreClasificacionTipoDocumento = Dr["NombreClasificacionTipoDocumento"].ToString()
                                },
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
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                lista = new List<Entidades.TipoDocumento>();
            }

            return lista;
        }

        public List<Entidades.TipoDocumento> Listar(string tipo)
        {
            List<Entidades.TipoDocumento> lista = new List<Entidades.TipoDocumento>();

            string query = string.Empty; ;

            try
            {
                switch (tipo)
                {
                    case "identidad":
                        query = "Select td.IdTipoDocumento, ctd.IdClasificacionTipoDocumento, ctd.NombreClasificacionTipoDocumento, td.NombreTipoDocumento, td.IdEstado, e.NombreEstado from TipoDocumento td join ClasificacionTipoDocumento ctd on td.IdClasificacionTipoDocumento = ctd.IdClasificacionTipoDocumento join Estado e on td.IdEstado = e.IdEstado where ctd.IdEstado = (Select IdEstado from Estado where NombreEstado = 'ACTIVO') and ctd.IdClasificacionTipoDocumento = 1";
                        break;
                    case "contable":
                        query = "Select td.IdTipoDocumento, ctd.IdClasificacionTipoDocumento, ctd.NombreClasificacionTipoDocumento, td.NombreTipoDocumento, td.IdEstado, e.NombreEstado from TipoDocumento td join ClasificacionTipoDocumento ctd on td.IdClasificacionTipoDocumento = ctd.IdClasificacionTipoDocumento join Estado e on td.IdEstado = e.IdEstado where ctd.IdEstado = (Select IdEstado from Estado where NombreEstado = 'ACTIVO') and ctd.IdClasificacionTipoDocumento = 2";
                        break;
                }

                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand(query, Cnx);
                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new Entidades.TipoDocumento()
                            {
                                IdTipoDocumento = Convert.ToInt32(Dr["IdTipoDocumento"]),
                                NombreTipoDocumento = Dr["NombreTipoDocumento"].ToString(),
                                oClasificacionTipoDocumento = new Entidades.ClasificacionTipoDocumento()
                                {
                                    IdClasificacionTipoDocumento = Convert.ToInt32(Dr["IdClasificacionTipoDocumento"]),
                                    NombreClasificacionTipoDocumento = Dr["NombreClasificacionTipoDocumento"].ToString()
                                },
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
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                lista = new List<Entidades.TipoDocumento>();
            }

            return lista;
        }

        public int Registrar(Entidades.TipoDocumento obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_TipoDocumento_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdClasificacionTipoDocumento", obj.oClasificacionTipoDocumento.IdClasificacionTipoDocumento);
                    Cmd.Parameters.AddWithValue("NombreTipoDocumento", obj.NombreTipoDocumento);
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

        public bool Editar(Entidades.TipoDocumento obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_TipoDocumento_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("IdClasificacionTipoDocumento", obj.oClasificacionTipoDocumento.IdClasificacionTipoDocumento);
                    Cmd.Parameters.AddWithValue("NombreTipoDocumento", obj.NombreTipoDocumento);
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
                    SqlCommand Cmd = new SqlCommand("Delete TipoDocumento where IdTipoDocumento = @IdTipoDocumento", Cnx);
                    Cmd.Parameters.AddWithValue("@IdTipoDocumento", id);
                    Cmd.CommandType = CommandType.Text;
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