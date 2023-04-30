using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Librería.Entidades;
using Librería.Data.Properties;

namespace Librería.Data
{
	public class Compra
	{
		Entidades.Compra eCompra = new Entidades.Compra();
		CompraCollection listaCompra = new CompraCollection();
		string Cn = Settings.Default.CadenaConexion;
		SqlConnection Cnx = null;
		SqlCommand Cmd = null;
		SqlDataAdapter Da = null;
		DataTable Dt = new DataTable();

		public int AgregarCompra(Entidades.Compra eCompra)
		{
            int resultado = 0;

			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Compra_AgregarCompra", Cnx);
			Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter IdCompra = new SqlParameter();
            IdCompra.ParameterName = "@IdCompra";
            IdCompra.Direction = ParameterDirection.Output;
            IdCompra.SqlDbType = SqlDbType.Int;

            Cmd.Parameters.Add(IdCompra);
            Cmd.Parameters.AddWithValue("@IdEmpresa", eCompra.IdEmpresa);
			Cmd.Parameters.AddWithValue("@IdEntidad", eCompra.IdEntidad);
			Cmd.Parameters.AddWithValue("@IdTipoDocumento", eCompra.IdTipoDocumento);
			Cmd.Parameters.AddWithValue("@IdUsuario", eCompra.IdUsuario);
			Cmd.Parameters.AddWithValue("@NroDocumento", eCompra.NroDocumento);
			Cmd.Parameters.AddWithValue("@FechaCompra", eCompra.FechaCompra);
			Cmd.Parameters.AddWithValue("@FechaRegistro", eCompra.FechaRegistro);
			Cmd.Parameters.AddWithValue("@SubTotal", eCompra.SubTotal);
			Cmd.Parameters.AddWithValue("@Impuesto", eCompra.Impuesto);
			Cmd.Parameters.AddWithValue("@Total", eCompra.Total);
			Cmd.Parameters.AddWithValue("@IdEstado", eCompra.IdEstado);

			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();

            resultado = Convert.ToInt32(IdCompra.Value);

            return resultado;
		}
		public void EliminarCompra(Entidades.Compra eCompra)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Compra_EliminarCompra", Cnx);
			Cmd.Parameters.AddWithValue("@IdCompra", eCompra.IdCompra);
            Cmd.CommandType = CommandType.StoredProcedure;
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EditarCompra(Entidades.Compra eCompra)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Compra_ActualizarCompra", Cnx);
			Cmd.Parameters.AddWithValue("@IdCompra", eCompra.IdCompra);
			Cmd.Parameters.AddWithValue("@IdEmpresa", eCompra.IdEmpresa);
			Cmd.Parameters.AddWithValue("@IdEntidad", eCompra.IdEntidad);
			Cmd.Parameters.AddWithValue("@IdTipoDocumento", eCompra.IdTipoDocumento);
			Cmd.Parameters.AddWithValue("@IdUsuario", eCompra.IdUsuario);
			Cmd.Parameters.AddWithValue("@NroDocumento", eCompra.NroDocumento);
			Cmd.Parameters.AddWithValue("@FechaCompra", eCompra.FechaCompra);
			Cmd.Parameters.AddWithValue("@FechaRegistro", eCompra.FechaRegistro);
			Cmd.Parameters.AddWithValue("@SubTotal", eCompra.SubTotal);
			Cmd.Parameters.AddWithValue("@Impuesto", eCompra.Impuesto);
			Cmd.Parameters.AddWithValue("@Total", eCompra.Total);
			Cmd.Parameters.AddWithValue("@IdEstado", eCompra.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public ObservableCollection<Entidades.Compra> ListaCompra()
		{
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaCompra.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Compra_ObtenerCompra", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaCompra.Add(new Entidades.Compra()
				{
					IdCompra = Convert.ToInt32(item[0].ToString()),
					IdEmpresa = Convert.ToInt32(item[1].ToString()),
					IdEntidad = Convert.ToInt32(item[2].ToString()),
					IdTipoDocumento = Convert.ToInt32(item[3].ToString()),
					IdUsuario = Convert.ToInt32(item[4].ToString()),
					NroDocumento = item[5].ToString(),
					FechaCompra = Convert.ToDateTime(item[6].ToString()),
					FechaRegistro = Convert.ToDateTime(item[7].ToString()),
					SubTotal = Convert.ToDecimal(item[8].ToString()),
					Impuesto = Convert.ToDecimal(item[9].ToString()),
					Total = Convert.ToDecimal(item[10].ToString()),
					IdEstado = Convert.ToInt32(item[11].ToString())
				});
			}
			return listaCompra;
		}
		public ObservableCollection<Entidades.Compra> ListaCompra(Entidades.Compra eCompra)
		{
            Dt.Rows.Clear();
            Dt.Columns.Clear();
			listaCompra.Clear();

            Cmd = new SqlCommand("dbo.sp_Compra_ObtenerCompraPorIdCompra", new SqlConnection(Cn));
            Cmd.Parameters.AddWithValue("@IdCompra", eCompra.IdCompra);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaCompra.Add(new Entidades.Compra()
				{
					IdCompra = Convert.ToInt32(item[0].ToString()),
					IdEmpresa = Convert.ToInt32(item[1].ToString()),
					IdEntidad = Convert.ToInt32(item[2].ToString()),
					IdTipoDocumento = Convert.ToInt32(item[3].ToString()),
					IdUsuario = Convert.ToInt32(item[4].ToString()),
					NroDocumento = item[5].ToString(),
					FechaCompra = Convert.ToDateTime(item[6].ToString()),
					FechaRegistro = Convert.ToDateTime(item[7].ToString()),
					SubTotal = Convert.ToDecimal(item[8].ToString()),
					Impuesto = Convert.ToDecimal(item[9].ToString()),
					Total = Convert.ToDecimal(item[10].ToString()),
					IdEstado = Convert.ToInt32(item[11].ToString())
				});
			}
			return listaCompra;
		}
	}
}

