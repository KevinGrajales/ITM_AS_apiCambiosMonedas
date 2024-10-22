using apiCambiosMoneda.Dominio.Entidades;
using apiCambiosMoneda.Core.Interfaces.Servicios;
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

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Moneda>>> ObtenerTodos()
        {
            return Ok(await servicio.ObtenerTodos());
        }

        [HttpGet("obtener/{Id}")]
        public async Task<ActionResult<Moneda>> Obtener(int Id)
        {
            return Ok(await servicio.Obtener(Id));
        }

        [HttpGet("buscar/{Tipo}/{Dato}")]
        public async Task<ActionResult<Moneda>> Buscar(int Tipo, string Dato)
        {
            return Ok(await servicio.Buscar(Tipo, Dato));
        }

        [HttpPost("agregar")]
        public async Task<ActionResult<Moneda>> Agregar([FromBody] Moneda moneda)
        {
            return Ok(await servicio.Agregar(moneda));
        }

        [HttpPut("modificar")]
        public async Task<ActionResult<Moneda>> Modificar([FromBody] Moneda moneda)
        {
            return Ok(await servicio.Modificar(moneda));
        }

        [HttpDelete("eliminar/{Id}")]
        public async Task<ActionResult<bool>> Eliminar(int Id)
        {
            return Ok(await servicio.Eliminar(Id));
        }
    }
}