using System;
using System.Collections.Generic;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Citas;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Citas.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Citas.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.Citas;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Citas.Listar;
using ThomasSalon.AccesoADatos.Citas.ObtenerPorId;

namespace ThomasSalon.LN.Citas.ObtenerPorId
{
    public class ObtenerCitaPorIdLN : IObtenerCitaPorIdLN
    {
        IObtenerCitaPorIdAD _obtenerCitasAD;

        public ObtenerCitaPorIdLN()
        {
            _obtenerCitasAD = new ObtenerCitaPorIdAD();
        }
        public List<CitasDto> DetallesCita(Guid IdCita)
        {
            List<CitasDto> laListaDeCitas = _obtenerCitasAD.DetallesCita(IdCita);
            return laListaDeCitas;
        }
    }
}

