using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Librería.Data
{
    public class Movimiento
    {
        public List<Entidades.Movimiento> Listar()
        {
            List<Entidades.Movimiento> lista = new List<Entidades.Movimiento>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select m.IdMovimiento, m.IdEmpresa, em.RazonSocial, m.IdTipoMovimiento, tm.IdTipoMovimiento, m.IdUsuario, u.NombreUsuario, m.FechaMovimiento, m.IdEstado, es.NombreEstado from Movimiento m join Empresa em on m.IdEmpresa = em.IdEmpresa join TipoMovimiento tm on m.IdTipoMovimiento = tm.IdTipoMovimiento join Usuario u on m.IdUsuario = u.IdUsuario join Estado es on m.IdEstado = es.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new Entidades.Movimiento()
                            {
                                IdMovimiento = Convert.ToInt32(Dr["IdMovimiento"]),
                                oEmpresa = new Entidades.Empresa()
                                {
                                    IdEmpresa = Convert.ToInt32(Dr["IdEmpresa"]),
                                    RazonSocial = Dr["RazonSocial"].ToString()
                                },
                                oTipoMovimiento = new Entidades.TipoMovimiento()
                                {
                                    IdTipoMovimiento = Convert.ToInt32(Dr["IdTipoMovimiento"]),
                                    NombreTipoMovimiento = Dr["NombreTipoMovimiento"].ToString()
                                },
                                oUsuario = new Entidades.Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(Dr["IdUsuario"]),
                                    NombreUsuario = Dr["NombreUsuario"].ToString()
                                },
                                FechaMovimiento = Dr["FechaMovimiento"].ToString(),
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
                lista = new List<Entidades.Movimiento>();
            }

            return lista;
        }

        public int Registrar(Entidades.Movimiento obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Movimiento_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("IdTipoMovimiento", obj.oTipoMovimiento.IdTipoMovimiento);
                    Cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    Cmd.Parameters.AddWithValue("FechaMovimiento", obj.FechaMovimiento);
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

        public bool Editar(Entidades.Movimiento obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Movimiento_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdMovimiento", obj.IdMovimiento);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("IdTipoMovimiento", obj.oTipoMovimiento.IdTipoMovimiento);
                    Cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    Cmd.Parameters.AddWithValue("FechaMovimiento", obj.FechaMovimiento);
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
                    SqlCommand Cmd = new SqlCommand("sp_Movimiento_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("IdMovimiento", id);
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