using Microsoft.AspNetCore.Mvc;
using BibliotecaDeClasses;

namespace FilaBancoWebAPI.Controllers
{
    [ApiController]  // Indica que este é um controlador de API
    [Route("[controller]")]  // Define a rota base para o controlador, neste caso, "FilaBanco"
    public class FilaBancoController : ControllerBase
    {
        private readonly FilaBanco _filaBanco;  // Campo para a fila de banco, injetado via dependência

        // Construtor que recebe uma instância de FilaBanco por injeção de dependência
        public FilaBancoController(FilaBanco filaBanco)
        {
            _filaBanco = filaBanco;
        }

        // Adicionar cliente à fila
        [HttpPost("AdicionarCliente")]  // Define uma rota POST para adicionar um cliente
        public IActionResult AdicionarCliente(Cliente cliente)
        {
            _filaBanco.AdicionarCliente(cliente.Nome, cliente.Idade);  // Adiciona o cliente à fila
            var clienteAdicionado = _filaBanco.ConsultarFila().Last();  // Obtém o último cliente adicionado
            return Ok(new { message = "Cliente adicionado com sucesso!", cliente = clienteAdicionado });  // Retorna uma resposta com o cliente adicionado
        }

        // Remover o primeiro cliente da fila
        [HttpDelete("RemoverCliente")]  // Define uma rota DELETE para remover o primeiro cliente da fila
        public IActionResult RemoverCliente()
        {
            _filaBanco.RemoverCliente();  // Remove o primeiro cliente da fila
            return Ok(new { message = "Cliente removido com sucesso!" });  // Retorna uma resposta de sucesso
        }

        // Consultar a fila de clientes
        [HttpGet("ConsultarFila")]  // Define uma rota GET para consultar a fila
        public IActionResult ConsultarFila()
        {
            var filaOrdenada = _filaBanco.ConsultarFila();  // Obtém a lista de clientes na fila
            return Ok(filaOrdenada);  // Retorna a lista de clientes
        }

        // Consultar os clientes que já foram atendidos
        [HttpGet("ConsultarClientesAtendidos")]  // Define uma rota GET para consultar clientes atendidos
        public IActionResult ConsultarClientesAtendidos()
        {
            var clientesAtendidos = _filaBanco.ConsultarClientesAtendidos();  // Obtém a lista de clientes atendidos
            Console.WriteLine($"Número de clientes atendidos: {clientesAtendidos.Count}");  // Log para verificação
            return Ok(clientesAtendidos);  // Retorna a lista de clientes atendidos
        }
    }
}