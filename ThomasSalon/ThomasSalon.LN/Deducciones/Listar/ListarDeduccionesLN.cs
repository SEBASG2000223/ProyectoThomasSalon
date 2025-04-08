using System.Collections.Generic;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Deducciones.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Deducciones;
using ThomasSalon.Abstracciones.Modelos.Citas;
using ThomasSalon.Abstracciones.Modelos.Deducciones;
using ThomasSalon.AccesoADatos.Deducciones.Listar;

namespace ThomasSalon.LN.Deducciones.Listar
{
    public class ListarDeduccionesLN : IListarDeduccionesLN
    {
        IListarDeduccionesAD _listarDeduccionesAD;

        public ListarDeduccionesLN()
        {
            _listarDeduccionesAD = new ListarDeduccionesAD();
        }
        public List<DeduccionesDto> ListarDeduccionesUsuario(int idColaborador)
        {
            List<DeduccionesDto> laListaDeDeducciones = _listarDeduccionesAD.ListarDeduccionesUsuario(idColaborador);
            return laListaDeDeducciones;
        }
    }
}
