using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class Menu
    {
        private Duravel duravel;
        private Digital digital;
        private Perecivel perecivel;
        private Cliente cliente;
        CadProdutos cadProdutos = new CadProdutos();
        CadClientes cadClientes = new CadClientes();

        private void PrintaMenu()
        {
            Console.WriteLine("Por favor, escolha uma opção:");
            Console.WriteLine("1 - Cadastrar um produto");
            Console.WriteLine("2 - Listar produtos");
            Console.WriteLine("3 - Informar data e comparar validade de produtos perecíveis");
            Console.WriteLine("4 - Cadastrar cliente");
            Console.WriteLine("5 - Listar clientes");
            Console.WriteLine("6 - Cadastrar estoque");
            Console.WriteLine("7 - Cadastrar uma venda");
            Console.WriteLine("8 - Listar vendas");
            Console.WriteLine("9 - Sair");
        }

        public Menu()
        {
            Console.WriteLine("Bem vindo ao sistema da Fake Enterprise LTDA");
            this.PrintaMenu();
            var opcao = 0;
            do
            {

            } while (opcao != 7);
        }
    }
}
