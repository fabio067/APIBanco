using Microsoft.AspNetCore.Mvc;
using BibliotecaDeClasses;

namespace FilaBancoWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilaBancoController : ControllerBase
    {
        private readonly FilaBanco _filaBanco;

        public FilaBancoController(FilaBanco filaBanco) // Injeção de dependência
        {
            _filaBanco = filaBanco;
        }

        [HttpPost("AdicionarCliente")]
        public IActionResult AdicionarCliente(Cliente cliente)
        {
            _filaBanco.AdicionarCliente(cliente.Nome, cliente.Idade);
            var clienteAdicionado = _filaBanco.ConsultarFila().Last();
            return Ok(new { message = "Cliente adicionado com sucesso!", cliente = clienteAdicionado });
        }

        [HttpDelete("RemoverCliente")]
        public IActionResult RemoverCliente()
        {
            _filaBanco.RemoverCliente();
            return Ok(new { message = "Cliente removido com sucesso!" });
        }

        [HttpGet("ConsultarFila")]
        public IActionResult ConsultarFila()
        {
            var filaOrdenada = _filaBanco.ConsultarFila();
            return Ok(filaOrdenada);
        }

        [HttpGet("ConsultarClientesAtendidos")]
        public IActionResult ConsultarClientesAtendidos()
        {
            var clientesAtendidos = _filaBanco.ClientesAtendidos.ConsultarClientesAtendidos();
            return Ok(clientesAtendidos);
        }
    }
}