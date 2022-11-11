using Facturacion_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturacion_MVC.Controllers
{
    public class TBLclienteController : Controller
    {
        // GET: TBLcliente
        public ActionResult Index()
        {
            BDFacturacion db = new BDFacturacion();
            var clientes = db.TBLCLIENTES;

            return View(clientes.ToList());
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BDFacturacion db = new BDFacturacion();
                    var NuevoDatos = new TBLCLIENTES();
                    NuevoDatos.StrNombre = collection["StrNombre"];
                    NuevoDatos.NumDocumento = long.Parse(collection["NumDocumento"]);
                    NuevoDatos.StrDireccion = collection["StrDireccion"];
                    NuevoDatos.StrTelefono = collection["StrTelefono"];
                    NuevoDatos.StrEmail = collection["StrEmail"];
                    NuevoDatos.DtmFechaModifica = DateTime.Now.Date;
                    NuevoDatos.StrUsuarioModifica = "Andrés";

                    db.TBLCLIENTES.Add(NuevoDatos);
                    db.SaveChanges();

                    return Redirect("/TBLcliente/index");
                }
                return View(collection);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            BDFacturacion db = new BDFacturacion();
            var DatosClien = db.TBLCLIENTES.Find(id);


            return View(DatosClien);
        }

        [HttpPost]
        public ActionResult Editar(TBLCLIENTES model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BDFacturacion db = new BDFacturacion())
                    {
                        var DatosModifi = db.TBLCLIENTES.Find(model.IdCliente);

                        DatosModifi.StrNombre = model.StrNombre;
                        DatosModifi.NumDocumento = model.NumDocumento;
                        DatosModifi.StrDireccion = model.StrDireccion;
                        DatosModifi.StrTelefono = model.StrTelefono;
                        DatosModifi.StrEmail = model.StrEmail;
                        DatosModifi.DtmFechaModifica = DateTime.Now.Date;
                        DatosModifi.StrUsuarioModifica = "Andrés";

                        db.Entry(DatosModifi).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/TBLcliente/index");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Borrar(int id)
        {
            try
            {
                using (BDFacturacion db = new BDFacturacion())
                {
                    var otabla = db.TBLCLIENTES.Find(id);
                    db.TBLCLIENTES.Remove(otabla);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return Redirect("/TBLcliente/index");
        }


    }
}