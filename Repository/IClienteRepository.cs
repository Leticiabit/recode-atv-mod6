using leticiaViagem.Model;

namespace viagemLeticia.Repository
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetClientebyId(int id);
        void AddCliente(Cliente cliente);
        void AtualizarCliente(Cliente cliente);
        void DeletarCliente(Cliente cliente);
        
        Task<bool> SaveChangeAsync();
    }
}