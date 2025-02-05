using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.Listar;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;

namespace ThomasSalon.AccesoADatos.Colaboradores.Listar
{
    public class ListarColaboradoresAD : IListarColaboradoresAD
    {
        Contexto _elContexto;

        public ListarColaboradoresAD()
        {
            _elContexto = new Contexto();
        }

        public List<ColaboradoresDto> Listar()
        {
            List<ColaboradoresDto> laListaDeColaboradores = (from c in _elContexto.ColaboradoresTabla
                                                             join e in _elContexto.EstadoDisponibilidadTabla
                                                             on c.IdEstado equals e.IdEstado
                                                             select new ColaboradoresDto
                                                             {
                                                                 IdColaborador = c.IdColaborador,
                                                                 Nombre = c.Nombre,
                                                                 Telefono = c.Telefono,
                                                                 SalarioDia = c.SalarioDia,
                                                                 IdEstado = c.IdEstado,
                                                                 NombreEstado = e.Nombre
                                                             }).ToList();
            return laListaDeColaboradores;
        }
    }
}