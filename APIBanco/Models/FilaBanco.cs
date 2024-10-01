using BibliotecaDeClasses;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaDeClasses
{
    public class Cliente
    {
        public int Id { get; set; }  // Identificador único para cada cliente
        public string Nome { get; set; }  // Nome do cliente
        public int Idade { get; set; }  // Idade do cliente
    }

    public class FilaBanco
    {
        private List<Cliente> clientes = new List<Cliente>();  // Lista que mantém os clientes na fila
        private int ultimoId = 0;  // Controla o próximo ID a ser atribuído

        private List<Cliente> clientesAtendidos = new List<Cliente>();  // Lista de clientes atendidos

        // Adiciona um novo cliente à fila, priorizando clientes com mais de 40 anos
        public void AdicionarCliente(string nome, int idade)
        {
            var novoCliente = new Cliente { Nome = nome, Idade = idade, Id = ultimoId++ };  // Cria um novo cliente com ID único

            if (idade > 40)
            {
                clientes.Insert(0, novoCliente);  // Insere no início da fila se o cliente tiver mais de 40 anos
            }
            else
            {
                clientes.Add(novoCliente);  // Insere no final da fila se for atendimento comum
            }
        }

        // Remove o primeiro cliente da fila
        public void RemoverCliente()
        {
            if (clientes.Count > 0)  // Verifica se há clientes na fila
            {
                var clienteRemovido = clientes[0];  // Pega o primeiro cliente da fila
                clientes.RemoveAt(0);  // Remove o cliente da fila

                AdicionarClienteAtendido(clienteRemovido);  // Move o cliente para a lista de atendidos
            }
            else
            {
                Console.WriteLine("A fila está vazia.");  // Log para indicar que a fila está vazia
            }
        }

        // Retorna a lista de clientes na fila
        public List<Cliente> ConsultarFila()
        {
            return clientes;  // Retorna a lista de clientes em sua ordem atual
        }

        // Adiciona um cliente à lista de atendidos
        public void AdicionarClienteAtendido(Cliente cliente)
        {
            clientesAtendidos.Add(cliente);  // Adiciona o cliente à lista de atendidos
        }

        // Retorna a lista de clientes atendidos, ordenados alfabeticamente
        public List<Cliente> ConsultarClientesAtendidos()
        {
            return clientesAtendidos.OrderBy(c => c.Nome).ToList();  // Retorna os clientes em ordem alfabética
        }
    }
}
    