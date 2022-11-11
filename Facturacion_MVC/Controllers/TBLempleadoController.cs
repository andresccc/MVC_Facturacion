﻿using Facturacion_MVC.Models;
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
        public ActionResult Nuevo(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BDFacturacion db = new BDFacturacion();
                    var NuevoDatos = new TBLEMPLEADO();
                    NuevoDatos.strNombre = collection["strNombre"];
                    NuevoDatos.NumDocumento = long.Parse(collection["NumDocumento"]);
                    NuevoDatos.StrDireccion = collection["StrDireccion"];
                    NuevoDatos.StrTelefono = collection["StrTelefono"];
                    NuevoDatos.StrEmail = collection["StrEmail"];
                    NuevoDatos.IdRolEmpleado = int.Parse(collection["IdRolEmpleado"]);
                    NuevoDatos.DtmIngreso = Convert.ToDateTime(collection["DtmIngreso"]);
                    NuevoDatos.DtmRetiro = Convert.ToDateTime(collection["DtmRetiro"]);
                    NuevoDatos.strDatosAdicionales = collection["strDatosAdicionales"];
                    NuevoDatos.DtmFechaModifica = DateTime.Now.Date;
                    NuevoDatos.StrUsuarioModifico = "Andrés";

                    db.TBLEMPLEADO.Add(NuevoDatos);
                    db.SaveChanges();

                    return Redirect("/TBLEmpleado/index");
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
            var DatosEmple = db.TBLEMPLEADO.Find(id);

            BDFacturacion db2 = new BDFacturacion();
            ViewBag.IdRolEmpleado = new SelectList(db2.TBLROLES, "IdRolEmpleado", "StrDescripcion", DatosEmple.IdRolEmpleado);

            return View(DatosEmple);
        }

        [HttpPost]
        public ActionResult Editar(TBLEMPLEADO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BDFacturacion db = new BDFacturacion())
                    {
                        var DatosModifi = db.TBLEMPLEADO.Find(model.IdEmpleado);
                        DatosModifi.strNombre = model.strNombre;
                        DatosModifi.NumDocumento = model.NumDocumento;
                        DatosModifi.StrDireccion = model.StrDireccion;
                        DatosModifi.StrTelefono = model.StrTelefono;
                        DatosModifi.StrEmail = model.StrEmail;
                        DatosModifi.IdRolEmpleado = model.IdRolEmpleado;
                        DatosModifi.DtmIngreso = model.DtmIngreso;
                        DatosModifi.DtmRetiro = model.DtmRetiro;
                        DatosModifi.strDatosAdicionales = model.strDatosAdicionales;
                        DatosModifi.DtmFechaModifica = DateTime.Now.Date;
                        DatosModifi.StrUsuarioModifico = "Andrés";

                        db.Entry(DatosModifi).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/TBLEmpleado/index");
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
                    var otabla = db.TBLEMPLEADO.Find(id);
                    db.TBLEMPLEADO.Remove(otabla);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return Redirect("/TBLEmpleado/index");
        }


    }
}