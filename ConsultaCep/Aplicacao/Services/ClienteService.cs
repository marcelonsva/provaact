using ConsultaCep.Application.Interfaces;
using ConsultaCep.Domain.Entities;
using ConsultaCep.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ConsultaCep.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> ObterTodosClientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> ObterClientePorIDAsync(int clienteID)
        {
            return await _context.Clientes.FindAsync(clienteID);
        }

        public async Task<int> AdicionarClienteAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente.ClienteID;
        }

        public async Task AtualizarClienteAsync(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirClienteAsync(int clienteID)
        {
            var cliente = await _context.Clientes.FindAsync(clienteID);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
