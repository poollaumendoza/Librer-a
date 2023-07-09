using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Librería.AdminLayer.Controllers
{
    public class ClasificacionTipoDocumentoController : Controller
    {
        // GET: ClasificacionTipoDocumento
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarClasificacionTipoDocumento()
        {
            List<Entidades.ClasificacionTipoDocumento> oLista = new List<Entidades.ClasificacionTipoDocumento>();
            oLista = new Negocios.ClasificacionTipoDocumento().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarClasificacionTipoDocumento(Entidades.ClasificacionTipoDocumento objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdClasificacionTipoDocumento == 0)
                resultado = new Negocios.ClasificacionTipoDocumento().Registrar(objeto, out mensaje);
            else
                resultado = new Negocios.ClasificacionTipoDocumento().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarClasificacionTipoDocumento(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new Negocios.ClasificacionTipoDocumento().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}