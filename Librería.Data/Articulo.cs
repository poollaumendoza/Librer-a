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
	public class Articulo
	{
		Entidades.Articulo eArticulo = new Entidades.Articulo();
		ArticuloCollection listaArticulo = new ArticuloCollection();
		string Cn = Settings.Default.CadenaConexion;
		SqlConnection Cnx = null;
		SqlCommand Cmd = null;
		SqlDataAdapter Da = null;
		DataTable Dt = new DataTable();

		public void AgregarArticulo(Entidades.Articulo eArticulo)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Articulo_AgregarArticulo", Cnx);
			Cmd.CommandType = CommandType.StoredProcedure;
			Cmd.Parameters.AddWithValue("@IdEmpresa", eArticulo.IdEmpresa);
			Cmd.Parameters.AddWithValue("@IdEntidad", eArticulo.IdEntidad);
			Cmd.Parameters.AddWithValue("@CodigoArticulo", eArticulo.CodigoArticulo);
			Cmd.Parameters.AddWithValue("@DescripcionArticulo", eArticulo.DescripcionArticulo);
			Cmd.Parameters.AddWithValue("@Cantidad", eArticulo.Cantidad);
			Cmd.Parameters.AddWithValue("@PrecioCompra", eArticulo.PrecioCompra);
			Cmd.Parameters.AddWithValue("@PrecioVenta", eArticulo.PrecioVenta);
			Cmd.Parameters.AddWithValue("@IdEstado", eArticulo.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EliminarArticulo(Entidades.Articulo eArticulo)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Articulo_EliminarArticulo", Cnx);
			Cmd.Parameters.AddWithValue("@IdArticulo", eArticulo.IdArticulo);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public void EditarArticulo(Entidades.Articulo eArticulo)
		{
			Cnx = new SqlConnection(Cn);
			Cmd = new SqlCommand("dbo.sp_Articulo_ActualizarArticulo", Cnx);
			Cmd.Parameters.AddWithValue("@IdArticulo", eArticulo.IdArticulo);
			Cmd.Parameters.AddWithValue("@IdEmpresa", eArticulo.IdEmpresa);
			Cmd.Parameters.AddWithValue("@IdEntidad", eArticulo.IdEntidad);
			Cmd.Parameters.AddWithValue("@CodigoArticulo", eArticulo.CodigoArticulo);
			Cmd.Parameters.AddWithValue("@DescripcionArticulo", eArticulo.DescripcionArticulo);
			Cmd.Parameters.AddWithValue("@Cantidad", eArticulo.Cantidad);
			Cmd.Parameters.AddWithValue("@PrecioCompra", eArticulo.PrecioCompra);
			Cmd.Parameters.AddWithValue("@PrecioVenta", eArticulo.PrecioVenta);
			Cmd.Parameters.AddWithValue("@IdEstado", eArticulo.IdEstado);
			Cnx.Open();
			Cmd.ExecuteNonQuery();
			Cnx.Close();
		}
		public ObservableCollection<Entidades.Articulo> ListaArticulo()
		{
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaArticulo.Clear();
			
			Da = new SqlDataAdapter(new SqlCommand("dbo.sp_Articulo_ObtenerArticulo", new SqlConnection(Cn)));
			Da.Fill(Dt);
			
			var query = (from a in Dt.Rows.Cast<DataRow>()
					select a).ToList();
			
			foreach (var item in query)
			{
				listaArticulo.Add(new Entidades.Articulo()
				{
					IdArticulo = Convert.ToInt32(item[0].ToString()),
					IdEmpresa = Convert.ToInt32(item[1].ToString()),
					IdEntidad = Convert.ToInt32(item[2].ToString()),
					CodigoArticulo = item[3].ToString(),
					DescripcionArticulo = item[4].ToString(),
					Cantidad = Convert.ToInt32(item[5].ToString()),
					PrecioCompra = Convert.ToDecimal(item[6].ToString()),
					PrecioVenta = Convert.ToDecimal(item[7].ToString()),
					IdEstado = Convert.ToInt32(item[8].ToString())
				});
			}
			return listaArticulo;
		}
		public ObservableCollection<Entidades.Articulo> ListaArticulo(Entidades.Articulo eArticulo)
		{
            Dt.Rows.Clear();
            Dt.Columns.Clear();
            listaArticulo.Clear();
			
            if(eArticulo.IdArticulo != 0)
            {
                Cmd = new SqlCommand("dbo.sp_Articulo_ObtenerArticuloPorIdArticulo", new SqlConnection(Cn));
                Cmd.Parameters.AddWithValue("@IdArticulo", eArticulo.IdArticulo);
                Cmd.CommandType = CommandType.StoredProcedure;
                Da = new SqlDataAdapter(Cmd);
                Da.Fill(Dt);

                var query = (from a in Dt.Rows.Cast<DataRow>()
                             select a).ToList();

                foreach (var item in query)
                {
                    listaArticulo.Add(new Entidades.Articulo()
                    {
                        IdArticulo = Convert.ToInt32(item[0].ToString()),
                        IdEmpresa = Convert.ToInt32(item[1].ToString()),
                        IdEntidad = Convert.ToInt32(item[2].ToString()),
                        CodigoArticulo = item[3].ToString(),
                        DescripcionArticulo = item[4].ToString(),
                        Cantidad = Convert.ToInt32(item[5].ToString()),
                        PrecioCompra = Convert.ToDecimal(item[6].ToString()),
                        PrecioVenta = Convert.ToDecimal(item[7].ToString()),
                        IdEstado = Convert.ToInt32(item[8].ToString())
                    });
                }
            }
            if(eArticulo.IdEntidad != 0)
            {
                Cmd = new SqlCommand("dbo.sp_Articulo_ObtenerArticuloPorIdEntidad", new SqlConnection(Cn));
                Cmd.Parameters.Clear();
                Cmd.Parameters.AddWithValue("@IdEntidad", eArticulo.IdEntidad);
                Cmd.CommandType = CommandType.StoredProcedure;
                Da = new SqlDataAdapter(Cmd);
                Da.Fill(Dt);

                var query = (from a in Dt.Rows.Cast<DataRow>()
                             select a).ToList();

                foreach (var item in query)
                {
                    listaArticulo.Add(new Entidades.Articulo()
                    {
                        IdArticulo = Convert.ToInt32(item[0].ToString()),
                        IdEmpresa = Convert.ToInt32(item[1].ToString()),
                        IdEntidad = Convert.ToInt32(item[2].ToString()),
                        CodigoArticulo = item[3].ToString(),
                        DescripcionArticulo = item[4].ToString(),
                        Cantidad = Convert.ToInt32(item[5].ToString()),
                        PrecioCompra = Convert.ToDecimal(item[6].ToString()),
                        PrecioVenta = Convert.ToDecimal(item[7].ToString()),
                        IdEstado = Convert.ToInt32(item[8].ToString())
                    });
                }
            }
            if(eArticulo.DescripcionArticulo != string.Empty)
            {
                Cmd = new SqlCommand("dbo.sp_Articulo_ObtenerArticuloPorDescripcion", new SqlConnection(Cn));
                Cmd.Parameters.Clear();
                Cmd.Parameters.AddWithValue("@Descripcion", eArticulo.DescripcionArticulo);
                Cmd.CommandType = CommandType.StoredProcedure;
                Da = new SqlDataAdapter(Cmd);
                Da.Fill(Dt);

                var query = (from a in Dt.Rows.Cast<DataRow>()
                             select a).ToList();

                foreach (var item in query)
                {
                    listaArticulo.Add(new Entidades.Articulo()
                    {
                        IdArticulo = Convert.ToInt32(item[0].ToString()),
                        IdEmpresa = Convert.ToInt32(item[1].ToString()),
                        IdEntidad = Convert.ToInt32(item[2].ToString()),
                        CodigoArticulo = item[3].ToString(),
                        DescripcionArticulo = item[4].ToString(),
                        Cantidad = Convert.ToInt32(item[5].ToString()),
                        PrecioCompra = Convert.ToDecimal(item[6].ToString()),
                        PrecioVenta = Convert.ToDecimal(item[7].ToString()),
                        IdEstado = Convert.ToInt32(item[8].ToString())
                    });
                }
            }
			
			return listaArticulo;
		}
	}
}