using leticiaViagem.Database;
using leticiaViagem.Model;
using Microsoft.EntityFrameworkCore;

namespace viagemLeticia.Repository
{
    public class DestinoRepository : IDestinoRepository
    {
        //Injetar dependencias do contexto
        private readonly DestinoDbContext _context;

        public DestinoRepository(DestinoDbContext context){
            _context = context;
        }

        public void AddDestino(Destino destino)
        {
            _context.Add(destino);
        }

        public void AtualizarDestino(Destino destino)
        {
            _context.Update(destino);
        }

        public void DeletarDestino(Destino destino)
        {
            _context.Remove(destino);
        }

        public async Task<Destino> GetDestinobyId(int id)
        {
            return await _context.Destinos.Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Destino>> GetDestinos()
        {
            return await _context.Destinos.ToListAsync();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;   
        }

        Task<IEnumerable<Destino>> IDestinoRepository.GetDestinos()
        {
            throw new NotImplementedException();
        }
    }
}