using ConsultaCep.Domain.Entities;

namespace ConsultaCep.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ObterTodosClientesAsync();
        Task<Cliente> ObterClientePorIDAsync(int clienteID);
        Task<int> AdicionarClienteAsync(Cliente cliente);
        Task AtualizarClienteAsync(Cliente cliente);
        Task ExcluirClienteAsync(int clienteID);
    }
}
