﻿using Librería.Data.Properties;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Data
{
    public class __Articulo
    {
        Entidades.__Articulo eArticulo = new Entidades.__Articulo();

        public bool AgregarArticulo(Entidades.__Articulo eArticulo)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "insert into Articulo(IdProveedor, CodigoArticulo, DescripcionArticulo, Cantidad, PrecioCompra, PrecioVenta, IdEstado) " +
                    "values(@IdProveedor, @CodigoArticulo, @DescripcionArticulo, @Cantidad, @PrecioCompra, @PrecioVenta, @IdEstado)";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdProveedor", eArticulo.IdProveedor);
                Cmd.Parameters.AddWithValue("@CodigoArticulo", eArticulo.CodigoArticulo);
                Cmd.Parameters.AddWithValue("@DescripcionArticulo", eArticulo.DescripcionArticulo);
                Cmd.Parameters.AddWithValue("@Cantidad", eArticulo.Cantidad);
                Cmd.Parameters.AddWithValue("@PrecioCompra", eArticulo.PrecioCompra);
                Cmd.Parameters.AddWithValue("@PrecioVenta", eArticulo.PrecioVenta);
                Cmd.Parameters.AddWithValue("@IdEstado", eArticulo.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public List<Entidades.__Articulo> ListaArticulo()
        {
            List<Entidades.__Articulo> oLista = new List<Entidades.__Articulo>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdArticulo, IdProveedor, CodigoArticulo, DescripcionArticulo, Cantidad, PrecioCompra, PrecioVenta, IdEstado from Articulo";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.__Articulo()
                        {
                            IdArticulo = int.Parse(Dr["IdArticulo"].ToString()),
                            IdProveedor = int.Parse(Dr["IdProveedor"].ToString()),
                            CodigoArticulo = Dr["CodigoArticulo"].ToString(),
                            DescripcionArticulo = Dr["DescripcionArticulo"].ToString(),
                            Cantidad = int.Parse(Dr["Cantidad"].ToString()),
                            PrecioCompra = decimal.Parse(Dr["PrecioCompra"].ToString()),
                            PrecioVenta = decimal.Parse(Dr["PrecioVenta"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public List<Entidades.__Articulo> ListaArticulo(string criterio)
        {
            List<Entidades.__Articulo> oLista = new List<Entidades.__Articulo>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdArticulo, IdProveedor, CodigoArticulo, DescripcionArticulo, Cantidad, PrecioCompra, PrecioVenta, IdEstado from Articulo where DescripcionArticulo like '%@Criterio%'";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@Criterio", criterio);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.__Articulo()
                        {
                            IdArticulo = int.Parse(Dr["IdArticulo"].ToString()),
                            IdProveedor = int.Parse(Dr["IdProveedor"].ToString()),
                            CodigoArticulo = Dr["CodigoArticulo"].ToString(),
                            DescripcionArticulo = Dr["DescripcionArticulo"].ToString(),
                            Cantidad = int.Parse(Dr["Cantidad"].ToString()),
                            PrecioCompra = decimal.Parse(Dr["PrecioCompra"].ToString()),
                            PrecioVenta = decimal.Parse(Dr["PrecioVenta"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public List<Entidades.__Articulo> ListaArticulo(Entidades.__Articulo eArticulo)
        {
            List<Entidades.__Articulo> oLista = new List<Entidades.__Articulo>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();

                if(eArticulo.IdArticulo !=0)
                {
                    string query = "Select IdArticulo, IdProveedor, CodigoArticulo, DescripcionArticulo, Cantidad, PrecioCompra, PrecioVenta, IdEstado from Articulo where IdArticulo = @IdArticulo";
                    SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                    Cmd.Parameters.AddWithValue("@IdArticulo", eArticulo.IdArticulo);
                    Cmd.CommandType = System.Data.CommandType.Text;

                    using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            oLista.Add(new Entidades.__Articulo()
                            {
                                IdArticulo = int.Parse(Dr["IdArticulo"].ToString()),
                                IdProveedor = int.Parse(Dr["IdProveedor"].ToString()),
                                CodigoArticulo = Dr["CodigoArticulo"].ToString(),
                                DescripcionArticulo = Dr["DescripcionArticulo"].ToString(),
                                Cantidad = int.Parse(Dr["Cantidad"].ToString()),
                                PrecioCompra = decimal.Parse(Dr["PrecioCompra"].ToString()),
                                PrecioVenta = decimal.Parse(Dr["PrecioVenta"].ToString()),
                                IdEstado = int.Parse(Dr["IdEstado"].ToString())
                            });
                        }
                    }
                }

                if(eArticulo.IdProveedor != 0)
                {
                    string query = "Select IdArticulo, IdProveedor, CodigoArticulo, DescripcionArticulo, Cantidad, PrecioCompra, PrecioVenta, IdEstado from Articulo where IdProveedor = @IdProveedor";
                    SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                    Cmd.Parameters.AddWithValue("@IdProveedor", eArticulo.IdProveedor);
                    Cmd.CommandType = System.Data.CommandType.Text;

                    using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            oLista.Add(new Entidades.__Articulo()
                            {
                                IdArticulo = int.Parse(Dr["IdArticulo"].ToString()),
                                IdProveedor = int.Parse(Dr["IdProveedor"].ToString()),
                                CodigoArticulo = Dr["CodigoArticulo"].ToString(),
                                DescripcionArticulo = Dr["DescripcionArticulo"].ToString(),
                                Cantidad = int.Parse(Dr["Cantidad"].ToString()),
                                PrecioCompra = decimal.Parse(Dr["PrecioCompra"].ToString()),
                                PrecioVenta = decimal.Parse(Dr["PrecioVenta"].ToString()),
                                IdEstado = int.Parse(Dr["IdEstado"].ToString())
                            });
                        }
                    }
                }
            }

            return oLista;
        }

        public bool EditarArticulo(Entidades.__Articulo eArticulo)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "update Articulo set IdProveedor = @IdProveedor, CodigoArticulo = @CodigoArticulo, DescripcionArticulo = @DescripcionArticulo, " +
                    "Cantidad = @Cantidad, PrecioCompra = @PrecioCompra, PrecioVenta = @PrecioVenta, IdEstado = @IdEstado where IdArticulo = @IdArticulo";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdArticulo", eArticulo.IdArticulo);
                Cmd.Parameters.AddWithValue("@IdProveedor", eArticulo.IdProveedor);
                Cmd.Parameters.AddWithValue("@CodigoArticulo", eArticulo.CodigoArticulo);
                Cmd.Parameters.AddWithValue("@DescripcionArticulo", eArticulo.DescripcionArticulo);
                Cmd.Parameters.AddWithValue("@Cantidad", eArticulo.Cantidad);
                Cmd.Parameters.AddWithValue("@PrecioCompra", eArticulo.PrecioCompra);
                Cmd.Parameters.AddWithValue("@PrecioVenta", eArticulo.PrecioVenta);
                Cmd.Parameters.AddWithValue("@IdEstado", eArticulo.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public bool EliminarArticulo(Entidades.__Articulo eArticulo)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Delete from Articulo where IdArticulo = @IdArticulo";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdArticulo", eArticulo.IdArticulo);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }
    }
}