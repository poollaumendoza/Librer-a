using Librería.Data.Properties;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace Librería.Data
{
    public class __Correlativo
    {
        Entidades.__Correlativo eCorrelativo = new Entidades.__Correlativo();
        List<Entidades.__Correlativo> listaCorrelativo = new List<Entidades.__Correlativo>();

        public bool AgregarCorrelativo(Entidades.__Correlativo eCorrelativo)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "insert into Correlativo(IdEmpresa, NombreTabla, Abreviatura, Serie, NroCorrelativo, IdEstado) values(@IdEmpresa, @NombreTabla, " +
                    "@Abreviatura, @Serie, @NroCorrelativo, @IdEstado)";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdEmpresa", eCorrelativo.IdEmpresa);
                Cmd.Parameters.AddWithValue("@NombreTabla", eCorrelativo.NombreTabla);
                Cmd.Parameters.AddWithValue("@Abreviatura", eCorrelativo.Abreviatura);
                Cmd.Parameters.AddWithValue("@Serie", eCorrelativo.Serie);
                Cmd.Parameters.AddWithValue("@NroCorrelativo", eCorrelativo.NroCorrelativo);
                Cmd.Parameters.AddWithValue("@IdEstado", eCorrelativo.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
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

        public string ConstruirCorrelativoDocumento(int IdCorrelativo)
        {
            string resultado = string.Empty;

            int nroCorrelativo = (from c in ListaCorrelativo()
                                  where c.IdCorrelativo.Equals(IdCorrelativo)
                                  select c.NroCorrelativo).FirstOrDefault();

            string ceros = "00000";
            resultado = resultado + ceros.PadLeft(ceros.Length - nroCorrelativo.ToString().Length) + nroCorrelativo.ToString();

            return resultado;
        }

        public List<Entidades.__Correlativo> ListaCorrelativo()
        {
            List<Entidades.__Correlativo> oLista = new List<Entidades.__Correlativo>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdCorrelativo, IdEmpresa, NombreTabla, Abreviatura, Serie, NroCorrelativo, IdEstado from Correlativo";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.__Correlativo()
                        {
                            IdCorrelativo = int.Parse(Dr["IdCorrelativo"].ToString()),
                            IdEmpresa = Dr["IdEmpresa"].ToString(),
                            NombreTabla = Dr["NombreTabla"].ToString(),
                            Abreviatura = Dr["Abreviatura"].ToString(),
                            Serie = Dr["Serie"].ToString(),
                            NroCorrelativo = int.Parse(Dr["NroCorrelativo"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public List<Entidades.__Correlativo> ListaCorrelativo(int IdCorrelativo)
        {
            List<Entidades.__Correlativo> oLista = new List<Entidades.__Correlativo>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();

                string query = "Select IdCorrelativo, IdEmpresa, NombreTabla, Abreviatura, Serie, NroCorrelativo, IdEstado from Correlativo where IdCorrelativo =" +
                    " @IdCorrelativo";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdCorrelativo", IdCorrelativo);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.__Correlativo()
                        {
                            IdCorrelativo = int.Parse(Dr["IdCorrelativo"].ToString()),
                            IdEmpresa = Dr["IdEmpresa"].ToString(),
                            NombreTabla = Dr["NombreTabla"].ToString(),
                            Abreviatura = Dr["Abreviatura"].ToString(),
                            Serie = Dr["Serie"].ToString(),
                            NroCorrelativo = int.Parse(Dr["NroCorrelativo"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public List<Entidades.__Correlativo> ListaCorrelativo(string Abreviatura)
        {
            List<Entidades.__Correlativo> oLista = new List<Entidades.__Correlativo>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();

                string query = "Select IdCorrelativo, IdEmpresa, NombreTabla, Abreviatura, Serie, NroCorrelativo, IdEstado from Correlativo where Abreviatura = " +
                    "@Abreviatura";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@Abreviatura", Abreviatura);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.__Correlativo()
                        {
                            IdCorrelativo = int.Parse(Dr["IdCorrelativo"].ToString()),
                            IdEmpresa = Dr["IdEmpresa"].ToString(),
                            NombreTabla = Dr["NombreTabla"].ToString(),
                            Abreviatura = Dr["Abreviatura"].ToString(),
                            Serie = Dr["Serie"].ToString(),
                            NroCorrelativo = int.Parse(Dr["NroCorrelativo"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public bool EditarCorrelativo(Entidades.__Correlativo eCorrelativo)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "update Correlativo set IdEmpresa = @IdEmpresa, NombreTabla = @NombreTabla, Abreviatura = @Abreviatura, " +
                    "Serie = @Serie, NroCorrelativo = @NroCorrelativo, IdEstado = @IdEstado where IdCorrelativo = @IdCorrelativo";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdCorrelativo", eCorrelativo.IdCorrelativo);
                Cmd.Parameters.AddWithValue("@IdEmpresa", eCorrelativo.IdEmpresa);
                Cmd.Parameters.AddWithValue("@NombreTabla", eCorrelativo.NombreTabla);
                Cmd.Parameters.AddWithValue("@Abreviatura", eCorrelativo.Abreviatura);
                Cmd.Parameters.AddWithValue("@Serie", eCorrelativo.Serie);
                Cmd.Parameters.AddWithValue("@NroCorrelativo", eCorrelativo.NroCorrelativo);
                Cmd.Parameters.AddWithValue("@IdEstado", eCorrelativo.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public bool EliminarCorrelativo(Entidades.__Correlativo eCorrelativo)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Delete from Correlativo where IdCorrelativo = @IdCorrelativo";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdCorrelativo", eCorrelativo.IdCorrelativo);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public List<Entidades.__Correlativo> ObtenerSerie(string NombreTabla, string Abreviatura)
        {
            listaCorrelativo.Clear();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdCorrelativo, IdEmpresa, NombreTabla, Abreviatura, Serie, NroCorrelativo, IdEstado from Correlativo where " +
                    "NombreTabla = @NombreTabla and Abreviatura = @Abreviatura";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@NombreTabla", NombreTabla);
                Cmd.Parameters.AddWithValue("@Abreviatura", Abreviatura);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        listaCorrelativo.Add(new Entidades.__Correlativo()
                        {
                            IdCorrelativo = int.Parse(Dr["IdCorrelativo"].ToString()),
                            IdEmpresa = Dr["IdEmpresa"].ToString(),
                            NombreTabla = Dr["NombreTabla"].ToString(),
                            Abreviatura = Dr["Abreviatura"].ToString(),
                            Serie = Dr["Serie"].ToString(),
                            NroCorrelativo = int.Parse(Dr["NroCorrelativo"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }
            return listaCorrelativo;
        }

        public int ObtenerCorrelativo(int IdCorrelativo)
        {
            int resultado = 0;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select NroCorrelativo from Correlativo where IdCorrelativo = @IdCorrelativo";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdCorrelativo", IdCorrelativo);

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                        resultado = Convert.ToInt32(Dr["NroCorrelativo"].ToString());
                }
            }
            return resultado;
        }
    }
}