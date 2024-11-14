using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class Estoque
    {
        private List<ItemEstoque> itens = new List<ItemEstoque>();

        public void Insere(ItemEstoque item)
        {
            itens.Add(item);
        }

        public ItemEstoque GetItem(int posicao)
        {
            return itens[posicao];
        }
    }
}
