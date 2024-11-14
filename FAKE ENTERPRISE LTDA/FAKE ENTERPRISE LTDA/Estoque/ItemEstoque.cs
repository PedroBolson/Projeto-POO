using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class ItemEstoque
    {
        public Produto Item { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public ItemEstoque(Produto item, int quantidade, double valor)
        {
            this.Item = item;
            this.Quantidade = quantidade;
            this.Valor = valor;
        }
    }
}
