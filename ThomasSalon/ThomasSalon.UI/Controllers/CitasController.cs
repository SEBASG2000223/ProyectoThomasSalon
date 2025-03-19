using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.Citas;
using ThomasSalon.Abstracciones.LN.Interfaces.Citas.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.Citas;
using ThomasSalon.LN.Citas.Listar;
using ThomasSalon.LN.Citas.ObtenerPorId;

namespace ThomasSalon.UI.Controllers
{
    public class CitasController : Controller
    {
        IListarCitasLN _listarCitas;
        IObtenerCitaPorIdLN _obtenerCitaPorIdLN;

        public CitasController()
        {
            _listarCitas = new ListarCitasLN();
            _obtenerCitaPorIdLN = new ObtenerCitaPorIdLN();
        }
        // GET: Citas
        public ActionResult ListarAgendas(int idSucursal)
        {
            TempData["IdSucursalSeleccionada"] = idSucursal;
            List<CitasDto> citas = _listarCitas.ListarAgendas(idSucursal);

            return View(citas);
        }

        public JsonResult ObtenerEventos(int idSucursal)
        {
            var eventos = _listarCitas.ListarAgendas(idSucursal) // Método que obtiene citas de la BD
                .Select(cita => new
                {
                    title = cita.nombrePersona, // El nombre del usuario o lo que desees mostrar como título del evento
                    start = cita.FechaHora.ToString("yyyy-MM-ddTHH:mm:ss"),
                    end = cita.FechaHora.ToString("yyyy-MM-ddTHH:mm:ss")
                }).ToList();

            return Json(eventos, JsonRequestBehavior.AllowGet);
        }

        // GET: Citas
        public ActionResult AgendarUsuario()
        {
            
          

            return View();
        }



        // GET: Citas/Details/5
        public ActionResult DetallesCita(Guid IdCita)
        {
            CitasDto cita = _obtenerCitaPorIdLN.DetallesCita(IdCita).FirstOrDefault();
            var idSucursal = Convert.ToInt32(TempData["IdSucursalSeleccionada"] ?? 0);

            return View(cita); 
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
