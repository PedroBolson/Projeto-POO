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
            foreach (ItemEstoque item in itens)
            {
                if (item.Item.Codigo == codigo)
                {
                    item.Valor = valor;
                }
            }
        }

        public int RetornaQuantidade(int codigo)
        {
            foreach (ItemEstoque item in itens)
            {
                if (item.Item.Codigo == codigo)
                {
                    return item.Quantidade;
                }
            }
            return 0;
        }

        public double RetornaValorUnitario(int codigo)
        {
            foreach (ItemEstoque item in itens)
            {
                if (item.Item.Codigo == codigo)
                {
                    return item.Valor;
                }
            }
            return 0.0;
        }

        public bool VerificaEstoque(int codigo)
        {
            foreach (ItemEstoque item in itens)
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
            foreach (ItemEstoque item in itens)
            {
                if (item.Item.Codigo == codigo)
                {
                    item.Quantidade -= quantidade;
                    break;
                }
            }
        }

        public Produto GetItemPorCodigo(int codigo)
        {
            foreach (ItemEstoque item in itens)
            {
                if (item.Item.Codigo == codigo)
                {
                    return item.Item;
                }
            }
            return null;
        }

        public void EscreveEstoque()
        {
            itens.Sort((p1, p2) => p1.Item.Codigo.CompareTo(p2.Item.Codigo)); // printa sempre em ordem crescente de código
            foreach (ItemEstoque item in itens)
            {
                if (item.Item is Digital)
                {
                    Console.WriteLine($"Código: {item.Item.Codigo} / Produto: {item.Item.Descricao} / Valor unitário: R$ {item.Valor:F2}");

                }
                else
                {
                    Console.WriteLine($"Código: {item.Item.Codigo} / Produto: {item.Item.Descricao} / Quantidade: {item.Quantidade} / Valor unitário: R$ {item.Valor:F2}");
                }
            }
        }

        public ItemEstoque GetItem(int posicao)
        {
            return itens[posicao];
        }
    }
}
