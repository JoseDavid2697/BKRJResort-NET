using HotelBKRJResort.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBKRJResort.Models.Business
{
    public class OfertaBusiness
    {

        public IConfiguration Configuration { get; }

        public OfertaBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Oferta> ObtenerOfertasAdmin()
        {
            OfertaData ofertaData = new OfertaData(this.Configuration);

            return ofertaData.ObtenerOfertasAdmin();
        }

        public List<Oferta> ObtenerOfertas()
        {
            OfertaData ofertaData = new OfertaData(this.Configuration);

            return ofertaData.ObtenerOfertas();
        }

        public List<Oferta> RegistrarOferta(String nombre, String descripcion, String linkDestino, string img)
        {
            OfertaData ofertaData = new OfertaData(this.Configuration);

            return ofertaData.RegistrarOferta(nombre, descripcion, linkDestino, img);
        }

        public List<Oferta> ActualizarOferta(int id, String nombre, String descripcion, String linkDestino)
        {
            OfertaData ofertaData = new OfertaData(this.Configuration);

            return ofertaData.ActualizarOferta(id, nombre, descripcion, linkDestino);
        }

        public List<Oferta> EliminarOferta(int id)
        {
            OfertaData ofertaData = new OfertaData(this.Configuration);

            return ofertaData.EliminarOferta(id);
        }

        public List<Oferta> ObtenerOfertasSolicitadas()
        {
            OfertaData ofertaData = new OfertaData(this.Configuration);

            return ofertaData.ObtenerOfertasSolicitadas();
        }
        public void AceptarOferta(int id)
        {
            OfertaData ofertaData = new OfertaData(this.Configuration);

            ofertaData.AceptarOferta(id);
        }

        public string ObtenerCorreoProveedor(int id)
        {
            OfertaData ofertaData = new OfertaData(this.Configuration);

            return ofertaData.ObtenerCorreoProveedor(id);
        }
    }
}
