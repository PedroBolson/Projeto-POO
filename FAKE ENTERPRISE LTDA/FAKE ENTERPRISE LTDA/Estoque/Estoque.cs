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
        CadProdutos cadProdutos = new CadProdutos();
        EntradaDados entradaDados = new EntradaDados();

        public void Insere(ItemEstoque item)
        {
            itens.Add(item);
        }

        public ItemEstoque GetItem(int posicao)
        {
            return itens[posicao];
        }

        public void CadastroEstoque()
        {
            int codigo;
            do
            {
                codigo = entradaDados.LeInteiro("Digite o(s) códigos para adicionar no estoque ou digite 0 para SAIR");
                var produto = cadProdutos.BuscaProduto(codigo);
                if (produto == null && codigo != 0)
                {
                    Console.WriteLine("Produto não encontrado! Por favor tente novamente");
                }
                else
                {
                    var quantidade = entradaDados.LeInteiro("Digite a quantidade de produtos");
                    var valor = entradaDados.LeFloat("Digite o preço unitário do produto");
                    var item = new ItemEstoque(produto, quantidade, valor);
                    this.Insere(item);
                    Console.WriteLine("Produto cadastrado com sucesso!");
                }
            } while (codigo != 0);
        }
    }
}
