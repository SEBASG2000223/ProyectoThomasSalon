using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.CambiarEstado;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.Abstracciones.Modelos.Usuarios;
using ThomasSalon.LN.Productos.CambiarEstado;
using ThomasSalon.LN.Productos.Editar;
using ThomasSalon.LN.Productos.Listar;
using ThomasSalon.LN.Productos.ObtenerPorId;
using ThomasSalon.LN.Productos.Registrar;
using ThomasSalon.LN.Proveedores.Listar;
using ThomasSalon.LN.Sucursales.Listar;
using ThomasSalon.LN.Usuarios.CambiarEstado;
using ThomasSalon.LN.Usuarios.Editar;
using ThomasSalon.LN.Usuarios.Listar;
using ThomasSalon.LN.Usuarios.ObtenerPorId;
using ThomasSalon.UI.Models;

namespace ThomasSalon.UI.Controllers
{
    public class UsuariosController : Controller
    {

        IListarUsuariosLN _listarUsuarios;
        IEditarUsuariosLN _editarUsuarios;
        ICambiarEstadoUsuariosLN _cambiarEstadoUsuariosLN;
        IObtenerUsuariosPorIdLN _obtenerUsuariosPorId;
        IListarSucursalesLN _listarSucursales;
       
        public UsuariosController()
        {
            _listarUsuarios = new ListarUsuariosLN();
            _editarUsuarios = new EditarUsuariosLN();
            _cambiarEstadoUsuariosLN = new CambiarEstadoUsuariosLN();
            _obtenerUsuariosPorId = new ObtenerUsuariosPorIdLN();
            _listarSucursales = new ListarSucursalesLN();
        }

        // GET: Usuarios
        public ActionResult ListarUsuarios()
        {
            List<UsuariosDto> laListaDeUsuarios = _listarUsuarios.Listar();
            return View(laListaDeUsuarios);
        }
        // GET: Usuarios
        public ActionResult ListarGerentes()
        {
            List<UsuariosDto> laListaDeUsuarios = _listarUsuarios.ListarGerentes();
            return View(laListaDeUsuarios);
        }
        // parcial
        public ActionResult ListarGerentesParcial()
        {
            List<UsuariosDto> laListaDeUsuarios = _listarUsuarios.ListarGerentes();
            return PartialView("_ListarGerentes", laListaDeUsuarios);
        }
        // GET: Usuarios
        public ActionResult ListarSoloUsuarios()
        {
            List<UsuariosDto> laListaDeUsuarios = _listarUsuarios.ListarUsuarios();
            return View(laListaDeUsuarios);
        }
        // GET: Usuarios
        public ActionResult ListarSoloUsuariosParcial()
        {
            List<UsuariosDto> laListaDeUsuarios = _listarUsuarios.ListarUsuarios();
            return PartialView("_ListarSoloUsuarios", laListaDeUsuarios);
        }
        // GET: Usuarios
        public ActionResult ListarAdministradores()
        {
            List<UsuariosDto> laListaDeUsuarios = _listarUsuarios.ListarAdministradores();
            return View(laListaDeUsuarios);
        }
        // GET: Usuarios
        public ActionResult ListarAdministradoresParcial()
        {
            List<UsuariosDto> laListaDeUsuarios = _listarUsuarios.ListarAdministradores();
            return PartialView("_ListarAdministradores", laListaDeUsuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
     
        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
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

        // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {
           

            UsuariosDto elUsuario = _obtenerUsuariosPorId.Obtener(id);
            return View(elUsuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(UsuariosDto elUsuario)
        {
            try
            {
                int cantidadDeDatosEditados = await _editarUsuarios.Editar(elUsuario);

                return RedirectToAction("ListarUsuarios");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
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
        public async Task<ActionResult> Activar(string id)
        {

            int resultado = await _cambiarEstadoUsuariosLN.CambiarEstado(id, 1);

            return RedirectToAction("ListarUsuarios");




        }

        public async Task<ActionResult> Inactivar(string id)
        {

            int resultado = await _cambiarEstadoUsuariosLN.CambiarEstado(id, 2);
            return RedirectToAction("ListarUsuarios");



        }
    }
}
