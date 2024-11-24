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
            var date = new Data(12,12,2027);
            var perecivel = new Perecivel(3000, "Iogurte", "Batavo", date, true, "Derivados do leite");
            this.Insere(perecivel);
            date = new Data(01, 05, 2025);
            perecivel = new Perecivel(3001, "Frango", "Nat", date, true, "Frango");
            this.Insere(perecivel);
            date = new Data(10, 01, 2017);
            perecivel = new Perecivel(3002, "Ovos", "Naturovos", date, true, "Ovo");
            this.Insere(perecivel);
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
                        codigo = entradaDados.LeInteiro("Digite o código do produto: ");
                        verifica = this.ConfereCodigo(codigo);
                        if (!verifica)
                        {
                            Console.WriteLine("Código de produto já existe!");
                        }
                    } while (!verifica);
                    descricao = entradaDados.LeString("Digite a descrição do produto");
                    fabricante = entradaDados.LeString("Digite o fabricante");
                    var garantia = entradaDados.LeInteiro("Digite o tempo de garantia em meses");
                    var material = entradaDados.LeString("Digite o material do produto: ");
                    var manutencao = entradaDados.LeString("O produto possui manutenção? (Sim) (Nao) - Favor não usar acentos", "Sim", "Nao");
                    if (manutencao == "Sim" || manutencao == "sim")
                    {
                        manutencao1 = true;
                    }
                    var produto1 = new Duravel(codigo, descricao, fabricante, garantia, material, manutencao1);
                    this.Insere(produto1);
                    break;
                case 2:
                    do
                    {
                        codigo = entradaDados.LeInteiro("Digite o código do produto: ");
                        verifica = this.ConfereCodigo(codigo);
                        if (!verifica)
                        {
                            Console.WriteLine("Código de produto já existe!");
                        }
                    } while (!verifica);
                    descricao = entradaDados.LeString("Digite a descrição do produto");
                    fabricante = entradaDados.LeString("Digite o fabricante");
                    var tamanho = entradaDados.LeFloat("Digite o tamanho do produto(MB)");
                    var formato = entradaDados.LeString("Digite o formato do produto");
                    var link = entradaDados.LeString("Digite o link do produto");
                    var produto2 = new Digital(codigo, descricao, fabricante, tamanho, formato, link);
                    this.Insere(produto2);
                    break;
                case 3:
                    bool organico1 = false;
                    do
                    {
                        codigo = entradaDados.LeInteiro("Digite o código do produto: ");
                        verifica = this.ConfereCodigo(codigo);
                        if (!verifica)
                        {
                            Console.WriteLine("Código de produto já existe!");
                        }
                    } while (!verifica);
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
