using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Librería.AdminLayer.Controllers
{
    public class AlmacenController : Controller
    {
        // GET: Almacen
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarAlmacen()
        {
            List<Entidades.Almacen> oLista = new List<Entidades.Almacen>();
            oLista = new Negocios.Almacen().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarAlmacen(Entidades.Almacen objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdAlmacen == 0)
                resultado = new Negocios.Almacen().Registrar(objeto, out mensaje);
            else
                resultado = new Negocios.Almacen().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarAlmacen(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new Negocios.Almacen().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}