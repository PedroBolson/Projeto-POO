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
