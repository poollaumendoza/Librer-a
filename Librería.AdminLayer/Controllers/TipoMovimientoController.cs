using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Librería.AdminLayer.Controllers
{
    public class TipoMovimientoController : Controller
    {
        // GET: TipoMovimiento
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarTipoMovimiento()
        {
            List<Entidades.TipoMovimiento> oLista = new List<Entidades.TipoMovimiento>();
            oLista = new Negocios.TipoMovimiento().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTipoMovimiento(Entidades.TipoMovimiento objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdTipoMovimiento == 0)
                resultado = new Negocios.TipoMovimiento().Registrar(objeto, out mensaje);
            else
                resultado = new Negocios.TipoMovimiento().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTipoMovimiento(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new Negocios.TipoMovimiento().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}