using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Ventas.ResgistroGastos;
using ThomasSalon.Abstracciones.LN.Interfaces.Ventas.ResgistroGastos;
using ThomasSalon.Abstracciones.Modelos.Ventas.ResgistroGastos;
using ThomasSalon.AccesoADatos.Ventas.ResgistroGastos;

namespace ThomasSalon.LN.Ventas.ResgistroGastos
{
    public class RegistroGastoLN: IRegistroGastoLN
    {
        IRegistroGastoAD _registroGastoAD;
         public RegistroGastoLN()
        {
            _registroGastoAD = new RegistroGastoAD();
        }

        public async Task<int> RegistroGasto(RegistroGastoDTO RegistroGasto)
        {
            return await _registroGastoAD.RegistroGasto(RegistroGasto);

        }
    }
}
