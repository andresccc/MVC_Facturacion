using Facturacion_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturacion_MVC.Controllers
{
    public class TBLempleadoController : Controller
    {
        // GET: TBLempleado
        public ActionResult Index()
        {
            BDFacturacion db = new BDFacturacion();

            var empleados = db.TBLEMPLEADO;

            return View(empleados.ToList());
        }

        public ActionResult Nuevo()
        {
            BDFacturacion db = new BDFacturacion();
            ViewBag.IdRolEmpleado = new SelectList(db.TBLROLES, "IdRolEmpleado", "StrDescripcion");
            return View();
        }

        [HttpPost]



    }
}