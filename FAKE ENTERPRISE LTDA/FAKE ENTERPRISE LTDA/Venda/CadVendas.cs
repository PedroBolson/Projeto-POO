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
                Console.WriteLine($"Cliente: {venda.Cliente.Nome} (Código: {venda.Cliente.Codigo})");
                Console.WriteLine($"Data da Venda: {venda.DataVenda}");
                Console.WriteLine($"Valor Total: R$ {venda.ValorTotal:F2}");
                Console.WriteLine("Itens Vendidos:");

                foreach (ItemVenda item in venda.Itens)
                {
                    Console.WriteLine($"- Produto: {item.Item.Descricao} (Código: {item.Item.Codigo})");
                    Console.WriteLine($"  Quantidade: {item.Quantidade}");
                    Console.WriteLine($"  Valor Unitário: R$ {item.Valor:F2}");
                    Console.WriteLine($"  Valor Total: R$ {item.Valor * item.Quantidade:F2}");
                }

                Console.WriteLine(new string('-', 30)); // Separador entre vendas
            }
        }
    }
}
