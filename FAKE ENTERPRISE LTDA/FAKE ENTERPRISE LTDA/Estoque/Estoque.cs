using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
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
        public int GetTamanho()
        {
            return itens.Count;
        }
        public void AtualizaValor(int codigo, double valor)
        {
            foreach(ItemEstoque item in itens)
            {
                if(item.Item.Codigo == codigo)
                {
                    item.Valor = valor;
                }
            }
        }

        public double RetornaValorUnitario(int codigo)
        {
            foreach(ItemEstoque item in itens)
            {
                if(item.Item.Codigo == codigo)
                {
                    return item.Valor;
                }
            }
            return 0.0;
        }

        public bool VerificaEstoque(int codigo)
        {
            foreach(ItemEstoque item in itens)
            {
                if (item.Item.Codigo == codigo)
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerificaEstoque(int codigo, int quantidade)
        {
            foreach (ItemEstoque item in itens)
            {
                if (item.Item.Codigo == codigo && item.Quantidade >= quantidade)
                {
                    return true;
                }
            }
            return false;
        }

        public void AumentaEstoque(int codigo, int quantidade)
        {
            foreach (ItemEstoque item in itens)
            {
                if (item.Item.Codigo == codigo)
                {
                    item.Quantidade += quantidade;
                    break;
                }
            }
        }

        public void AtualizaEstoque(int codigo, int quantidade)
        {
            foreach(ItemEstoque item in itens)
            {
                if(item.Item.Codigo == codigo)
                {
                    item.Quantidade -= quantidade;
                    break;
                }
            }
        }

        public Produto GetItemPorCodigo(int codigo)
        {
            foreach(ItemEstoque item in itens)
            {
                if(item.Item.Codigo == codigo)
                {
                    return item.Item;
                }
            }
            return null;
        }

        public void EscreveEstoque()
        {
            foreach (ItemEstoque item in itens)
            {
                Console.WriteLine($"Código: {item.Item.Codigo} / Produto: {item.Item.Descricao} / Quantidade: {item.Quantidade} / Valor unitário: R$ {item.Valor:F2}");
            }
        }

        public ItemEstoque GetItem(int posicao)
        {
            return itens[posicao];
        }
    }
}
