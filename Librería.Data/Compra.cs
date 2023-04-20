using Librería.Data.Properties;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Data
{
    public class Compra
    {
        Entidades.Compra eCompra = new Entidades.Compra();

        public bool AgregarCompra(Entidades.Compra eCompra)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "insert into Compra(IdEmpresa, IdEntidad, IdTipoDocumento, IdUsuario, NroDocumento, FechaCompra, FechaRegistro, SubTotal, Impuesto, Total, " +
                    "IdEstado) values(@IdEmpresa, @IdTipoDocumento, @IdUsuario, @NroDocumento, @FechaCompra, @FechaRegistro, @SubTotal, @Impuesto, @Total, @IdEstado)";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdEmpresa", eCompra.IdEmpresa);
                Cmd.Parameters.AddWithValue("@IdEntidad", eCompra.IdProveedor);
                Cmd.Parameters.AddWithValue("@IdTipoDocumento", eCompra.IdTipoDocumento);
                Cmd.Parameters.AddWithValue("@IdUsuario", eCompra.IdUsuario);
                Cmd.Parameters.AddWithValue("@NroDocumento", eCompra.NroDocumento);
                Cmd.Parameters.AddWithValue("@FechaCompra", eCompra.FechaCompra);
                Cmd.Parameters.AddWithValue("@FechaRegistro", eCompra.FechaRegistro);
                Cmd.Parameters.AddWithValue("@SubTotal", eCompra.SubTotal);
                Cmd.Parameters.AddWithValue("@Impuesto", eCompra.Impuesto);
                Cmd.Parameters.AddWithValue("@Total", eCompra.Total);
                Cmd.Parameters.AddWithValue("@IdEstado", eCompra.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public List<Entidades.Compra> ListaCompra()
        {
            List<Entidades.Compra> oLista = new List<Entidades.Compra>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdCompra, IdEmpresa, IdEntidad, IdTipoDocumento, IdUsuario, NroDocumento, FechaCompra, FechaRegistro, SubTotal, Impuesto, Total, IdEstado " +
                    "from Compra";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.Compra()
                        {
                            IdCompra = int.Parse(Dr["IdCompra"].ToString()),
                            IdEmpresa = Dr["IdEmpresa"].ToString(),
                            IdProveedor = Dr["IdEntidad"].ToString(),
                            IdTipoDocumento = Dr["IdTipoDocumento"].ToString(),
                            IdUsuario = Dr["IdUsuario"].ToString(),
                            NroDocumento = Dr["NroDocumento"].ToString(),
                            FechaCompra = Dr["FechaCompra"].ToString(),
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

        public List<Entidades.Compra> ListaCompra(int IdCompra)
        {
            List<Entidades.Compra> oLista = new List<Entidades.Compra>();

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Select IdCompra, IdEmpresa, IdEntidad, IdTipoDocumento, IdUsuario, NroDocumento, FechaCompra, FechaRegistro, SubTotal, Impuesto, Total, IdEstado" +
                    " from Compra where IdCompra = @IdCompra";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdCompra", IdCompra);
                Cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new Entidades.Compra()
                        {
                            IdCompra = int.Parse(Dr["IdCompra"].ToString()),
                            IdEmpresa = Dr["IdEmpresa"].ToString(),
                            IdProveedor = Dr["IdEntidad"].ToString(),
                            IdTipoDocumento = Dr["IdTipoDocumento"].ToString(),
                            IdUsuario = Dr["IdUsuario"].ToString(),
                            NroDocumento = Dr["NroDocumento"].ToString(),
                            FechaCompra = Dr["FechaCompra"].ToString(),
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

        public bool EditarCompra(Entidades.Compra eCompra)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "update Compra set IdCompra = @IdCompra, IdEmpresa = @IdEmpresa, IdEntidad = @IdEntidad, IdTipoDocumento = @IdTipoDocumento, IdUsuario = @IdUsuario, " +
                    "NroDocumento = @NroDocumento, FechaCompra = @FechaCompra, FechaRegistro = @FechaRegistro, SubTotal = @SubTotal, Impuesto = @Impuesto, " +
                    "Total = @Total, IdEstado = @IdEstado where IdCompra = @IdCompra";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdCompra", eCompra.IdCompra);
                Cmd.Parameters.AddWithValue("@IdEmpresa", eCompra.IdEmpresa);
                Cmd.Parameters.AddWithValue("@IdEntidad", eCompra.IdProveedor);
                Cmd.Parameters.AddWithValue("@IdTipoDocumento", eCompra.IdTipoDocumento);
                Cmd.Parameters.AddWithValue("@IdUsuario", eCompra.IdUsuario);
                Cmd.Parameters.AddWithValue("@NroDocumento", eCompra.NroDocumento);
                Cmd.Parameters.AddWithValue("@FechaCompra", eCompra.FechaCompra);
                Cmd.Parameters.AddWithValue("@FechaRegistro", eCompra.FechaRegistro);
                Cmd.Parameters.AddWithValue("@SubTotal", eCompra.SubTotal);
                Cmd.Parameters.AddWithValue("@Impuesto", eCompra.Impuesto);
                Cmd.Parameters.AddWithValue("@Total", eCompra.Total);
                Cmd.Parameters.AddWithValue("@IdEstado", eCompra.IdEstado);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }

        public bool EliminarCompra(Entidades.Compra eCompra)
        {
            bool respuesta = false;

            using (SQLiteConnection Cnx = new SQLiteConnection(Settings.Default.CadenaConexion))
            {
                Cnx.Open();
                string query = "Delete from Compra where IdCompra = @IdCompra";
                SQLiteCommand Cmd = new SQLiteCommand(query, Cnx);
                Cmd.Parameters.AddWithValue("@IdCompra", eCompra.IdCompra);
                Cmd.CommandType = System.Data.CommandType.Text;

                if (Cmd.ExecuteNonQuery() < 1)
                    respuesta = false;
            }

            return respuesta;
        }
    }
}