using Librería.Data.Properties;
using Librería.Entidades;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Librería.Data
{
    public class Correlativo
    {
        Entidades.Correlativo eCorrelativo = new Entidades.Correlativo();
        CorrelativoCollection listaCorrelativo = new CorrelativoCollection();
        string Cn = Settings.Default.CadenaConexion;
        SqlConnection Cnx = null;
        SqlCommand Cmd = null;
        SqlDataAdapter Da = null;
        DataTable Dt = new DataTable();

        public void AgregarCorrelativo(Entidades.Correlativo eCorrelativo)
        {
            Cnx = new SqlConnection(Cn);
            Cmd = new SqlCommand("dbo.sp_Correlativo_AgregarCorrelativo", Cnx);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@IdEmpresa", eCorrelativo.IdEmpresa);
            Cmd.Parameters.AddWithValue("@NombreTabla", eCorrelativo.NombreTabla);
            Cmd.Parameters.AddWithValue("@Abreviatura", eCorrelativo.Abreviatura);
            Cmd.Parameters.AddWithValue("@Serie", eCorrelativo.Serie);
            Cmd.Parameters.AddWithValue("@NroCorrelativo", eCorrelativo.NroCorrelativo);
            Cmd.Parameters.AddWithValue("@IdEstado", eCorrelativo.IdEstado);
            Cnx.Open();
            Cmd.ExecuteNonQuery();
            Cnx.Close();
        }
        public void EliminarCorrelativo(Entidades.Correlativo eCorrelativo)
        {
            Cnx = new SqlConnection(Cn);
            Cmd = new SqlCommand("dbo.sp_Correlativo_EliminarCorrelativo", Cnx);
            Cmd.Parameters.AddWithValue("@IdCorrelativo", eCorrelativo.IdCorrelativo);
            Cnx.Open();
            Cmd.ExecuteNonQuery();
            Cnx.Close();
        }
        public void EditarCorrelativo(Entidades.Correlativo eCorrelativo)
        {
            Cnx = new SqlConnection(Cn);
            Cmd = new SqlCommand("dbo.sp_Correlativo_ActualizarCorrelativo", Cnx);
            Cmd.Parameters.AddWithValue("@IdCorrelativo", eCorrelativo.IdCorrelativo);
            Cmd.Parameters.AddWithValue("@IdEmpresa", eCorrelativo.IdEmpresa);
            Cmd.Parameters.AddWithValue("@NombreTabla", eCorrelativo.NombreTabla);
            Cmd.Parameters.AddWithValue("@Abreviatura", eCorrelativo.Abreviatura);
            Cmd.Parameters.AddWithValue("@Serie", eCorrelativo.Serie);
            Cmd.Parameters.AddWithValue("@NroCorrelativo", eCorrelativo.NroCorrelativo);
            Cmd.Parameters.AddWithValue("@IdEstado", eCorrelativo.IdEstado);
            Cnx.Open();
            Cmd.ExecuteNonQuery();
            Cnx.Close();
        }
        public ObservableCollection<Entidades.Correlativo> ListaCorrelativo()
        {
            Dt.Columns.Clear();
            Dt.Rows.Clear();
            listaCorrelativo.Clear();

            Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Correlativo_ObtenerCorrelativo", new SqlConnection(Cn)));
            Da.Fill(Dt);

            var query = (from a in Dt.Rows.Cast<DataRow>()
                         select a).ToList();

            foreach (var item in query)
            {
                listaCorrelativo.Add(new Entidades.Correlativo()
                {
                    IdCorrelativo = Convert.ToInt32(item[0].ToString()),
                    IdEmpresa = Convert.ToInt32(item[1].ToString()),
                    NombreTabla = item[2].ToString(),
                    Abreviatura = item[3].ToString(),
                    Serie = item[4].ToString(),
                    NroCorrelativo = Convert.ToInt32(item[5].ToString()),
                    IdEstado = Convert.ToInt32(item[6].ToString())
                });
            }
            return listaCorrelativo;
        }
        public ObservableCollection<Entidades.Correlativo> ListaCorrelativo(Entidades.Correlativo eCorrelativo)
        {
            listaCorrelativo.Clear();

            Cmd = new SqlCommand("dbo.sp_Correlativo_ObtenerCorrelativoPorIdCorrelativo", new SqlConnection(Cn));
            Cmd.Parameters.AddWithValue("@IdCorrelativo", eCorrelativo.IdCorrelativo);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            var query = (from a in Dt.Rows.Cast<DataRow>()
                         select a).ToList();

            foreach (var item in query)
            {
                listaCorrelativo.Add(new Entidades.Correlativo()
                {
                    IdCorrelativo = Convert.ToInt32(item[0].ToString()),
                    IdEmpresa = Convert.ToInt32(item[1].ToString()),
                    NombreTabla = item[2].ToString(),
                    Abreviatura = item[3].ToString(),
                    Serie = item[4].ToString(),
                    NroCorrelativo = Convert.ToInt32(item[5].ToString()),
                    IdEstado = Convert.ToInt32(item[6].ToString())
                });
            }
            return listaCorrelativo;
        }

        public string ConstruirCorrelativoDocumento(int IdCorrelativo)
        {
            Dt.Columns.Clear();
            Dt.Rows.Clear();
            string resultado = string.Empty;

            Cmd = new SqlCommand("dbo.sp_Correlativo_ConstruirCorrelativoDocumento", new SqlConnection(Cn));
            Cmd.Parameters.AddWithValue("@IdCorrelativo", IdCorrelativo);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            if (Dt.Rows.Count > 0)
            {
                var q1 = (from c in Dt.Rows.Cast<DataRow>()
                          select new
                          {
                              NroCorrelativo = Convert.ToInt32(c[0].ToString())
                          }).FirstOrDefault();

                int nroCorrelativo = q1.NroCorrelativo;
                string ceros = "00000000";
                resultado = resultado + ceros.PadLeft(ceros.Length - nroCorrelativo.ToString().Length) + nroCorrelativo.ToString();
            }
            return resultado;
        }

        public string ConstruirCorrelativoArticulo(string codigo)
        {
            string resultado = string.Empty;
            string correlativo = string.Empty;

            for (int i = 0; i < codigo.Length; i++)
            {
                string s = codigo.Substring(i, 1);
                bool esNum = int.TryParse(s, out int n);
                if (esNum == false)
                    resultado += s;
            }

            var _correlativo = (from c in ListaCorrelativo()
                                where c.Abreviatura.Equals(resultado)
                                select c.NroCorrelativo).FirstOrDefault();

            string ceros = "00000";
            correlativo = resultado + ceros.PadLeft(ceros.Length - _correlativo.ToString().Length) + _correlativo.ToString();

            return correlativo;
        }

        public string ObtenerAbreviatura(int IdTipoDocumento, string NombreTabla)
        {
            string resultado = string.Empty;

            Dt.Rows.Clear();
            Dt.Columns.Clear();

            Cmd = new SqlCommand("sp_Correlativo_ObtenerAbreviatura", new SqlConnection(Cn));
            Cmd.Parameters.AddWithValue("@IdTipoDocumento", IdTipoDocumento);
            Cmd.Parameters.AddWithValue("@NombreTabla", NombreTabla);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            if (Dt.Rows.Count > 0)
            {
                var q1 = (from c in Dt.Rows.Cast<DataRow>()
                          select new
                          {
                              Abreviatura = c[0].ToString()
                          }).FirstOrDefault();

                resultado = q1.Abreviatura;
            }
            return resultado;
        }

        public ObservableCollection<Entidades.Correlativo> ObtenerSerie(string NombreTabla, string Abreviatura)
        {
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaCorrelativo.Clear();

            Cmd = new SqlCommand("sp_Correlativo_ObtenerSerie", new SqlConnection(Cn));
            Cmd.Parameters.AddWithValue("@NombreTabla", NombreTabla);
            Cmd.Parameters.AddWithValue("@Abreviatura", Abreviatura);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            var query = (from a in Dt.Rows.Cast<DataRow>()
                         select a).ToList();

            foreach (var item in query)
            {
                listaCorrelativo.Add(new Entidades.Correlativo()
                {
                    IdCorrelativo = Convert.ToInt32(item[0].ToString()),
                    IdEmpresa = Convert.ToInt32(item[1].ToString()),
                    NombreTabla = item[2].ToString(),
                    Abreviatura = item[3].ToString(),
                    Serie = item[4].ToString(),
                    NroCorrelativo = Convert.ToInt32(item[5].ToString()),
                    IdEstado = Convert.ToInt32(item[6].ToString())
                });
            }
            return listaCorrelativo;
        }
    }
}