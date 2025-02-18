using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Personas.Listar;
using ThomasSalon.Abstracciones.Modelos.Personas;
using ThomasSalon.Abstracciones.Modelos.Proveedores;

namespace ThomasSalon.AccesoADatos.Personas.Listar
{
    public class ListarPersonasAD : IListarPersonasAD
    {
        Contexto _elContexto;

        public ListarPersonasAD()
        {
            _elContexto = new Contexto();
        }

        public List<PersonasDto> Listar()
        {
            List<PersonasDto> laListaDePersonas = (from laPersona in _elContexto.PersonasTabla
                                                   select new PersonasDto
                                                   {
                                                       IdPersona = laPersona.IdPersona,
                                                       Nombre = laPersona.Nombre,
                                                       Telefono = laPersona.Telefono,
                                                       Genero = laPersona.Genero,
                                                       Direccion = laPersona.Direccion,
                                                       Edad = laPersona.Edad,
                                                       Identificacion = laPersona.Identificacion
                                                   }).ToList();
            return laListaDePersonas;
        }
    }
}

