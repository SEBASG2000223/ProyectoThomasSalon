using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Servicios.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Servicios.Listar;
using ThomasSalon.Abstracciones.Modelos.Servicios;
using ThomasSalon.AccesoADatos.Servicios.Listar;

namespace ThomasSalon.LN.Servicios.Listar
{
    public class ListarServiciosLN : IListarServiciosLN
    {
        IListarServiciosAD _listarServiciosAD;

        public ListarServiciosLN()
        {
            _listarServiciosAD = new ListarServiciosAD();
        }
        public List<ServiciosDto> Listar()
        {
            List<ServiciosDto> laListaDeServicios = _listarServiciosAD.Listar();
            return laListaDeServicios;
        }

        public List<ServiciosDto> ListarActivos()
        {
            List<ServiciosDto> laListaDeServicios = _listarServiciosAD.ListarActivos();
            return laListaDeServicios;
        }
    }
}