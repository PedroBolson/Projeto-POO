using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class CadClientes
    {
        private List<Cliente> clientes = new List<Cliente>();

        public void Insere(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public Cliente GetCliente(int posicao)
        {
            return clientes[posicao];
        }
    }
}
