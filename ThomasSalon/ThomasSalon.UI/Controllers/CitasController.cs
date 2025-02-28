using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Citas;
using ThomasSalon.Abstracciones.LN.Interfaces.Citas;
using ThomasSalon.Abstracciones.Modelos.Citas;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.LN.Citas.Listar;

namespace ThomasSalon.UI.Controllers
{
    public class CitasController : Controller
    {
        IListarCitasLN _listarCitas;

        public CitasController()
        {
            _listarCitas = new ListarCitasLN();
        }

        // GET: Citas
        public ActionResult ListarAgendas(int idSucursal)
        {
            TempData["IdSucursalSeleccionada"] = idSucursal;
            List<CitasDto> citas = _listarCitas.ListarAgendas(idSucursal);
            return View(citas);
        }

        // GET: Citas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Citas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Citas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Citas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
