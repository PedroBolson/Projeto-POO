﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class CadClientes
    {
        private List<Cliente> clientes = new List<Cliente>();
        EntradaDados entradaDados = new EntradaDados();

        public void Insere(Cliente cliente)
        {
            clientes.Add(cliente);
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
