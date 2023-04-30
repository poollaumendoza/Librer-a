using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Librería.Data.Properties;
using Librería.Entidades;

namespace Librería.Data
{
    public class Almacen
	{
		Entidades.Almacen eAlmacen = new Entidades.Almacen();
		AlmacenCollection listaAlmacen = new AlmacenCollection();
		string Cn = Settings.Default.CadenaConexion;
		SqlConnection Cnx = null;
		SqlCommand Cmd = null;
		SqlDataAdapter Da = null;
		DataTable Dt = new DataTable();

		public void AgregarAlmacen(Entidades.Almacen eAlmacen)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Almacen_AgregarAlmacen", Cnx);
			Cmd.CommandType = CommandType.StoredProcedure;
			Cmd.Parameters.AddWithValue("@NombreAlmacen", eAlmacen.NombreAlmacen);
			Cmd.Parameters.AddWithValue("@Direccion", eAlmacen.Direccion);
			Cmd.Parameters.AddWithValue("@IdEstado", eAlmacen.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EliminarAlmacen(Entidades.Almacen eAlmacen)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Almacen_EliminarAlmacen", Cnx);
			Cmd.Parameters.AddWithValue("@IdAlmacen", eAlmacen.IdAlmacen);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EditarAlmacen(Entidades.Almacen eAlmacen)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Almacen_ActualizarAlmacen", Cnx);
			Cmd.Parameters.AddWithValue("@IdAlmacen", eAlmacen.IdAlmacen);
			Cmd.Parameters.AddWithValue("@NombreAlmacen", eAlmacen.NombreAlmacen);
			Cmd.Parameters.AddWithValue("@Direccion", eAlmacen.Direccion);
			Cmd.Parameters.AddWithValue("@IdEstado", eAlmacen.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public ObservableCollection<Entidades.Almacen> ListaAlmacen()
		{
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaAlmacen.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Almacen_ObtenerAlmacen", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaAlmacen.Add(new Entidades.Almacen()
				{
					IdAlmacen = Convert.ToInt32(item[0].ToString()),
					NombreAlmacen = item[1].ToString(),
					Direccion = item[2].ToString(),
					IdEstado = Convert.ToInt32(item[3].ToString())
				});
			}
			return listaAlmacen;
		}
		public ObservableCollection<Entidades.Almacen> ListaAlmacen(Entidades.Almacen eAlmacen)
		{
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaAlmacen.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Almacen_ObtenerPorIdAlmacen", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaAlmacen.Add(new Entidades.Almacen()
				{
					IdAlmacen = Convert.ToInt32(item[0].ToString()),
					NombreAlmacen = item[1].ToString(),
					Direccion = item[2].ToString(),
					IdEstado = Convert.ToInt32(item[3].ToString())
				});
			}
			return listaAlmacen;
		}
	}
}

