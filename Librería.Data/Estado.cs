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
	public class Estado
	{
		Entidades.Estado eEstado = new Entidades.Estado();
		EstadoCollection listaEstado = new EstadoCollection();
		string Cn = Settings.Default.CadenaConexion;
		SqlConnection Cnx = null;
		SqlCommand Cmd = null;
		SqlDataAdapter Da = null;
		DataTable Dt = new DataTable();

		public void AgregarEstado(Entidades.Estado eEstado)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Estado_AgregarEstado", Cnx);
			Cmd.CommandType = CommandType.StoredProcedure;
			Cmd.Parameters.AddWithValue("@NombreEstado", eEstado.NombreEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EliminarEstado(Entidades.Estado eEstado)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Estado_EliminarEstado", Cnx);
			Cmd.Parameters.AddWithValue("@IdEstado", eEstado.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EditarEstado(Entidades.Estado eEstado)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Estado_ActualizarEstado", Cnx);
			Cmd.Parameters.AddWithValue("@IdEstado", eEstado.IdEstado);
			Cmd.Parameters.AddWithValue("@NombreEstado", eEstado.NombreEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public ObservableCollection<Entidades.Estado> ListaEstado()
		{
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaEstado.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Estado_ObtenerEstado", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaEstado.Add(new Entidades.Estado()
				{
					IdEstado = Convert.ToInt32(item[0].ToString()),
					NombreEstado = item[1].ToString()
				});
			}
			return listaEstado;
		}
		public ObservableCollection<Entidades.Estado> ListaEstado(Entidades.Estado eEstado)
		{
			listaEstado.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Estado_ObtenerPorIdEstado", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaEstado.Add(new Entidades.Estado()
				{
					IdEstado = Convert.ToInt32(item[0].ToString()),
					NombreEstado = item[1].ToString()
				});
			}
			return listaEstado;
		}
	}
}

