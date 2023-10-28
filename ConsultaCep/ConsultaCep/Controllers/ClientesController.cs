using ConsultaCep.Application.Interfaces;
using ConsultaCep.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaCep.Presentation.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = await _clienteService.ObterClientePorIDAsync(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.ObterTodosClientesAsync();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            await _clienteService.AdicionarClienteAsync(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.ClienteID }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cliente cliente)
        {
            if (id != cliente.ClienteID)
                return BadRequest();

            await _clienteService.AtualizarClienteAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _clienteService.ObterClientePorIDAsync(id);
            if (cliente == null)
                return NotFound();

            await _clienteService.ExcluirClienteAsync(id);
            return NoContent();
        }

    }
}
