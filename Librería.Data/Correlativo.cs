using Librería.Data.Properties;
using Librería.Entidades;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Configuration;

namespace Librería.Data
{
    public class Correlativo
    {
        public List<Entidades.Correlativo> Listar()
        {
            List<Entidades.Correlativo> lista = new List<Entidades.Correlativo>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select c.IdCorrelativo, c.IdEmpresa, em.RazonSocial, c.IdTipoDocumento, td.NombreTipoDocumento, c.NombreTabla, c.Abreviatura, c.Serie, c.NroCorrelativo, c.IdEstado, es.NombreEstado from Correlativo c join Empresa em on c.IdEmpresa = c.IdEmpresa join TipoDocumento td on c.IdTipoDocumento = td.IdTipoDocumento join Estado es on c.IdEstado = es.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new Entidades.Correlativo()
                            {
                                IdCorrelativo = Convert.ToInt32(Dr["IdCorrelativo"]),
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
                                NombreTabla = Dr["NombreTabla"].ToString(),
                                Abreviatura = Dr["Abreviatura"].ToString(),
                                Serie = Dr["Serie"].ToString(),
                                NroCorrelativo = Convert.ToInt32(Dr["NroCorrelativo"]),
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
                lista = new List<Entidades.Correlativo>();
            }

            return lista;
        }

        public int Registrar(Entidades.Correlativo obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Correlativo_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("NombreTabla", obj.NombreTabla);
                    Cmd.Parameters.AddWithValue("Abreviatura", obj.Abreviatura);
                    Cmd.Parameters.AddWithValue("Serie", obj.Serie);
                    Cmd.Parameters.AddWithValue("NroCorrelativo", obj.NroCorrelativo);
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

        public bool Editar(Entidades.Correlativo obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Correlativo_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdCorrelativo", obj.IdCorrelativo);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("NombreTabla", obj.NombreTabla);
                    Cmd.Parameters.AddWithValue("Abreviatura", obj.Abreviatura);
                    Cmd.Parameters.AddWithValue("Serie", obj.Serie);
                    Cmd.Parameters.AddWithValue("NroCorrelativo", obj.NroCorrelativo);
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
                    SqlCommand Cmd = new SqlCommand("sp_Correlativo_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("IdCorrelativo", id);
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

        //public string ConstruirCorrelativoDocumento(int IdCorrelativo)
        //{
        //    Dt.Columns.Clear();
        //    Dt.Rows.Clear();
        //    string resultado = string.Empty;

        //    Cmd = new SqlCommand("dbo.sp_Correlativo_ConstruirCorrelativoDocumento", new SqlConnection(Cn));
        //    Cmd.Parameters.AddWithValue("@IdCorrelativo", IdCorrelativo);
        //    Cmd.CommandType = CommandType.StoredProcedure;
        //    Da = new SqlDataAdapter(Cmd);
        //    Da.Fill(Dt);

        //    if (Dt.Rows.Count > 0)
        //    {
        //        var q1 = (from c in Dt.Rows.Cast<DataRow>()
        //                  select new
        //                  {
        //                      NroCorrelativo = Convert.ToInt32(c[0].ToString())
        //                  }).FirstOrDefault();

        //        int nroCorrelativo = q1.NroCorrelativo;
        //        string ceros = "00000000";
        //        int niz = ceros.Length - nroCorrelativo.ToString().Length;
        //        resultado = string.Format("{0}{1}", Strings.Left(ceros, niz), nroCorrelativo.ToString());
        //    }
        //    return resultado;
        //}

        //public string ConstruirCorrelativoArticulo(string codigo)
        //{
        //    string resultado = string.Empty;
        //    string correlativo = string.Empty;

        //    for (int i = 0; i < codigo.Length; i++)
        //    {
        //        string s = codigo.Substring(i, 1);
        //        bool esNum = int.TryParse(s, out int n);
        //        if (esNum == false)
        //            resultado += s;
        //    }

        //    var _correlativo = (from c in ListaCorrelativo()
        //                        where c.Abreviatura.Equals(resultado)
        //                        select c.NroCorrelativo).FirstOrDefault();

        //    string ceros = "00000";
        //    correlativo = resultado + ceros.PadLeft(ceros.Length - _correlativo.ToString().Length) + _correlativo.ToString();

        //    return correlativo;
        //}

        //public string ObtenerAbreviatura(int IdTipoDocumento, string NombreTabla)
        //{
        //    string resultado = string.Empty;

        //    Dt.Rows.Clear();
        //    Dt.Columns.Clear();

        //    Cmd = new SqlCommand("sp_Correlativo_ObtenerAbreviatura", new SqlConnection(Cn));
        //    Cmd.Parameters.AddWithValue("@IdTipoDocumento", IdTipoDocumento);
        //    Cmd.Parameters.AddWithValue("@NombreTabla", NombreTabla);
        //    Cmd.CommandType = CommandType.StoredProcedure;
        //    Da = new SqlDataAdapter(Cmd);
        //    Da.Fill(Dt);

        //    if (Dt.Rows.Count > 0)
        //    {
        //        var q1 = (from c in Dt.Rows.Cast<DataRow>()
        //                  select new
        //                  {
        //                      Abreviatura = c[0].ToString()
        //                  }).FirstOrDefault();

        //        resultado = q1.Abreviatura;
        //    }
        //    return resultado;
        //}

        //public ObservableCollection<Entidades.Correlativo> ObtenerSerie(string NombreTabla, string Abreviatura)
        //{
        //    Dt.Rows.Clear();
        //    Dt.Columns.Clear();
        //    listaCorrelativo.Clear();

        //    Cmd = new SqlCommand("sp_Correlativo_ObtenerSerie", new SqlConnection(Cn));
        //    Cmd.Parameters.AddWithValue("@NombreTabla", NombreTabla);
        //    Cmd.Parameters.AddWithValue("@Abreviatura", Abreviatura);
        //    Cmd.CommandType = CommandType.StoredProcedure;
        //    Da = new SqlDataAdapter(Cmd);
        //    Da.Fill(Dt);

        //    var query = (from a in Dt.Rows.Cast<DataRow>()
        //                 select a).ToList();

        //    foreach (var item in query)
        //    {
        //        listaCorrelativo.Add(new Entidades.Correlativo()
        //        {
        //            IdCorrelativo = Convert.ToInt32(item[0].ToString()),
        //            IdEmpresa = Convert.ToInt32(item[1].ToString()),
        //            IdTipoDocumento = Convert.ToInt32(item[2].ToString()),
        //            NombreTabla = item[3].ToString(),
        //            Abreviatura = item[4].ToString(),
        //            Serie = item[5].ToString(),
        //            NroCorrelativo = Convert.ToInt32(item[6].ToString()),
        //            IdEstado = Convert.ToInt32(item[7].ToString())
        //        });
        //    }
        //    return listaCorrelativo;
        //}

        //public void ActualizarCorrelativoArticulo(string NombreTabla, string Abreviatura)
        //{
        //    Cnx = new SqlConnection(Cn);
        //    Cmd = new SqlCommand("dbo.sp_Correlativo_ActualizarCorrelativoArticulo", Cnx);
        //    Cmd.Parameters.AddWithValue("@NombreTabla", NombreTabla);
        //    Cmd.Parameters.AddWithValue("@Abreviatura", Abreviatura);
        //    Cmd.CommandType = CommandType.StoredProcedure;
        //    Cnx.Open();
        //    Cmd.ExecuteNonQuery();
        //    Cnx.Close();
        //}
    }
}