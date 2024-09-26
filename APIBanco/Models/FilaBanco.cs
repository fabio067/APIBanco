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
            var novoCliente = new Cliente { Nome = nome, Idade = idade };

            
            // Se a idade for maior que 40, insere no início e incrementa os IDs dos demais
            if (idade > 40)
            {
                clientes.Insert(0, novoCliente);
                novoCliente.Id = 0;
                for (int i = 1; i < clientes.Count; i++)
                {
                    clientes[i].Id++;
                }
            }
            else
            {
                // Insere no final e atribui o próximo ID
                novoCliente.Id = ultimoId++;
                clientes.Add(novoCliente);
            }
        }
        private ClientesAtendidos clientesAtendidos = new ClientesAtendidos();
        public void ConsultarClientesAtendidos()
        {
            clientesAtendidos.ConsultarClientesAtendidos();
        }

        public void RemoverCliente()
        {

            if (clientes.Count > 0)
            {


                // Remove o primeiro cliente da fila (menor ID)
                var clienteRemovido = clientes[0];
                clientes.RemoveAt(0);

                // Ajusta os IDs dos clientes restantes
                for (int i = 0; i < clientes.Count; i++)
                {
                    clientes[i].Id = i;
                }


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
            // Ordena a lista por ID de forma crescente
            var filaOrdenada = clientes.OrderBy(cliente => cliente.Id).ToList();
            return filaOrdenada;
        }

        public ClientesAtendidos ClientesAtendidos { get; private set; } = new ClientesAtendidos();
    }
}