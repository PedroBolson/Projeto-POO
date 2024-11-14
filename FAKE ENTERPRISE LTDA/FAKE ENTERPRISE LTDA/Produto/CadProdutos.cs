using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class CadProdutos
    {
        private List<Produto> produtos = new List<Produto>();

        public void Insere (Produto prod)
        {
            produtos.Add(prod);
        }
        public Produto GetProduto(int posicao)
        {
            return produtos[posicao];
        }
    }
}
