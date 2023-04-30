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
	public class TipoDocumento
	{
		Entidades.TipoDocumento eTipoDocumento = new Entidades.TipoDocumento();
		TipoDocumentoCollection listaTipoDocumento = new TipoDocumentoCollection();
		string Cn = Settings.Default.CadenaConexion;
		SqlConnection Cnx = null;
		SqlCommand Cmd = null;
		SqlDataAdapter Da = null;
		DataTable Dt = new DataTable();

		public void AgregarTipoDocumento(Entidades.TipoDocumento eTipoDocumento)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_TipoDocumento_AgregarTipoDocumento", Cnx);
			Cmd.CommandType = CommandType.StoredProcedure;
			Cmd.Parameters.AddWithValue("@IdClasificacionTipoDocumento", eTipoDocumento.IdClasificacionTipoDocumento);
			Cmd.Parameters.AddWithValue("@NombreTipoDocumento", eTipoDocumento.NombreTipoDocumento);
			Cmd.Parameters.AddWithValue("@IdEstado", eTipoDocumento.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EliminarTipoDocumento(Entidades.TipoDocumento eTipoDocumento)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_TipoDocumento_EliminarTipoDocumento", Cnx);
			Cmd.Parameters.AddWithValue("@IdTipoDocumento", eTipoDocumento.IdTipoDocumento);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EditarTipoDocumento(Entidades.TipoDocumento eTipoDocumento)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_TipoDocumento_ActualizarTipoDocumento", Cnx);
			Cmd.Parameters.AddWithValue("@IdTipoDocumento", eTipoDocumento.IdTipoDocumento);
			Cmd.Parameters.AddWithValue("@IdClasificacionTipoDocumento", eTipoDocumento.IdClasificacionTipoDocumento);
			Cmd.Parameters.AddWithValue("@NombreTipoDocumento", eTipoDocumento.NombreTipoDocumento);
			Cmd.Parameters.AddWithValue("@IdEstado", eTipoDocumento.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public ObservableCollection<Entidades.TipoDocumento> ListaTipoDocumento()
		{
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaTipoDocumento.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_TipoDocumento_ObtenerTipoDocumento", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaTipoDocumento.Add(new Entidades.TipoDocumento()
				{
					IdTipoDocumento = Convert.ToInt32(item[0].ToString()),
					IdClasificacionTipoDocumento = Convert.ToInt32(item[1].ToString()),
					NombreTipoDocumento = item[2].ToString(),
					IdEstado = Convert.ToInt32(item[3].ToString())
				});
			}
			return listaTipoDocumento;
		}
		public ObservableCollection<Entidades.TipoDocumento> ListaTipoDocumento(Entidades.TipoDocumento eTipoDocumento)
		{
			listaTipoDocumento.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_TipoDocumento_ObtenerPorIdTipoDocumento", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaTipoDocumento.Add(new Entidades.TipoDocumento()
				{
					IdTipoDocumento = Convert.ToInt32(item[0].ToString()),
					IdClasificacionTipoDocumento = Convert.ToInt32(item[1].ToString()),
					NombreTipoDocumento = item[2].ToString(),
					IdEstado = Convert.ToInt32(item[3].ToString())
				});
			}
			return listaTipoDocumento;
		}
	}
}

