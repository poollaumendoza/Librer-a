﻿using Librería.Data.Properties;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Data
{
    public class __Venta
    {
        Entidades.__Venta eVenta = new Entidades.__Venta();

        public bool AgregarVenta(Entidades.__Venta eVenta)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "insert into Venta(IdEmpresa, IdEntidad, IdTipoDocumento, IdUsuario, IdCorrelativo, Correlativo, FechaVenta, FechaRegistro, SubTotal, Impuesto, Total, " +
                    "IdEstado) values(@IdEmpresa, @IdEntidad, @IdTipoDocumento, @IdUsuario, @IdCorrelativo, @Correlativo, @FechaVenta, @FechaRegistro, @SubTotal, @Impuesto, @Total, @IdEstado)";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdEmpresa", eVenta.IdEmpresa);
                Cmd.Parameters.AddWithValue("@IdEntidad", eVenta.IdCliente);
                Cmd.Parameters.AddWithValue("@IdTipoDocumento", eVenta.IdTipoDocumento);
                Cmd.Parameters.AddWithValue("@IdUsuario", eVenta.IdUsuario);
                Cmd.Parameters.AddWithValue("@IdCorrelativo", eVenta.IdCorrelativo);
                Cmd.Parameters.AddWithValue("@Correlativo", eVenta.Correlativo);
                Cmd.Parameters.AddWithValue("@FechaVenta", eVenta.FechaVenta);
                Cmd.Parameters.AddWithValue("@FechaRegistro", eVenta.FechaRegistro);
                Cmd.Parameters.AddWithValue("@SubTotal", eVenta.SubTotal);
                Cmd.Parameters.AddWithValue("@Impuesto", eVenta.Impuesto);
                Cmd.Parameters.AddWithValue("@Total", eVenta.Total);
                Cmd.Parameters.AddWithValue("@IdEstado", eVenta.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public List<Entidades.__Venta> ListaVenta()
        {
            List<Entidades.__Venta> oLista = new List<Entidades.__Venta>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdVenta, IdEmpresa, IdEntidad, IdTipoDocumento, IdUsuario, IdCorrelativo, Correlativo, FechaVenta, FechaRegistro, SubTotal, Impuesto, Total, " +
                    "IdEstado from Venta";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.__Venta()
                        {
                            IdVenta = int.Parse(Dr["IdVenta"].ToString()),
                            IdEmpresa = Dr["IdEmpresa"].ToString(),
                            IdCliente = Dr["IdEntidad"].ToString(),
                            IdTipoDocumento = Dr["IdTipoDocumento"].ToString(),
                            IdUsuario = Dr["IdUsuario"].ToString(),
                            IdCorrelativo = Convert.ToInt32(Dr["IdCorrelativo"].ToString()),
                            Correlativo = Dr["Correlativo"].ToString(),
                            FechaVenta = Dr["FechaVenta"].ToString(),
                            FechaRegistro = Dr["FechaRegistro"].ToString(),
                            SubTotal = decimal.Parse(Dr["SubTotal"].ToString()),
                            Impuesto = decimal.Parse(Dr["Impuesto"].ToString()),
                            Total = decimal.Parse(Dr["Total"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public List<Entidades.__Venta> ListaVenta(int IdVenta)
        {
            List<Entidades.__Venta> oLista = new List<Entidades.__Venta>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdVenta, IdEmpresa, IdEntidad, IdTipoDocumento, IdUsuario, IdCorrelativo, Correlativo, FechaVenta, FechaRegistro, SubTotal, Impuesto, Total, " +
                    "IdEstado from Venta where IdVenta = @IdVenta";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdVenta", IdVenta);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.__Venta()
                        {
                            IdVenta = int.Parse(Dr["IdVenta"].ToString()),
                            IdEmpresa = Dr["IdEmpresa"].ToString(),
                            IdCliente = Dr["IdEntidad"].ToString(),
                            IdTipoDocumento = Dr["IdTipoDocumento"].ToString(),
                            IdUsuario = Dr["IdUsuario"].ToString(),
                            IdCorrelativo = Convert.ToInt32(Dr["IdCorrelativo"].ToString()),
                            Correlativo = Dr["Correlativo"].ToString(),
                            FechaVenta = Dr["FechaVenta"].ToString(),
                            FechaRegistro = Dr["FechaRegistro"].ToString(),
                            SubTotal = decimal.Parse(Dr["SubTotal"].ToString()),
                            Impuesto = decimal.Parse(Dr["Impuesto"].ToString()),
                            Total = decimal.Parse(Dr["Total"].ToString()),
                            IdEstado = int.Parse(Dr["IdEstado"].ToString())
                        });
                    }
                }
            }

            return oLista;
        }

        public bool EditarVenta(Entidades.__Venta eVenta)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "update Venta set IdVenta = @IdVenta, IdEmpresa = @IdEmpresa, IdEntidad = @IdEntidad, IdTipoDocumento = @IdTipoDocumento, IdUsuario = " +
                    "@IdUsuario, IdCorrelativo = @IdCorrelativo, Correlativo = @Correlativo, FechaVenta = @FechaVenta, FechaRegistro = @FechaRegistro, SubTotal = @SubTotal, " +
                    "Impuesto = @Impuesto, Total = @Total, IdEstado = @IdEstado where IdVenta = @IdVenta";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdVenta", eVenta.IdVenta);
                Cmd.Parameters.AddWithValue("@IdEmpresa", eVenta.IdEmpresa);
                Cmd.Parameters.AddWithValue("@IdEntidad", eVenta.IdCliente);
                Cmd.Parameters.AddWithValue("@IdTipoDocumento", eVenta.IdTipoDocumento);
                Cmd.Parameters.AddWithValue("@IdUsuario", eVenta.IdUsuario);
                Cmd.Parameters.AddWithValue("@IdCorrelativo", eVenta.IdCorrelativo);
                Cmd.Parameters.AddWithValue("@Correlativo", eVenta.Correlativo);
                Cmd.Parameters.AddWithValue("@FechaVenta", eVenta.FechaVenta);
                Cmd.Parameters.AddWithValue("@FechaRegistro", eVenta.FechaRegistro);
                Cmd.Parameters.AddWithValue("@SubTotal", eVenta.SubTotal);
                Cmd.Parameters.AddWithValue("@Impuesto", eVenta.Impuesto);
                Cmd.Parameters.AddWithValue("@Total", eVenta.Total);
                Cmd.Parameters.AddWithValue("@IdEstado", eVenta.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public bool EliminarVenta(Entidades.__Venta eVenta)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Delete from Venta where IdVenta = @IdVenta";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdVenta", eVenta.IdVenta);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }
    }
}