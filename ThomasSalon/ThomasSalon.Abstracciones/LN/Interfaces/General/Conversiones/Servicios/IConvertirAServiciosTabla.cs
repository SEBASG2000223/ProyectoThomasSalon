using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Servicios;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Servicios
{
    public interface IConvertirAServiciosTabla
    {
        ServiciosTabla ConvertirObjetoAServiciosTabla(ServiciosDto elServicio);
    }
}
