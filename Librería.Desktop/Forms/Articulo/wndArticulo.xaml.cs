using Librería.Desktop.Models;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Linq;
using System.Windows;

namespace Librería.Desktop.Forms.Articulo
{
    public partial class wndArticulo : MetroWindow
    {
        #region Variables
        public int Id = 0;
        #endregion
        #region Métodos
        void CargarProveedor()
        {
            using (DbLibEntities db = new DbLibEntities())
            {
                cboProveedor.ItemsSource = null;
                cboProveedor.ItemsSource = db.Entidad.ToList();
            }
        }
        void CargarEstado()
        {
            using (DbLibEntities db = new DbLibEntities())
            {
                cboEstado.ItemsSource = null;
                cboEstado.ItemsSource = db.Estado.ToList();
            }
        }
        public string ConstruirCorrelativoArticulo(string codigo)
        {
            string resultado = string.Empty, correlativo = string.Empty, ceros = "00000";
            using (DbLibEntities db = new DbLibEntities())
            {
                for (int i = 0; i < codigo.Length; i++)
                {
                    string s = codigo.Substring(i, 1);
                    bool esNum = int.TryParse(s, out int n);
                    if (esNum == false)
                        resultado += s;
                }

                var _correlativo = db.Correlativo.Where(x => x.Abreviatura == resultado).FirstOrDefault();
                correlativo = resultado + ceros.PadLeft(ceros.Length - _correlativo.ToString().Length) + _correlativo.ToString();
            }
            return correlativo;
        }
        #endregion

        public wndArticulo(int Id = 0)
        {
            InitializeComponent();

            CargarProveedor();
            CargarEstado();
            this.Id = Id;

            if (Id != 0)
                using (DbLibEntities db = new DbLibEntities())
                {
                    var articulo = db.Articulo.Find(Id);
                    txtCodigo.Text = articulo.CodigoArticulo;
                    txtDescripcion.Text = articulo.DescripcionArticulo;
                    cboProveedor.SelectedValue = articulo.IdEntidad;
                    nupCantidad.Value = articulo.Cantidad;
                    nupPrecioCompra.Value = Convert.ToDouble(articulo.PrecioCompra);
                    nupPrecioVenta.Value = Convert.ToDouble(articulo.PrecioVenta);
                    cboEstado.SelectedValue = articulo.IdEstado;
                }
        }

        private async void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var message =
                await this.ShowMessageAsync(
                    null,
                    "¿Desea guardar este registro?",
                    MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary,
                    new MetroDialogSettings()
                    {
                        AffirmativeButtonText = "Sí",
                        NegativeButtonText = "No"
                    });

            switch (message)
            {
                case MessageDialogResult.Affirmative:
                    if (Id == 0)
                    {
                        string abreviatura = txtCodigo.Text;

                        using (DbLibEntities db = new DbLibEntities())
                        {
                            if (db.Correlativo.Where(x => x.Abreviatura == abreviatura).ToList().Count().Equals(0))
                            {
                                Models.Correlativo correlativo = new Correlativo()
                                {
                                    IdEmpresa = App.IdEmpresa,
                                    IdTipoDocumento = 0,
                                    NombreTabla = "ARTICULO",
                                    Abreviatura = abreviatura,
                                    Serie = "-",
                                    NroCorrelativo = 1,
                                    IdEstado = 1
                                };
                                db.Correlativo.Add(correlativo);
                                db.SaveChanges();
                            }
                            else
                            {
                                var c1 = db.Correlativo.Where(x => x.NombreTabla == "ARTICULO").Where(y => y.Abreviatura == abreviatura).FirstOrDefault();
                                Models.Correlativo correlativo = new Models.Correlativo() { NroCorrelativo = c1.NroCorrelativo + 1 };
                                db.Entry(correlativo).State = System.Data.Entity.EntityState.Modified;
                            }
                        }

                        using (DbLibEntities db = new DbLibEntities())
                        {
                            Models.Articulo articulo = new Models.Articulo()
                            {
                                IdEmpresa = App.IdEmpresa,
                                CodigoArticulo = ConstruirCorrelativoArticulo(txtCodigo.Text),
                                DescripcionArticulo = txtDescripcion.Text,
                                IdEntidad = Convert.ToInt32(cboProveedor.SelectedValue),
                                Cantidad = Convert.ToInt32(nupCantidad.Value),
                                PrecioCompra = Convert.ToDecimal(nupPrecioCompra.Value),
                                PrecioVenta = Convert.ToDecimal(nupPrecioVenta.Value),
                                IdEstado = Convert.ToInt32(cboEstado.SelectedValue)
                            };
                            db.Articulo.Add(articulo);
                            db.SaveChanges();
                        }
                        App.Resultado = true;
                        message = await this.ShowMessageAsync(null, "Registro guardado correctamente", MessageDialogStyle.Affirmative);
                    }
                    else
                    {
                        using (DbLibEntities db = new DbLibEntities())
                        {
                            var articulo = db.Articulo.Find(Id);
                            articulo.CodigoArticulo = txtCodigo.Text;
                            articulo.DescripcionArticulo = txtDescripcion.Text;
                            articulo.IdEntidad = Convert.ToInt32(cboProveedor.SelectedValue);
                            articulo.Cantidad = Convert.ToInt32(nupCantidad.Value);
                            articulo.PrecioCompra = Convert.ToDecimal(nupPrecioCompra.Value);
                            articulo.PrecioVenta = Convert.ToDecimal(nupPrecioVenta.Value);
                            articulo.IdEstado = Convert.ToInt32(cboEstado.SelectedValue);
                            db.Entry(articulo).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        };
                        message = await this.ShowMessageAsync(null, "Registro actualizado correctamente", MessageDialogStyle.Affirmative);
                        Close();
                    }
                    break;
                case MessageDialogResult.Negative:
                    Close();
                    break;
                case MessageDialogResult.Canceled:
                    return;
                default:
                    break;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}