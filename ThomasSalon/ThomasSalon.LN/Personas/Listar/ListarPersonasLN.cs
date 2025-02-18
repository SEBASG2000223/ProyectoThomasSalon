using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Personas.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Personas.Listar;
using ThomasSalon.Abstracciones.Modelos.Personas;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.AccesoADatos.Personas.Listar;

namespace ThomasSalon.LN.Personas.Listar
{
    public class ListarPersonasLN : IListarPersonasLN
    {
        IListarPersonasAD _listarPersonasAD;

        public ListarPersonasLN()
        {
            _listarPersonasAD = new ListarPersonasAD();
        }
        public List<PersonasDto> Listar()
        {
            List<PersonasDto> laListaDePersonas = _listarPersonasAD.Listar();
            return laListaDePersonas
;
        }
    }
}
