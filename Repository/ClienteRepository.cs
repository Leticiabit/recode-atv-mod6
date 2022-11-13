using leticiaViagem.Database;
using leticiaViagem.Model;
using Microsoft.EntityFrameworkCore;

namespace viagemLeticia.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        //Injetar dependencias do contexto
        private readonly ClienteDbContext _context;

        public ClienteRepository(ClienteDbContext context){
            _context = context;
        }

        public void AddCliente(Cliente cliente)
        {
            _context.Add(cliente);
        }

        public void AtualizarCliente(Cliente cliente)
        {
            _context.Update(cliente);
        }

        public void DeletarCliente(Cliente cliente)
        {
            _context.Remove(cliente);
        }

        public async Task<Cliente> GetClientebyId(int id)
        {
            return await _context.Clientes.Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;   
        }
    }
}