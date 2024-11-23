using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class Menu
    {
        private CadProdutos cadProdutos;
        private CadClientes cadClientes;
        private Estoque estoque;
        private CadVendas cadVendas;
        EntradaDados entradaDados;
        double total;
        public Menu()
        {
            cadProdutos = new CadProdutos();
            cadClientes = new CadClientes();
            estoque = new Estoque();
            cadVendas = new CadVendas();
            entradaDados = new EntradaDados();
        }
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
                        this.AdicionaProduto();
                        break;
                    case 2:
                        this.EscreveProdutos();
                        break;
                    case 3:
                        this.ConfereValidade();
                        break;
                    case 4:
                        cadClientes.CadastroCliente();
                        break;
                    case 5:
                        Console.WriteLine("Clientes");
                        cadClientes.PrintaClientes();
                        break;
                    case 6:
                        this.CadastroEstoque();
                        break;
                    case 7:
                        this.CadastroVenda();
                        break;
                    case 8:
                        cadVendas.ListarVendas();
                        break;
                }
                Console.WriteLine("Digite qualquer tecla para continuar ...");
                Console.ReadKey();
                Console.Clear();
                this.EscreveMenu();
                opcao = entradaDados.LeInteiro("Opção: ", 1, 9);
            }
        }
        private void AdicionaProduto()
        {
            var contagem = cadProdutos.GetTamanho();
            if (contagem > 100)
            {
                Console.WriteLine("Limite de produtos atingido!");
            }
            else
            {
                Console.WriteLine("Qual o tipo de produto?");
                Console.WriteLine("1 - Durável");
                Console.WriteLine("2 - Digital");
                Console.WriteLine("3 - Perecível");
                int option = 0;
                option = entradaDados.LeInteiro("Opção: ", 1, 3);
                cadProdutos.CadastroPrduto(option);
                Console.WriteLine("Produto cadastrado com sucesso!");
            }
        }
        private void CadastroEstoque()
        {
            int codigo;
            do
            {
                this.EscreveProdutos();
                codigo = entradaDados.LeInteiro("Digite o código para adicionar no estoque ou digite 0 para retornar ao menu principal");
                var produto = cadProdutos.BuscaProduto(codigo);
                if (estoque.VerificaEstoque(codigo))
                {
                    Console.WriteLine("Produto já encontrado em estoque!");
                    Console.WriteLine($"Valor unitário do protudo R${estoque.RetornaValorUnitario(codigo):F2}");
                    var control = entradaDados.LeInteiro("Deseja alterar o valor? 1 - sim / 2 - não", 1, 2);
                    if (control == 1)
                    {
                        var novoPreco = entradaDados.LeDouble("Digite o novo valor do produto: ");
                        estoque.AtualizaValor(codigo, novoPreco);
                    }
                    var novaQtd = entradaDados.LeInteiro("Digite quantos produtos gostaria de adicionar a mais");
                    estoque.AumentaEstoque(codigo, novaQtd);
                    Console.WriteLine("______");
                    Console.WriteLine("Produtos em estoque:");
                    estoque.EscreveEstoque();
                    Console.WriteLine("Digite qualquer tecla para continuar ...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (produto != null && codigo != 0)
                {
                    var quantidade = entradaDados.LeInteiro("Digite a quantidade de produtos");
                    var valor = entradaDados.LeFloat("Digite o preço unitário do produto");
                    var item = new ItemEstoque(produto, quantidade, valor);
                    estoque.Insere(item);
                    Console.WriteLine("Produto cadastrado com sucesso!");
                    Console.WriteLine("______");
                    Console.WriteLine("Produtos em estoque:");
                    estoque.EscreveEstoque();
                    Console.WriteLine("Digite qualquer tecla para continuar ...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (codigo != 0)
                {
                    Console.WriteLine("Produto não encontrado!");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            } while (codigo != 0);
        }
        private void ConfereValidade()
        {
            Console.WriteLine("Data para verificação de validade");
            var data1 = entradaDados.LeData();
            Console.WriteLine("Produtos perecíveis a vencer");
            Console.WriteLine();
            cadProdutos.ProdutosAVencer(data1);
        }
        private void EscreveProdutos()
        {
            Console.WriteLine("Produtos Duráveis");
            Console.WriteLine("");
            cadProdutos.PrintaProduto(1);
            Console.WriteLine("______");
            Console.WriteLine("Produtos Digitais");
            Console.WriteLine("");
            cadProdutos.PrintaProduto(2);
            Console.WriteLine("______");
            Console.WriteLine("Produtos Perecíveis");
            cadProdutos.PrintaProduto(3);
            Console.WriteLine("______");
        }
        private void CadastroVenda()
        {
            double totalParcial;
            Cliente cliente1;
            int controle = 0;
            if (cadClientes.GetTamanho() == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado! por favor cadastre um cliente na opção 4 do menu.");
            }
            else if(estoque.GetTamanho() == 0)
            {
                Console.WriteLine("Nenhum item cadastrado em estoque!");
            }
            else
            {
                do
                {
                    Console.WriteLine("Clientes");
                    cadClientes.PrintaClientes();
                    var codigo1 = entradaDados.LeInteiro("Digite o código de um cliente cadastrado:");
                    cliente1 = cadClientes.BuscaCliente(codigo1);
                    if (cliente1 != null)
                    {
                        controle = 1;
                        Console.WriteLine("Cliente selecionado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Cliente não encontrado!");
                    }
                    Thread.Sleep(1500);
                    Console.Clear();
                } while (controle == 0);
                Console.WriteLine("Checagem de estoque!");
                var vendas = new List<ItemVenda>();
                int codigo2;
                do
                {
                    estoque.EscreveEstoque();
                    codigo2 = entradaDados.LeInteiro("Informe o código do produto vendido ou digite 0 para finalizar a venda!");
                    if (estoque.VerificaEstoque(codigo2))
                    {
                        var quantidade1 = entradaDados.LeInteiro("Digite a quantidade de itens");
                        if (estoque.VerificaEstoque(codigo2, quantidade1))
                        {
                            Console.WriteLine("Quantidade de itens disponível em estoque!");
                            totalParcial = estoque.RetornaValorUnitario(codigo2);
                            var item = new ItemVenda(estoque.GetItemPorCodigo(codigo2), quantidade1, totalParcial * quantidade1);
                            estoque.AtualizaEstoque(codigo2, quantidade1);
                            vendas.Add(item);
                            Console.WriteLine("Produto(s) adicionado a venda com sucesso!");
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
                    Thread.Sleep(1500);
                    Console.Clear();
                } while (codigo2 != 0);
                Console.WriteLine("Data de venda");
                var dataVenda = entradaDados.LeData();
                total = 0.0;
                foreach (ItemVenda item in vendas)
                {
                    total = total + item.Valor;
                }
                var venda1 = new Venda(vendas, cliente1, dataVenda, total);
                cadVendas.Insere(venda1);
            }
        }
    }
}
