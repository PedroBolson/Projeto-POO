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
        public List<ItemVenda> Itens { get; set; }
        public Cliente Cliente { get; set; }
        public double ValorTotal { get; set; }
        public Data DataVenda { get; set; }
        public Venda(Cliente cliente, Data dataVenda, double total)
        {
            Itens = new List<ItemVenda>();
            this.Cliente = cliente;
            this.ValorTotal = total;
            this.DataVenda = dataVenda;
        }
    }
}