using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Usuarios;
using ThomasSalon.Abstracciones.Modelos.Sucursales;
using ThomasSalon.Abstracciones.Modelos.Usuarios;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.LN.General.Conversiones.Usuarios
{
    public class ConvertirAUsuariosTabla : IConvertirAUsuariosTabla
    {
        public UsuariosTabla ConvertirObjetoAUsuariosTabla(UsuariosDto elUsuario)
        {
            return new UsuariosTabla 
            { 
            Id = elUsuario.Id,
            Email = elUsuario.Email,
            IdEstado = elUsuario.IdEstado,
            IdSucursal = elUsuario.IdSucursal,
            IdPersona = elUsuario.IdPersona
           
            };
        }
    }
}
