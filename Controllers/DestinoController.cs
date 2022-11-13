using leticiaViagem.Model;
using Microsoft.AspNetCore.Mvc;
using viagemLeticia.Repository;

namespace leticiaViagem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinoController : ControllerBase
    {
        // Injetar dependencia do repositório

        private readonly IDestinoRepository _repository;

        public DestinoController(IDestinoRepository repository){
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var destinos = await _repository.GetDestinos();
            return destinos.Any() ? Ok(destinos) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var destino = await _repository.GetDestinobyId(id);
            return destino != null ? Ok(destino) : NotFound("Destino não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Destino destino){
            _repository.AddDestino(destino);
            return await _repository.SaveChangeAsync()
            ? Ok("Destino adicionado") : BadRequest("Algo de errado não está certo.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Destino destino)
        {
            var destinoExiste = await _repository.GetDestinobyId(id);
            if(destinoExiste == null) return NotFound("Destino não encontrado.");

            destinoExiste.pais = destino.pais ?? destinoExiste.pais;
            destinoExiste.cidade = destino.cidade ?? destinoExiste.cidade;
            destinoExiste.valor = destino.valor ?? destinoExiste.valor;

            return await _repository.SaveChangeAsync() ? Ok("Destino atualizado.") : BadRequest("Algo de errado não está certo.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var destinoExiste = await _repository.GetDestinobyId(id);
            if (destinoExiste == null)
                return NotFound("Destino não encontrado.");

            _repository.DeletarDestino(destinoExiste);

            return await _repository.SaveChangeAsync() ? Ok("Destino excluido.") : BadRequest("Aldo de errado não está certo.");
        }

    }
}