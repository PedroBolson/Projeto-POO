using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class CadProdutos
    {
        EntradaDados entradaDados = new EntradaDados();
        protected List<Produto> produtos = new List<Produto>();

        public void ComecaDados()
        {
            var duravel = new Duravel(1000, "Telefone S24 Ultra 256GB", "Samsung", 60, "Titânio e vidro", false);
            this.Insere(duravel);
            duravel = new Duravel(1001, "Galaxy Book Ultra", "Samsung", 60, "Alumínio", false);
            this.Insere(duravel);
            var digital = new Digital(2000, "Cartão presente spotify 30 dias", "Spotify", 0, "Código de resgate online", "amazon.com.br/produto/cartão_presente_spotify");
            this.Insere(digital);
            digital = new Digital(2001, "Black Myth: Wukong", "Game Science", 118000, "Jogo digital", "steam.com.br/game/blackmythwukong");
            this.Insere(digital);
            var date = new Data(12, 12, 2027);
            var perecivel = new Perecivel(3000, "Iogurte", "Batavo", date, true, "Derivados do leite");
            this.Insere(perecivel);
            date = new Data(01, 05, 2025);
            perecivel = new Perecivel(3001, "Frango", "Nat", date, true, "Frango");
            this.Insere(perecivel);
            date = new Data(10, 01, 2017);
            perecivel = new Perecivel(3002, "Ovos", "Naturovos", date, true, "Ovo");
            this.Insere(perecivel);
        }

        public bool ConfereDigital(int codigo)
        {
            foreach(Produto produto in produtos)
            {
                if(produto.Codigo == codigo)
                {
                    if(produto is Digital)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ConfereCodigo(int codigo)
        {
            foreach (Produto produto in produtos)
            {
                if (produto.Codigo == codigo)
                    return false;
            }
            return true;
        }

        public Produto BuscaProduto(int codigo)
        {
            foreach (Produto produto in produtos)
            {
                if (produto.Codigo == codigo)
                {
                    return produto;
                }
            }
            return null;
        }

        public void ExcluiProduto(int codigo)
        {
            if (ConfereCodigo(codigo))
            {
                Console.WriteLine("Produto não encontrado!");
            }
            else
            {
                produtos.RemoveAll(p => p.Codigo == codigo);
                Console.WriteLine("Produto excluído!");
            }
        }

        public void MudancaParametros(int codigo)
        {
            int escolha = 1, cod;
            bool verifica;
            bool organico1 = false, manutencao1 = false, produtoEncontrado = false;
            foreach (Produto produto in produtos)
            {
                if (produto.Codigo == codigo)
                {
                    produtoEncontrado = true;
                    if (produto is Perecivel perecivel)
                    {
                        Console.Clear();
                        perecivel.ExibirDetalhes();
                        Console.WriteLine("O que desejaria mudar? Escolha uma opção");
                        Console.WriteLine("1 - Código");
                        Console.WriteLine("2 - Descrição");
                        Console.WriteLine("3 - Fabricante");
                        Console.WriteLine("4 - Data de validade");
                        Console.WriteLine("5 - Orgânico");
                        Console.WriteLine("6 - Ingredientes");
                        Console.WriteLine("0 - Cancelar alteração");
                        escolha = entradaDados.LeInteiro("Opção: ", 0, 6);
                        switch (escolha)
                        {
                            case 0:
                                break;
                            case 1:
                                do
                                {
                                    cod = entradaDados.LeInteiro("Digite o código do produto: ");
                                    verifica = this.ConfereCodigo(cod);
                                    if (!verifica)
                                    {
                                        Console.WriteLine("Código de produto já existe!");
                                    }
                                } while (!verifica);
                                perecivel.Codigo = cod;
                                break;
                            case 2:
                                var descricao = entradaDados.LeString("Digite a descrição do produto");
                                perecivel.Descricao = descricao;
                                break;
                            case 3:
                                var fabricante = entradaDados.LeString("Digite o fabricante");
                                perecivel.Fabricante = fabricante;
                                break;
                            case 4:
                                Console.WriteLine("Nova data de validade");
                                var dataValidade = entradaDados.LeData();
                                perecivel.DataValidade = dataValidade;
                                break;
                            case 5:
                                var organico = entradaDados.LeString("O produto é orgânico? (Sim) ou (Nao) - Favor não usar acentos", "Sim", "Nao");
                                if (organico == "Sim" || organico == "sim")
                                {
                                    organico1 = true;
                                }
                                perecivel.Organico = organico1;
                                break;
                            case 6:
                                var ingredientes = entradaDados.LeString("Digite os ingredientes: ");
                                perecivel.Ingredientes = ingredientes;
                                break;
                        }
                    }
                    else if (produto is Duravel duravel)
                    {
                        Console.Clear();
                        duravel.ExibirDetalhes();
                        Console.WriteLine("O que desejaria mudar? Escolha uma opção");
                        Console.WriteLine("1 - Código");
                        Console.WriteLine("2 - Descrição");
                        Console.WriteLine("3 - Fabricante");
                        Console.WriteLine("4 - Garantia");
                        Console.WriteLine("5 - Material");
                        Console.WriteLine("6 - Manutenção");
                        Console.WriteLine("0 - Cancelar alteração");
                        escolha = entradaDados.LeInteiro("Opção: ", 0, 6);
                        switch (escolha)
                        {
                            case 0:
                                break;
                            case 1:
                                do
                                {
                                    cod = entradaDados.LeInteiro("Digite o código do produto: ");
                                    verifica = this.ConfereCodigo(cod);
                                    if (!verifica)
                                    {
                                        Console.WriteLine("Código de produto já existe!");
                                    }
                                } while (!verifica);
                                duravel.Codigo = cod;
                                break;
                            case 2:
                                var descricao = entradaDados.LeString("Digite a descrição do produto");
                                duravel.Descricao = descricao;
                                break;
                            case 3:
                                var fabricante = entradaDados.LeString("Digite o fabricante");
                                duravel.Fabricante = fabricante;
                                break;
                            case 4:
                                var garantia = entradaDados.LeInteiro("Digite o tempo de garantia em meses");
                                duravel.Garantia = garantia;
                                break;
                            case 5:
                                var material = entradaDados.LeString("Digite o material do produto: ");
                                duravel.Material = material;
                                break;
                            case 6:
                                var manutencao = entradaDados.LeString("O produto precisa de manutenção? (Sim) (Nao) - Favor não usar acentos", "Sim", "Nao");
                                if (manutencao == "Sim" || manutencao == "sim")
                                {
                                    manutencao1 = true;
                                }
                                duravel.Manutencao = manutencao1;
                                break;
                        }
                    }
                    else if (produto is Digital digital)
                    {
                        Console.Clear();
                        digital.ExibirDetalhes();
                        Console.WriteLine("O que desejaria mudar? Escolha uma opção");
                        Console.WriteLine("1 - Código");
                        Console.WriteLine("2 - Descrição");
                        Console.WriteLine("3 - Fabricante");
                        Console.WriteLine("4 - Tamanho");
                        Console.WriteLine("5 - Formato");
                        Console.WriteLine("6 - Link");
                        Console.WriteLine("0 - Cancelar alteração");
                        escolha = entradaDados.LeInteiro("Opção: ", 0, 6);
                        switch (escolha)
                        {
                            case 0:
                                break;
                            case 1:
                                do
                                {
                                    cod = entradaDados.LeInteiro("Digite o código do produto: ");
                                    verifica = this.ConfereCodigo(cod);
                                    if (!verifica)
                                    {
                                        Console.WriteLine("Código de produto já existe!");
                                    }
                                } while (!verifica);
                                digital.Codigo = cod;
                                break;
                            case 2:
                                var descricao = entradaDados.LeString("Digite a descrição do produto");
                                digital.Descricao = descricao;
                                break;
                            case 3:
                                var fabricante = entradaDados.LeString("Digite o fabricante");
                                digital.Fabricante = fabricante;
                                break;
                            case 4:
                                var tamanho = entradaDados.LeFloat("Digite o tamanho do produto(MB)");
                                digital.Tamanho = tamanho;
                                break;
                            case 5:
                                var formato = entradaDados.LeString("Digite o formato do produto");
                                digital.Formato = formato;
                                break;
                            case 6:
                                var link = entradaDados.LeString("Digite o link do produto");
                                digital.Link = link;
                                break;
                        }
                    }
                    break;
                }
            }
            if (!produtoEncontrado)
            {
                Console.WriteLine("Produto não encontrado");
            }
        }
        public void Insere(Produto prod)
        {
            produtos.Add(prod);
        }
        public Produto GetProduto(int posicao)
        {
            return produtos[posicao];
        }
        public int GetTamanho()
        {
            return produtos.Count;
        }

        public void PrintaProduto(Produto produto)
        {
            produto.ExibirDetalhes();
        }
        public void PrintaProduto(int referencia)
        {
            produtos.Sort((p1, p2) => p1.Codigo.CompareTo(p2.Codigo)); // printa sempre em ordem crescente de código

            switch (referencia)
            {
                case 1:
                    foreach (Produto produto in produtos)
                    {
                        if (produto is Duravel duravel)
                        {
                            duravel.ExibirDetalhes();
                            Console.WriteLine();
                        }
                    }
                    break;
                case 2:
                    foreach (Produto produto in produtos)
                    {
                        if (produto is Digital digital)
                        {
                            digital.ExibirDetalhes();
                            Console.WriteLine();
                        }
                    }
                    break;
                case 3:
                    foreach (Produto produto in produtos)
                    {
                        if (produto is Perecivel perecivel)
                        {
                            perecivel.ExibirDetalhes();
                            Console.WriteLine();
                        }
                    }
                    break;
            }
        }

        public void CadastroPrduto(int tipo)
        {
            int codigo;
            bool verifica;
            string descricao, fabricante;
            switch (tipo)
            {
                case 1:
                    bool manutencao1 = false;
                    do
                    {
                        codigo = entradaDados.LeInteiro("Digite o código do produto(digite 0 para cancelar e voltar ao menu de alterações de produtos): ");
                        verifica = this.ConfereCodigo(codigo);
                        if (!verifica)
                        {
                            Console.WriteLine("Código de produto já existe!");
                        }
                    } while (!verifica);
                    if (codigo == 0)
                    {
                        break;
                    }
                    descricao = entradaDados.LeString("Digite a descrição do produto");
                    fabricante = entradaDados.LeString("Digite o fabricante");
                    var garantia = entradaDados.LeInteiro("Digite o tempo de garantia em meses");
                    var material = entradaDados.LeString("Digite o material do produto: ");
                    var manutencao = entradaDados.LeString("O produto precisa de manutenção? (Sim) (Nao) - Favor não usar acentos", "Sim", "Nao");
                    if (manutencao == "Sim" || manutencao == "sim")
                    {
                        manutencao1 = true;
                    }
                    var produto1 = new Duravel(codigo, descricao, fabricante, garantia, material, manutencao1);
                    this.Insere(produto1);
                    Console.WriteLine("Produto cadastrado com sucesso!");
                    break;
                case 2:
                    do
                    {
                        codigo = entradaDados.LeInteiro("Digite o código do produto(digite 0 para cancelar e voltar ao menu de alterações de produtos): ");
                        verifica = this.ConfereCodigo(codigo);
                        if (!verifica)
                        {
                            Console.WriteLine("Código de produto já existe!");
                        }
                    } while (!verifica);
                    if (codigo == 0)
                    {
                        break;
                    }
                    descricao = entradaDados.LeString("Digite a descrição do produto");
                    fabricante = entradaDados.LeString("Digite o fabricante");
                    var tamanho = entradaDados.LeFloat("Digite o tamanho do produto(MB)");
                    var formato = entradaDados.LeString("Digite o formato do produto");
                    var link = entradaDados.LeString("Digite o link do produto");
                    var produto2 = new Digital(codigo, descricao, fabricante, tamanho, formato, link);
                    this.Insere(produto2);
                    Console.WriteLine("Produto cadastrado com sucesso!");
                    break;
                case 3:
                    bool organico1 = false;
                    do
                    {
                        codigo = entradaDados.LeInteiro("Digite o código do produto(digite 0 para cancelar e voltar ao menu de alterações de produtos): ");
                        verifica = this.ConfereCodigo(codigo);
                        if (!verifica)
                        {
                            Console.WriteLine("Código de produto já existe!");
                        }
                    } while (!verifica);
                    if (codigo == 0)
                    {
                        break;
                    }
                    descricao = entradaDados.LeString("Digite a descrição do produto");
                    fabricante = entradaDados.LeString("Digite o fabricante");
                    Console.WriteLine("Data de validade");
                    var dataValidade = entradaDados.LeData();
                    var organico = entradaDados.LeString("O produto é orgânico? (Sim) ou (Nao) - Favor não usar acentos", "Sim", "Nao");
                    if (organico == "Sim" || organico == "sim")
                    {
                        organico1 = true;
                    }
                    var ingredientes = entradaDados.LeString("Digite os ingredientes: ");
                    var produto3 = new Perecivel(codigo, descricao, fabricante, dataValidade, organico1, ingredientes);
                    this.Insere(produto3);
                    Console.WriteLine("Produto cadastrado com sucesso!");
                    break;
                default:
                    throw new Exception("Tipo inválido");
            }
        }

        public void ProdutosAVencer(Data referencia)
        {
            foreach (Produto produto in produtos)
            {
                if (produto is Perecivel perecivel)
                {
                    Console.WriteLine();
                    perecivel.ExibirDetalhes();
                    var dias = perecivel.DiasAteVencimento(referencia);
                    Console.WriteLine($" {dias} dias");
                    Console.WriteLine("_________________");
                }
            }
        }
    }
}
