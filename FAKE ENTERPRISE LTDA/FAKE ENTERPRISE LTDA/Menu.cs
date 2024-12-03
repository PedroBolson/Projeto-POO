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
            Console.WriteLine("1 - Cadastrar, alterar ou excluir um produto");
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
            var option = entradaDados.LeString("Deseja pré carregar dados à lista de Produtos e Clientes? (Sim) (Nao)", "Sim", "Nao");
            if (option == "Sim" || option == "sim")
            {
                cadProdutos.ComecaDados();
                cadClientes.ComecaDados();
                Console.WriteLine("Dados carregados com sucesso!");
                Thread.Sleep(900);
            }
            Console.Clear();
            int opcao;
            this.EscreveMenu();
            opcao = entradaDados.LeInteiro("Opção: ", 1, 9);
            while (opcao != 9)
            {
                switch (opcao)
                {
                    case 1:
                        this.Opcao1();
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
        private void Opcao1()
        {
            int opcao2, codigo;
            do
            {
                Console.Clear();
                Console.WriteLine("Digite uma opção: ");
                Console.WriteLine("1 - Cadastro de novo produto");
                Console.WriteLine("2 - Mudança de parâmetros");
                Console.WriteLine("3 - Excluir um produto");
                Console.WriteLine("0 - Retornar ao menu principal");
                opcao2 = entradaDados.LeInteiro("Opção: ");
                switch (opcao2)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Produtos já cadastrados:");
                        this.EscreveProdutos();
                        Console.WriteLine("Modo de cadastro de produtos");
                        this.AdicionaProduto();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Modo de alteração de dados de produto");
                        this.EscreveProdutos();
                        codigo = entradaDados.LeInteiro("Digite o código do produto a ser alterado(ou digite 0 para retornar ao menu anterior)");
                        if (codigo == 0)
                        {
                            break;
                        }
                        cadProdutos.MudancaParametros(codigo);
                        Thread.Sleep(1000);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Modo de exclusão de produtos!");
                        this.EscreveProdutos();
                        codigo = entradaDados.LeInteiro("Digite o código do produto a ser excluído(ou digite 0 para retornar ao menu anterior)");
                        if (codigo == 0)
                        {
                            break;
                        }
                        cadProdutos.ExcluiProduto(codigo);
                        Thread.Sleep(1200);
                        break;
                }
            } while (opcao2 != 0);

        }
        private void AdicionaProduto()
        {
            var contagem = cadProdutos.GetTamanho();
            int option;
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
                Console.WriteLine("0 - Retornar ao menu anterior");
                option = entradaDados.LeInteiro("Opção: ", 0, 3);
                if (option != 0)
                {
                    cadProdutos.CadastroPrduto(option);
                    Thread.Sleep(1000);
                }
            }
        }

        private void CadastroEstoque()
        {
            int codigo, novaQtd = 0;
            do
            {
                this.EscreveProdutos();
                codigo = entradaDados.LeInteiro("Digite o código para adicionar no estoque ou digite 0 para retornar ao menu principal");
                var produto = cadProdutos.BuscaProduto(codigo);
                if (estoque.VerificaEstoque(codigo))
                {
                    Console.WriteLine("Produto já encontrado em estoque!");
                    Console.WriteLine($"Valor unitário do protudo R${estoque.RetornaValorUnitario(codigo):F2}");
                    var control = entradaDados.LeString("Deseja alterar o valor unitário do produto? (Sim) (Nao)", "Sim", "Nao");
                    if (control == "Sim" || control == "sim")
                    {
                        var novoPreco = entradaDados.LeDouble("Digite o novo valor do produto: ");
                        estoque.AtualizaValor(codigo, novoPreco);
                    }
                    Console.WriteLine($"A quantidade de itens é {estoque.RetornaQuantidade(codigo)} produtos");
                    var mudanca = entradaDados.LeInteiro("Digite 1 para adicionar mais produtos, 2 para remover produtos ou 3 para não alterar a quantidade");
                    if (mudanca == 1)
                    {
                        novaQtd = entradaDados.LeInteiro("Digite quantos produtos gostaria de adicionar");
                        estoque.AumentaEstoque(codigo, novaQtd);
                    }
                    else if (mudanca == 2)
                    {
                        novaQtd = entradaDados.LeInteiro("Digite quantos produtos gostaria de remover");
                        estoque.AtualizaEstoque(codigo, novaQtd);

                    }
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
                    var valor = entradaDados.LeFloat("Digite o preço unitário do produto (utilizando virgula para centavos como por exemplo: 100,50)");
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
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            } while (codigo != 0);
        }
        private void ConfereValidade()
        {
            Data data1;
            var escolha = entradaDados.LeInteiro("Digite 1 para comparar com a data atual ou 2 para comparar com uma data de sua escolha", 1, 2);
            if (escolha == 2)
            {
                Console.WriteLine("Data para verificação de validade");
                data1 = entradaDados.LeData();
                Console.WriteLine("Produtos perecíveis a vencer");
                cadProdutos.ProdutosAVencer(data1);
            }
            else
            {
                DateTime agora = DateTime.Now;
                data1 = new Data(agora.Day, agora.Month, agora.Year);
                Console.WriteLine("Produtos perecíveis a vencer");
                cadProdutos.ProdutosAVencer(data1);
            }
        }
        private void EscreveProdutos()
        {
            Console.WriteLine("Produtos Duráveis");
            Console.WriteLine();
            cadProdutos.PrintaProduto(1);
            Console.WriteLine("______");
            Console.WriteLine("Produtos Digitais");
            Console.WriteLine();
            cadProdutos.PrintaProduto(2);
            Console.WriteLine("______");
            Console.WriteLine("Produtos Perecíveis");
            Console.WriteLine();
            cadProdutos.PrintaProduto(3);
            Console.WriteLine("______");
        }
        private void CadastroVenda()
        {
            int codigo1;
            double totalParcial;
            Cliente cliente1;
            int controle = 0;
            if (cadClientes.GetTamanho() == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado! por favor cadastre um cliente na opção 4 do menu.");
            }
            else if (estoque.GetTamanho() == 0)
            {
                Console.WriteLine("Nenhum item cadastrado em estoque!");
            }
            else
            {
                do
                {
                    Console.WriteLine("Clientes");
                    cadClientes.PrintaClientes();
                    codigo1 = entradaDados.LeInteiro("Digite o código de um cliente cadastrado(digite 0 caso queira cancelar e voltar ao menu):");
                    if (codigo1 == 0)
                    {
                        return;
                    }
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
                    Thread.Sleep(1000);
                    Console.Clear();
                } while (controle == 0);
                var vendas = new List<ItemVenda>();
                int codigo2;
                do
                {
                    Console.WriteLine("Checagem de estoque!");
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
                    Thread.Sleep(1000);
                    Console.Clear();
                } while (codigo2 != 0);
                Data dataVenda;
                var escolha = entradaDados.LeInteiro("Digite 1 caso a venda seja na data atual ou 2 para inserir uma data de sua escolha", 1, 2);
                if (escolha == 2)
                {
                    Console.WriteLine("Data de venda");
                    dataVenda = entradaDados.LeData();
                }
                else
                {
                    DateTime agora = DateTime.Now;
                    dataVenda = new Data(agora.Day, agora.Month, agora.Year);
                }
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
