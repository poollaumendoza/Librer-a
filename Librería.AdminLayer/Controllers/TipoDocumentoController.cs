using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Librería.AdminLayer.Controllers
{
    public class TipoDocumentoController : Controller
    {
        // GET: TipoDocumento
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarTipoDocumento()
        {
            List<Entidades.TipoDocumento> oLista = new List<Entidades.TipoDocumento>();
            oLista = new Negocios.TipoDocumento().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarTipoDocumento_Identidad()
        {
            List<Entidades.TipoDocumento> oLista = new List<Entidades.TipoDocumento>();
            oLista = new Negocios.TipoDocumento().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarTipoDocumento_Contable()
        {
            List<Entidades.TipoDocumento> oLista = new List<Entidades.TipoDocumento>();
            oLista = new Negocios.TipoDocumento().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTipoDocumento(Entidades.TipoDocumento objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdTipoDocumento == 0)
                resultado = new Negocios.TipoDocumento().Registrar(objeto, out mensaje);
            else
                resultado = new Negocios.TipoDocumento().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTipoDocumento(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new Negocios.TipoDocumento().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}