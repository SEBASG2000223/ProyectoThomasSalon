using System.Collections.Generic;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Citas;
using ThomasSalon.Abstracciones.LN.Interfaces.Citas;
using ThomasSalon.Abstracciones.Modelos.Citas;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.AccesoADatos.Citas.Listar;

namespace ThomasSalon.LN.Citas.Listar
{
    public class ListarCitasLN : IListarCitasLN
    {
        IListarCitasAD _listarCitasAD;

        public ListarCitasLN()
        {
            _listarCitasAD = new ListarCitasAD();
        }
        public List<CitasDto> ListarAgendas(int idSucursal)
        {
            List<CitasDto> laListaDeCitas = _listarCitasAD.ListarAgendas(idSucursal);
            return laListaDeCitas;
        }

        public List<CitasDto> ListarCitasUsuario(int idPersona)
        {
            List<CitasDto> laListaDeCitas = _listarCitasAD.ListarCitasUsuario(idPersona);
            return laListaDeCitas;
        }

    }
}
