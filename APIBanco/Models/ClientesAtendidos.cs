using BibliotecaDeClasses;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaDeClasses
{
    public class ClientesAtendidos
    {
        private Dictionary<string, Cliente> clientesAtendidos = new Dictionary<string, Cliente>();

        public void AdicionarClienteAtendido(Cliente cliente)
        {
            clientesAtendidos.Add(cliente.Nome, cliente);
        }

        public List<Cliente> ConsultarClientesAtendidos()
        {
            return clientesAtendidos.Values.OrderBy(c => c.Nome).ToList();
        }
    }
}