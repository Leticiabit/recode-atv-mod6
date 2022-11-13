using leticiaViagem.Model;

namespace viagemLeticia.Repository
{
    public interface IDestinoRepository
    {
        Task<IEnumerable<Destino>> GetDestinos();
        Task<Destino> GetDestinobyId(int id);
        void AddDestino(Destino destino);
        void AtualizarDestino(Destino destino);
        void DeletarDestino(Destino destino);
        
        Task<bool> SaveChangeAsync();
    }
}