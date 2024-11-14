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
        public Cliente Cliente { get; set; }
        public ItemVenda Itens { get; set; }
        public double ValorTotal { get; set; }
        public Data DataVenda { get; set; }
        public Venda(Cliente cliente, ItemVenda itens, double valorTotal, Data dataVenda)
        {
            this.Cliente = cliente;
            this.Itens = itens;
            this.ValorTotal = valorTotal;
            this.DataVenda = dataVenda;
        }
    }
}
