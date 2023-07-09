using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Librería.AdminLayer.Controllers
{
    public class EstadoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarEstados()
        {
            List<Entidades.Estado> oLista = new List<Entidades.Estado>();
            oLista = new Negocios.Estado().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarEstado(Entidades.Estado objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdEstado == 0)
                resultado = new Negocios.Estado().Registrar(objeto, out mensaje);
            else
                resultado = new Negocios.Estado().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarEstado(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new Negocios.Estado().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}