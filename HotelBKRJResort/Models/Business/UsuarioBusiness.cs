using HotelBKRJResort.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Business
{
    public class UsuarioBusiness
    {
        public IConfiguration Configuration { get; }

        public UsuarioBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public int ValidarUsuario(String usuario, String contra)
        {
            UsuarioData usuarioData = new UsuarioData(this.Configuration);

            return usuarioData.ValidarUsuario(usuario, contra);
        }
    }
}

