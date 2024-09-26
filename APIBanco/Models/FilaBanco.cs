using BibliotecaDeClasses;

namespace BibliotecaDeClasses
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }

    public class FilaBanco
    {
        private List<Cliente> clientes = new List<Cliente>();
        private int ultimoId = 0;

        public void AdicionarCliente(string nome, int idade)
        {
            var novoCliente = new Cliente { Nome = nome, Idade = idade, Id = ultimoId++ }; // Gera um ID único para cada cliente

            // Se a idade for maior que 40, insere no início da fila, senão insere no final
            if (idade > 40)
            {
                clientes.Insert(0, novoCliente); // Atendimento preferencial (início da fila)
            }
            else
            {
                clientes.Add(novoCliente); // Atendimento comum (final da fila)
            }
        }

        private ClientesAtendidos clientesAtendidos = new ClientesAtendidos();

        public void RemoverCliente()
        {
            if (clientes.Count > 0)
            {
                // Remove o primeiro cliente da fila
                var clienteRemovido = clientes[0];
                clientes.RemoveAt(0);

                // Adiciona o cliente removido à lista de clientes atendidos
                clientesAtendidos.AdicionarClienteAtendido(clienteRemovido);
            }
            else
            {
                Console.WriteLine("A fila está vazia.");
            }
        }

        public List<Cliente> ConsultarFila()
        {
            return clientes; // Retorna a lista de clientes na ordem atual da fila
        }

        public ClientesAtendidos ClientesAtendidos { get; private set; } = new ClientesAtendidos();
    }
}