using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Deducciones;
using ThomasSalon.Abstracciones.LN.Interfaces.Deducciones.Agregar;
using ThomasSalon.Abstracciones.LN.Interfaces.Pagos.Listar;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;
using ThomasSalon.Abstracciones.Modelos.Deducciones;
using ThomasSalon.Abstracciones.Modelos.Pagos;
using ThomasSalon.LN.Colaboradores.Listar;
using ThomasSalon.LN.Deducciones.Agregar;
using ThomasSalon.LN.Deducciones.Listar;

namespace ThomasSalon.UI.Controllers
{
    public class DeduccionesController : Controller
    {
        IListarColaboradoresLN _listarColaboradores;
        IListarDeduccionesLN _listarDeducciones;
        IAgregarDeduccionLN _crearDeduccion;
        IListarPagosLN _listarPagosLN;

        public DeduccionesController()
        {
            _listarColaboradores = new ListarColaboradoresLN();
            _listarDeducciones = new ListarDeduccionesLN();
            _crearDeduccion = new AgregarDeduccionLN();
            _listarPagosLN = new ListarPagosLN();
        }
        public ActionResult ListarDeduccionesColaborador(int idColaborador)
        {
            try
            {
                List<DeduccionesDto> deducciones = _listarDeducciones.ListarDeduccionesUsuario(idColaborador);

                if (deducciones == null || !deducciones.Any())
                {
                    ViewBag.NoDeducciones = "No se encuentran deducciones para este trabajador.";

                    deducciones = new List<DeduccionesDto>
        {
            new DeduccionesDto { IdColaborador = idColaborador }
        };
                }
                else
                {
                    foreach (var deduccion in deducciones)
                    {
                        deduccion.IdColaborador = idColaborador;
                    }
                }

                return View(deducciones);
            }
            catch (Exception ex)
            {
                return RedirectToAction("ListarColaboradores", "Deducciones");
            }
        }

        public ActionResult ListarColaboradores()
        {
            List<ColaboradoresDto> laListaDeColaboradores = _listarColaboradores.ListarActivos();
            return View(laListaDeColaboradores);
        }

        public async Task<ActionResult> ListarPagos(int idColaborador)
        {
            List<PagosDto> laListaDePagos = await _listarPagosLN.ListarPagos(idColaborador);
            

            return View(laListaDePagos);
        }


        // Acción para confirmar el pago del colaborador
        [HttpPost]
        public async Task<ActionResult> ConfirmarPago(int idColaborador)
        {
            try
            {
                // Llamar al método para confirmar el pago en el acceso a datos
                await _listarPagosLN.ConfirmarPago(idColaborador);

                // Después de confirmar el pago, redirigir de vuelta a la lista de pagos
                return RedirectToAction("ListarColaboradores", "Deducciones");
            }
            catch (Exception ex)
            {
                // Manejar el error, si ocurre
                ModelState.AddModelError("", "Hubo un error al confirmar el pago.");
                return View();
            }
        }






        // GET: InventarioSucursal/AgregarInventarioSucursal
        public ActionResult Agregar(int idColaborador)
        {
            ViewBag.IdColaborador = idColaborador;

            var deduccionDto = new DeduccionesDto
            {
                IdColaborador = idColaborador,  
                                                
            };
            return View(deduccionDto);
        }



        // POST: InventarioSucursal/AgregarInventarioSucursal
        [HttpPost]
        public async Task<ActionResult> Agregar(DeduccionesDto modelo)
        {
            try
            {
                int cantidadDeDatosGuardados = await _crearDeduccion.Agregar(modelo);
                return RedirectToAction("ListarColaboradores", "Deducciones");
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.Mensaje = ex.Message;

                return RedirectToAction("ListarColaboradores", "Deducciones");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;

                return RedirectToAction("ListarColaboradores", "Deducciones");
            }
        }

        // GET: Deducciones/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Deducciones/Edit/5
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

        // GET: Deducciones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Deducciones/Delete/5
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
