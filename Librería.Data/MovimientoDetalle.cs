using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Librería.Data
{
    public class MovimientoDetalle
    {
        public List<Entidades.MovimientoDetalle> Listar()
        {
            List<Entidades.MovimientoDetalle> lista = new List<Entidades.MovimientoDetalle>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select md.IdMovimientoDetalle, md.IdMovimiento, m.NroMovimiento, md.IdArticulo, a.DescripcionArticulo, md.Cantidad, md.IdEstado, e.NombreEstado from MovimientoDetalle md join Movimiento m on md.IdMovimiento = m.IdMovimiento join Articulo a on md.IdArticulo = a.IdArticulo join Estado e on md.IdEstado = e.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new Entidades.MovimientoDetalle()
                            {
                                IdMovimientoDetalle = Convert.ToInt32(Dr["IdMovimientoDetalle"]),
                                oMovimiento = new Entidades.Movimiento()
                                {
                                    IdMovimiento = Convert.ToInt32(Dr["IdMovimiento"]),
                                    NroMovimiento = Dr["NroMovimiento"].ToString()
                                },
                                oArticulo = new Entidades.Articulo()
                                {
                                    IdArticulo = Convert.ToInt32(Dr["IdArticulo"]),
                                    DescripcionArticulo = Dr["DescripcionArticulo"].ToString()
                                },
                                Cantidad = Convert.ToInt32(Dr["Cantidad"]),
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
                lista = new List<Entidades.MovimientoDetalle>();
            }

            return lista;
        }

        public int Registrar(Entidades.MovimientoDetalle obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_MovimientoDetalle_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdMovimiento", obj.oMovimiento.IdMovimiento);
                    Cmd.Parameters.AddWithValue("IdArticulo", obj.oArticulo.IdArticulo);
                    Cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
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

        public bool Editar(Entidades.MovimientoDetalle obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_MovimientoDetalle_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdMovimientoDetalle", obj.IdMovimientoDetalle);
                    Cmd.Parameters.AddWithValue("IdMovimiento", obj.oMovimiento.IdMovimiento);
                    Cmd.Parameters.AddWithValue("IdArticulo", obj.oArticulo.IdArticulo);
                    Cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
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
                    SqlCommand Cmd = new SqlCommand("sp_MovimientoDetalle_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("IdMovimientoDetalle", id);
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