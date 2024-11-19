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
        private ItemVenda itemVenda;
        private Venda venda;
        Data data;
        EntradaDados entradaDados;
        CadVendas cadVendas;
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
            cadVendas = new CadVendas();
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
                        Console.WriteLine(new string('-', 30));
                        Console.WriteLine("Produtos Digitais");
                        Console.WriteLine("");
                        cadProdutos.PrintaProduto(2);
                        Console.WriteLine(new string('-', 30));
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
                        Console.WriteLine("Produtos Duráveis");
                        Console.WriteLine("");
                        cadProdutos.PrintaProduto(1);
                        Console.WriteLine(new string('-', 30));
                        Console.WriteLine("Produtos Digitais");
                        Console.WriteLine("");
                        cadProdutos.PrintaProduto(2);
                        Console.WriteLine(new string('-', 30));
                        Console.WriteLine("Produtos Perecíveis");
                        Console.WriteLine("");
                        cadProdutos.PrintaProduto(3);
                        int codigo;
                        do
                        {
                            codigo = entradaDados.LeInteiro("Digite o(s) códigos para adicionar no estoque ou digite 0 para SAIR");
                            var produto = cadProdutos.BuscaProduto(codigo);
                            if (produto != null)
                            {
                                var quantidade = entradaDados.LeInteiro("Digite a quantidade de produtos");
                                var valor = entradaDados.LeFloat("Digite o preço unitário do produto");
                                var item = new ItemEstoque(produto, quantidade, valor);
                                estoque.Insere(item);
                                Console.WriteLine("Produto cadastrado com sucesso!");
                            }

                        } while (codigo != 0);
                        break;
                    case 7:
                        Cliente cliente1;
                        Console.WriteLine("Clientes");
                        cadClientes.PrintaClientes();
                        Console.WriteLine("Digite o código de um cliente cadastrado");
                        int controle = 0;
                        do
                        {
                            var codigo1 = entradaDados.LeInteiro("Código");
                            cliente1 = cadClientes.BuscaCliente(codigo1);
                            if (cliente1 != null)
                            {
                                controle = 1;
                            }
                            else
                            {
                                Console.WriteLine("Cliente não encontrado!");
                            }
                        } while (controle == 0);
                        Console.WriteLine("Checagem de estoque para os produtos, por favor digite os códigos de cada produto");
                        int[] codigos = new int[100];
                        int[] quantidades = new int[100];
                        int codigo2, i = 0;
                        do
                        {

                            Console.WriteLine("Informe o código do produto vendido, para continuar a venda digite 0");
                            codigo2 = entradaDados.LeInteiro("Código");
                            if (estoque.VerificaEstoque(codigo2))
                            {
                                Console.WriteLine("Produto encontrado no estoque!");
                                var quantidade1 = entradaDados.LeInteiro("Digite a quantidade de itens");
                                if (estoque.VerificaEstoque(codigo2, quantidade1))
                                {
                                    Console.WriteLine("Quantidade de itens disponível em estoque!");
                                    codigos[i] = codigo2;
                                    quantidades[i] = quantidade1;
                                    i++;
                                }
                                else
                                {
                                    Console.WriteLine("Quantidade insuficiente em estoque");
                                }
                            }
                            else if (codigo2 != 0)
                            {
                                Console.WriteLine("Produto não encontrado em estoque");
                            }
                            Console.WriteLine("Informe a data de venda");
                        } while (codigo2 != 0);
                        var dataVenda = entradaDados.LeData();
                        double total = 0.0;
                        for (int j = 0; j < i; j++)
                        {
                            var aux = codigos[j];
                            var totalParcial = estoque.RetornaValorUnitario(aux);
                            if( totalParcial != 0.0)
                            {
                                totalParcial = totalParcial * quantidades[j];
                                estoque.AtualizaEstoque(codigos[j], quantidades[j]);
                                total += totalParcial;
                            }
                            else 
                            {
                                Console.WriteLine($"Valor unitário do produto com código {codigos[j]} não encontrado!");
                            }
                        }
                        var venda1 = new Venda(cliente1, dataVenda, total);
                        cadVendas.Insere(venda1);
                        break;
                    case 8:
                        if (cadVendas.GetVenda(0) == null)
                        {
                            Console.WriteLine("Nenhuma venda cadastrada.");
                            return;
                        }

                        Console.WriteLine("Lista de Vendas:");
                        for (int j = 0; j < cadVendas.GetTamanho(); j++)
                        {
                            var vendas = cadVendas.GetVenda(j);
                            Console.WriteLine($"Cliente: {vendas.Cliente.Nome} (Código: {vendas.Cliente.Codigo})");
                            Console.WriteLine($"Data da Venda: {vendas.DataVenda}");
                            Console.WriteLine($"Valor Total: R$ {vendas.ValorTotal:F2}");
                            Console.WriteLine("Itens Vendidos:");
                            foreach (ItemVenda item in vendas.Itens)
                            {
                                Console.WriteLine($"- Produto:");
                                item.Item.ExibirDetalhes();
                                Console.WriteLine($"  Quantidade: {item.Quantidade}");
                                Console.WriteLine($"  Valor Unitário: R$ {item.Valor:F2}");
                                Console.WriteLine($"  Valor Total: R$ {item.Valor * item.Quantidade:F2}");
                            }

                            Console.WriteLine(new string('-', 30));
                        }
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
