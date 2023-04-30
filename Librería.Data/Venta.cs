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
	public class Venta
	{
		Entidades.Venta eVenta = new Entidades.Venta();
		VentaCollection listaVenta = new VentaCollection();
		string Cn = Settings.Default.CadenaConexion;
		SqlConnection Cnx = null;
		SqlCommand Cmd = null;
		SqlDataAdapter Da = null;
		DataTable Dt = new DataTable();

		public int AgregarVenta(Entidades.Venta eVenta)
		{
            int resultado = 0;

			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Venta_AgregarVenta", Cnx);
			Cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter IdVenta = new SqlParameter();
            IdVenta.ParameterName = "@IdVenta";
            IdVenta.Direction = ParameterDirection.Output;
            IdVenta.SqlDbType = SqlDbType.Int;

            Cmd.Parameters.Add(IdVenta);
			Cmd.Parameters.AddWithValue("@IdEmpresa", eVenta.IdEmpresa);
			Cmd.Parameters.AddWithValue("@IdEntidad", eVenta.IdEntidad);
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

			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();

            return resultado = Convert.ToInt32(IdVenta.Value);
        }
		public void EliminarVenta(Entidades.Venta eVenta)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Venta_EliminarVenta", Cnx);
			Cmd.Parameters.AddWithValue("@IdVenta", eVenta.IdVenta);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EditarVenta(Entidades.Venta eVenta)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Venta_ActualizarVenta", Cnx);
			Cmd.Parameters.AddWithValue("@IdVenta", eVenta.IdVenta);
			Cmd.Parameters.AddWithValue("@IdEmpresa", eVenta.IdEmpresa);
			Cmd.Parameters.AddWithValue("@IdEntidad", eVenta.IdEntidad);
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
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public ObservableCollection<Entidades.Venta> ListaVenta()
		{
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaVenta.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Venta_ObtenerVenta", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaVenta.Add(new Entidades.Venta()
				{
					IdVenta = Convert.ToInt32(item[0].ToString()),
					IdEmpresa = Convert.ToInt32(item[1].ToString()),
					IdEntidad = Convert.ToInt32(item[2].ToString()),
					IdTipoDocumento = Convert.ToInt32(item[3].ToString()),
					IdUsuario = Convert.ToInt32(item[4].ToString()),
					IdCorrelativo = Convert.ToInt32(item[5].ToString()),
					Correlativo = item[6].ToString(),
					FechaVenta = Convert.ToDateTime(item[7].ToString()),
					FechaRegistro = Convert.ToDateTime(item[8].ToString()),
					SubTotal = Convert.ToDecimal(item[9].ToString()),
					Impuesto = Convert.ToDecimal(item[10].ToString()),
					Total = Convert.ToDecimal(item[11].ToString()),
					IdEstado = Convert.ToInt32(item[12].ToString())
				});
			}
			return listaVenta;
		}
		public ObservableCollection<Entidades.Venta> ListaVenta(Entidades.Venta eVenta)
		{
            Dt.Columns.Clear();
            Dt.Rows.Clear();
			listaVenta.Clear();

            Cmd = new SqlCommand("dbo.sp_Venta_ObtenerVentaPorIdVenta", new SqlConnection(Cn));
            Cmd.Parameters.AddWithValue("@IdVenta", eVenta.IdVenta);
            Cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(Cmd);
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaVenta.Add(new Entidades.Venta()
				{
					IdVenta = Convert.ToInt32(item[0].ToString()),
					IdEmpresa = Convert.ToInt32(item[1].ToString()),
					IdEntidad = Convert.ToInt32(item[2].ToString()),
					IdTipoDocumento = Convert.ToInt32(item[3].ToString()),
					IdUsuario = Convert.ToInt32(item[4].ToString()),
					IdCorrelativo = Convert.ToInt32(item[5].ToString()),
					Correlativo = item[6].ToString(),
					FechaVenta = Convert.ToDateTime(item[7].ToString()),
					FechaRegistro = Convert.ToDateTime(item[8].ToString()),
					SubTotal = Convert.ToDecimal(item[9].ToString()),
					Impuesto = Convert.ToDecimal(item[10].ToString()),
					Total = Convert.ToDecimal(item[11].ToString()),
					IdEstado = Convert.ToInt32(item[12].ToString())
				});
			}
			return listaVenta;
		}
	}
}