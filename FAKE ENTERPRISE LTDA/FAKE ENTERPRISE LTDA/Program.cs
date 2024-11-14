using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class Program
    {
        private Duravel duravel;
        private Digital digital;
        private Perecivel perecivel;
        static void Main(string[] args)
        {
            CadProdutos cadProdutos = new CadProdutos();
            var data3 = new Data(20, 3, 2025);
            var data1 = new Data(31, 2, 2040);
            var produto1 = new Duravel(1, "Telefone", "Samsung", 2030, "Titânio", false);
            var produto2 = new Digital(2, "Cartão presente", "Netflix", 0, "Código de resgate digital", "amazon.com.br/cupom_Netflix");
            var produto3 = new Perecivel(3, "Leite", "CCGL", data3, true, "Leite e derivados");
            cadProdutos.Insere(produto1);
            cadProdutos.Insere(produto2);
            cadProdutos.Insere(produto3);

            for (int i = 0; i < 3; i++) 
            {
                var produto = cadProdutos.GetProduto(i);
                produto.ExibirDetalhes();
            }
            Console.ReadKey();
        }
    }
}

