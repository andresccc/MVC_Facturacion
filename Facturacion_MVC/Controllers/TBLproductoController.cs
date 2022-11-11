using Facturacion_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturacion_MVC.Controllers
{
    public class TBLproductoController : Controller
    {
        // GET: TBLproducto
        public ActionResult Index()
        {
            BDFacturacion db = new BDFacturacion();
            ViewBag.IdCategoria = new SelectList(db.TBLCATEGORIA_PROD, "IdCategoria", "StrDescripcion");

            var productos = db.TBLPRODUCTO;

            return View(productos.ToList());
        }

        public ActionResult Nuevo()
        {
            BDFacturacion db = new BDFacturacion();
            ViewBag.IdCategoria = new SelectList(db.TBLCATEGORIA_PROD, "IdCategoria", "StrDescripcion");

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
                    var NuevoDatos = new TBLPRODUCTO();
                    NuevoDatos.StrNombre = collection["StrNombre"];
                    NuevoDatos.StrCodigo = collection["StrCodigo"];
                    NuevoDatos.NumPrecioCompra = long.Parse(collection["NumPrecioCompra"]);
                    NuevoDatos.NumPrecioVenta = long.Parse(collection["NumPrecioVenta"]);
                    NuevoDatos.IdCategoria = int.Parse(collection["IdCategoria"]);
                    NuevoDatos.StrDetalle = collection["StrDetalle"];
                    NuevoDatos.strFoto = collection["strFoto"];
                    NuevoDatos.NumStock = int.Parse(collection["NumStock"]);
                    NuevoDatos.DtmFechaModifica = DateTime.Now.Date;
                    NuevoDatos.StrUsuarioModifica = "Andrés";

                    db.TBLPRODUCTO.Add(NuevoDatos);
                    db.SaveChanges();

                    return Redirect("/TBLproducto/index");
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
            var DatosProd = db.TBLPRODUCTO.Find(id);

            BDFacturacion db2 = new BDFacturacion();
            ViewBag.IdCategoria = new SelectList(db2.TBLCATEGORIA_PROD, "IdCategoria", "StrDescripcion", DatosProd.IdCategoria);

            return View(DatosProd);
        }

        [HttpPost]
        public ActionResult Editar(TBLPRODUCTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BDFacturacion db = new BDFacturacion())
                    {
                        var DatosModifi = db.TBLPRODUCTO.Find(model.IdProducto);
                        DatosModifi.StrNombre = model.StrNombre;
                        DatosModifi.StrCodigo = model.StrCodigo;
                        DatosModifi.NumPrecioCompra = model.NumPrecioCompra;
                        DatosModifi.NumPrecioVenta = model.NumPrecioVenta;
                        DatosModifi.IdCategoria = model.IdCategoria;
                        DatosModifi.StrDetalle = model.StrDetalle;
                        DatosModifi.strFoto = model.strFoto;
                        DatosModifi.NumStock = model.NumStock;
                        DatosModifi.DtmFechaModifica = DateTime.Now.Date;
                        DatosModifi.StrUsuarioModifica = "Andrés";

                        db.Entry(DatosModifi).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/TBLproducto/index");
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
                    var otabla = db.TBLPRODUCTO.Find(id);
                    db.TBLPRODUCTO.Remove(otabla);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Redirect("/TBLproducto/index");
        }




    }
}