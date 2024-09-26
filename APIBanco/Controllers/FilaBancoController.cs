using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BibliotecaDeClasses;
using System.Text.Json;

namespace FilaBancoWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilaBancoController : ControllerBase
    {
        private readonly FilaBanco _filaBanco = new FilaBanco();

        [HttpPost("AdicionarCliente")]
        public IActionResult AdicionarCliente(Cliente cliente)
        {
            _filaBanco.AdicionarCliente(cliente.Nome, cliente.Idade);
            // Retornando uma resposta com o cliente adicionado ou uma mensagem de sucesso
            return Ok(new { message = "Cliente adicionado com sucesso!", cliente });
        }
        [HttpDelete("RemoverCliente")]
        public IActionResult RemoverCliente()
        {
            _filaBanco.RemoverCliente();
            return Ok("Cliente removido com sucesso!");
        }
        [HttpGet("ConsultarFila")]
        public IActionResult ConsultarFila()
        {
            var filaOrdenada = _filaBanco.ConsultarFila(); // Adaptar para retornar a lista de clientes
            return Ok(JsonSerializer.Serialize(filaOrdenada));
        }
        [HttpGet("ConsultarClientesAtendidos")]
        public IActionResult ConsultarClientesAtendidos()
        {
            var clientesAtendidos = _filaBanco.ClientesAtendidos.ConsultarClientesAtendidos();
            return Ok(JsonSerializer.Serialize(clientesAtendidos));
        }


    }
}
