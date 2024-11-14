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
        private ItemEstoque itemEstoque;
        Data data;
        EntradaDados entradaDados;
        CadProdutos cadProdutos;
        CadClientes cadClientes;
        Estoque estoque;

        private void EscreveMenu()
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
            cadProdutos = new CadProdutos();
            cadClientes = new CadClientes();
            entradaDados = new EntradaDados();
            estoque = new Estoque();
        }
        public void MenuOpcoes()
        {
            Console.WriteLine("Bem vindo ao sistema da Fake Enterprise LTDA");
            int opcao;
            this.EscreveMenu();
            opcao = entradaDados.LeInteiro("Opção: ", 1, 9);
            while (opcao != 9)
            {
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Qual o tipo de produto?");
                        Console.WriteLine("1 - Durável");
                        Console.WriteLine("2 - Digital");
                        Console.WriteLine("3 - Perecível");
                        int option = 0;
                        option = entradaDados.LeInteiro("Opção: ", 1, 3);
                        cadProdutos.CadastroPrduto(option);
                        break;
                    case 2:
                        Console.WriteLine("Produtos Duráveis");
                        Console.WriteLine("");
                        cadProdutos.PrintaProduto(1);
                        Console.WriteLine("_____________________________________");
                        Console.WriteLine("Produtos Digitais");
                        Console.WriteLine("");
                        cadProdutos.PrintaProduto(2);
                        Console.WriteLine("_____________________________________");
                        Console.WriteLine("Produtos Perecíveis");
                        Console.WriteLine("");
                        cadProdutos.PrintaProduto(3);
                        break;
                    case 3:
                        Console.WriteLine("Data para verificação de validade");
                        var data1 = entradaDados.LeData();
                        Console.WriteLine("Produtos perecíveis a vencer");
                        Console.WriteLine();
                        cadProdutos.ProdutosAVencer(data1);
                        break;
                    case 4:
                        cadClientes.CadastroCliente();
                        break;
                    case 5:
                        Console.WriteLine("Clientes");
                        cadClientes.PrintaClientes();
                        break;
                    case 6:
                        estoque.CadastroEstoque();
                        break;
                }
                Console.WriteLine("Digite qualquer tecla para continuar ...");
                Console.ReadKey();
                Console.Clear();
                this.EscreveMenu();
                opcao = entradaDados.LeInteiro("Opção: ", 1, 9);
            }
        }
    }
}
