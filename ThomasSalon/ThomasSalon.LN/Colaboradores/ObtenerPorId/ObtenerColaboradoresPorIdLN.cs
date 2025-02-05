using System;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Colaboradores.ObtenerPorId;

namespace ThomasSalon.LN.Colaboradores.ObtenerPorId
{
    public class ObtenerColaboradoresPorIdLN : IObtenerColaboradoresPorIdLN
    {
        IObtenerColaboradoresPorIdAD _obtenerPorIdAD;

        public ObtenerColaboradoresPorIdLN()
        {
            _obtenerPorIdAD = new ObtenerPorIdColaboradoresAD();
        }

        public ColaboradoresDto Obtener(int IdColaborador)
        {
            ColaboradoresTabla elColaboradorEnDb = _obtenerPorIdAD.Obtener(IdColaborador);
            return new ColaboradoresDto
            {
                IdColaborador = elColaboradorEnDb.IdColaborador,
                Nombre = elColaboradorEnDb.Nombre,
                Telefono = elColaboradorEnDb.Telefono,
                SalarioDia = elColaboradorEnDb.SalarioDia,
                IdEstado = elColaboradorEnDb.IdEstado
            };
        }
    }
}