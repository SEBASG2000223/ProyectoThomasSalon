using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Personas.Editar;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Personas;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Proveedores;
using ThomasSalon.Abstracciones.LN.Interfaces.Personas.Editar;
using ThomasSalon.Abstracciones.Modelos.Personas;
using ThomasSalon.AccesoADatos.Personas.Editar;
using ThomasSalon.AccesoADatos.Proveedores.Editar;
using ThomasSalon.LN.General.Conversiones.Personas;
using ThomasSalon.LN.General.Conversiones.Proveedores;

namespace ThomasSalon.LN.Personas.Editar
{
    public class EditarPersonasLN : IEditarPersonasLN
    {

        IEditarPersonasAD _editarPersonasAD;
        IConvertirAPersonasTabla _convertirAPersonasTabla;
        public EditarPersonasLN()
        {
            _editarPersonasAD = new EditarPersonasAD();
            _convertirAPersonasTabla = new ConvertirAPersonasTabla();
        }


        public async Task<int> Editar(PersonasDto laPersonaEnLaVista)
        {
            int cantidadDeDatosGuardados = await _editarPersonasAD.Editar(_convertirAPersonasTabla.ConvertirObjetoAPersonasTabla(laPersonaEnLaVista));
            return cantidadDeDatosGuardados;
        }
    }
}
