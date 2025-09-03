using Microsoft.AspNetCore.Mvc;
using Clientes.DTOs;
using Clientes.Services.Interfaces;

namespace ClientesJD.Api.Clientes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetClientes()
        {
            var clientes = await _clienteService.ObtenerTodosAsync();
            return Ok(clientes);
        }

        // GET: api/clientes/{identificacion}
        [HttpGet("{identificacion}")]
        public async Task<ActionResult<ClienteDto>> GetCliente(string identificacion)
        {
            var cliente = await _clienteService.ObtenerPorIdentificacionAsync(identificacion);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult<ClienteDto>> CrearCliente([FromBody] ClienteDto clienteDto)
        {
            var clienteCreado = await _clienteService.CrearAsync(clienteDto);
            return CreatedAtAction(nameof(GetCliente), new { identificacion = clienteCreado.Identificacion }, clienteCreado);
        }

        // PUT: api/clientes/{identificacion}
        [HttpPut("{identificacion}")]
        public async Task<IActionResult> ActualizarCliente(string identificacion, [FromBody] ClienteDto clienteDto)
        {
            var actualizado = await _clienteService.ActualizarAsync(identificacion, clienteDto);
            if (!actualizado)
                return NotFound();
            return NoContent();
        }

        // DELETE: api/clientes/{identificacion}
        [HttpDelete("{identificacion}")]
        public async Task<IActionResult> EliminarCliente(string identificacion)
        {
            var eliminado = await _clienteService.EliminarAsync(identificacion);
            if (!eliminado)
                return NotFound();
            return NoContent();
        }
    }
}
