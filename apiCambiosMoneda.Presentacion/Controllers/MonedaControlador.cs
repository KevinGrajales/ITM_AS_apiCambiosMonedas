using apiCambiosMoneda.Core.Interfaces.Servicios;
using apiCambiosMoneda.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace apiCambiosMoneda.Presentacion.Controllers
{
    [ApiController]
    [Route("api/monedas")]
    public class MonedaControlador : ControllerBase
    {
        private readonly IMonedaServicio servicio;

        public MonedaControlador(IMonedaServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("cambios/historial/{idMoneda}/{desde}/{hasta}")]
        public Task<IEnumerable<CambioMoneda>> ObtenerHistorialCambios(int idMoneda, DateTime desde, DateTime hasta)
        {
            return servicio.ObtenerHistorialCambios(idMoneda, desde, hasta);
        }
    }
}
