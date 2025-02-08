using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Colaboradores;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.Editar;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;
using ThomasSalon.AccesoADatos.Colaboradores.Editar;
using ThomasSalon.LN.General.Conversiones.Colaboradores;

namespace ThomasSalon.LN.Colaboradores.Editar
{
    public class EditarColaboradoresLN : IEditarColaboradoresLN
    {
        IEditarColaboradoresAD _editarColaboradoresAD;
        IConvertirAColaboradoresTabla _convertirAColaboradoresTabla;

        public EditarColaboradoresLN()
        {
            _editarColaboradoresAD = new EditarColaboradoresAD();
            _convertirAColaboradoresTabla = new ConvertirAColaboradoresTabla();
        }
        public async Task<int> Editar(ColaboradoresDto elColaboradorEnVista)
        {
            int cantidadDeDatosGuardados = await _editarColaboradoresAD.Editar(_convertirAColaboradoresTabla.ConvertirObjetoAColaboradoresTabla(elColaboradorEnVista));
            return cantidadDeDatosGuardados;
        }
    }
}