using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.Modelos.Sucursales;
using ThomasSalon.LN.Sucursales.Listar;

namespace ThomasSalon.UI.Controllers
{
    public class HomeController : Controller
    {
        IListarSucursalesLN _listarSucursales;
        public HomeController()
        {
            _listarSucursales = new ListarSucursalesLN();
        }

        public PartialViewResult CargarSucursales()
        {
            List<SucursalesDto> sucursales = _listarSucursales.ListarActivas();
            return PartialView("_DropdownSucursales", sucursales);
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}