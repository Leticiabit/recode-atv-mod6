using leticiaViagem.Model;
using Microsoft.AspNetCore.Mvc;
using viagemLeticia.Repository;

namespace leticiaViagem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        // Injetar dependencia do repositório

        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository){
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _repository.GetClientes();
            return clientes.Any() ? Ok(clientes) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _repository.GetClientebyId(id);
            return cliente != null ? Ok(cliente) : NotFound("Cliente não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente){
            _repository.AddCliente(cliente);
            return await _repository.SaveChangeAsync()
            ? Ok("Cliente adicionado") : BadRequest("Algo de errado não está certo.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Cliente cliente)
        {
            var clienteExiste = await _repository.GetClientebyId(id);
            if(clienteExiste == null) return NotFound("Cliente não encontrado.");

            clienteExiste.nome = cliente.nome ?? clienteExiste.nome;
            clienteExiste.celular = cliente.celular ?? clienteExiste.celular;
            clienteExiste.email = cliente.email ?? clienteExiste.email;

            return await _repository.SaveChangeAsync() ? Ok("Cliente atualizado.") : BadRequest("Algo de errado não está certo.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var clienteExiste = await _repository.GetClientebyId(id);
            if (clienteExiste == null)
                return NotFound("Cliente não encontrado.");

            _repository.DeletarCliente(clienteExiste);

            return await _repository.SaveChangeAsync() ? Ok("Cliente excluido.") : BadRequest("Aldo de errado não está certo.");
        }

    }
}