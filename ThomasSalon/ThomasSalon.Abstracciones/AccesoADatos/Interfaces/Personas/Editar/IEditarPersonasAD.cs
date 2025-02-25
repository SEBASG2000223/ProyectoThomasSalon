using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Personas.Editar
{
    public interface IEditarPersonasAD
    {
        Task<int> Editar(PersonasTabla laPersonaParaEditar);
    }
}
