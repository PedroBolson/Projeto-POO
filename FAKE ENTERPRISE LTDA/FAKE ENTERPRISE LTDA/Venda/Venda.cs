using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class Venda
    {
        public List<ItemVenda> Itens { get; set; } = new List<ItemVenda>();
        public Cliente Cliente { get; set; }
        public double ValorTotal { get; set; }
        public Data DataVenda { get; set; }
        public Venda(List<ItemVenda> itens, Cliente cliente, Data dataVenda, double total)
        {
            Itens = itens;
            this.Cliente = cliente;
            this.ValorTotal = total;
            this.DataVenda = dataVenda;
        }

        public override string ToString() 
        {

            Console.WriteLine($"Cliente: {Cliente.Nome} (Código: {Cliente.Codigo})");
            Console.WriteLine($"Data da Venda: {DataVenda}");
            Console.WriteLine($"Valor Total: R$ {ValorTotal:F2}");
            Console.WriteLine("Itens Vendidos:");
            foreach (ItemVenda item in Itens)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("__________");
            return "Venda listada com sucesso!";
        }
    }
}