using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class CadVendas
    {
        private List<Venda> vendas = new List<Venda>();

        public void Insere(Venda venda)
        {
            vendas.Add(venda);
        }

        public Venda GetVenda(int posicao)
        {
            return vendas[posicao];
        }
    }
}
