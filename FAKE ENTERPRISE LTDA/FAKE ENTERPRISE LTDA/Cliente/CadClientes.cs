using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class CadClientes
    {
        private List<Cliente> clientes = new List<Cliente>();
        EntradaDados entradaDados = new EntradaDados();

        public void ComecaDados()
        {
            var endereco = new Endereco("Avenida Rio Branco", 1096, "Apto 901", "Rio Branco", "95090-200", "Caxias do sul", "RS");
            var date = new Data(12, 11, 1998);
            var cliente = new Cliente(1000, "Pedro Bolson", endereco, "54 3029-5158", "54 99980-9543", date);
            this.Insere(cliente);
            date = new Data(18, 06, 1954);
            cliente = new Cliente(1001, "Roberto Bolson", endereco, "54 3029-5158", "54 99963-7865", date);
            this.Insere(cliente);
        }
        public void Insere(Cliente cliente)
        {
            clientes.Add(cliente);
        }
        public int GetTamanho()
        {
            return clientes.Count;
        }
        public Cliente BuscaCliente(int codigo)
        {
            foreach(Cliente cliente in clientes)
            {
                if(cliente.Codigo == codigo)
                {
                    return cliente;
                }
            }
            return null;
        }

        public Cliente GetCliente(int posicao)
        {
            return clientes[posicao];
        }

        public bool ConfereCodigo(int codigo)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.Codigo == codigo)
                    return false;
            }
            return true;
        }

        public void CadastroCliente()
        {
            bool verifica;
            int codigo;
            do
            {
                codigo = entradaDados.LeInteiro("Digite o código do cliente: ");
                verifica = this.ConfereCodigo(codigo);
                if (!verifica)
                {
                    Console.WriteLine("Código de cliente já existe!");
                }
            } while (!verifica);
            var nome = entradaDados.LeString("Nome do cliente:");
            var rua = entradaDados.LeString("Rua de residência:");
            var numero = entradaDados.LeInteiro("Número da residência:");
            var complemento = entradaDados.LeString("Complemento:");
            var bairro = entradaDados.LeString("Bairro:");
            var cep = entradaDados.LeString("CEP:");
            var cidade = entradaDados.LeString("Cidade:");
            var uf = entradaDados.LeString("UF:");
            var endereco = new Endereco(rua, numero, complemento, bairro, cep, cidade, uf);
            var foneRes = entradaDados.LeString("Telefone residencial:");
            var foneCel = entradaDados.LeString("Telefone celular:");
            Console.WriteLine("Data de nascimento");
            var nascimento = entradaDados.LeData();
            var cliente = new Cliente(codigo, nome, endereco, foneRes, foneCel, nascimento);
            this.Insere(cliente);
        }

        public void PrintaClientes()
        {
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"Código: {cliente.Codigo}, Nome: {cliente.Nome}");
                Console.WriteLine($"Data de nascimento: {cliente.Nascimento}");
                Console.WriteLine($"Endereço: {cliente.Endereco.ToString()}");
                Console.WriteLine($"Fone Residencial: {cliente.FoneRes}, Fone Celular: {cliente.FoneCelular}");
                Console.WriteLine("___________");
            }
        }
    }
}
