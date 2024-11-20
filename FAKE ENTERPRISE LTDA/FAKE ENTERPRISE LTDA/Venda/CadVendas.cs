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

        public int GetTamanho()
        {
            return vendas.Count;
        }

        public Venda GetVenda(int posicao)
        {
            return vendas[posicao];
        }

        public void ListarVendas()
        {
            if (vendas.Count == 0)
            {
                Console.WriteLine("Nenhuma venda cadastrada.");
                return;
            }

            Console.WriteLine("Lista de Vendas:");
            foreach (Venda venda in vendas)
            {
                venda.ToString();
            }
        }
    }
}
