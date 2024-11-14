using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public string FoneRes { get; set; }
        public string FoneCelular { get; set; }
        public Data Nascimento { get; set; }

        public Cliente(int codigo, string nome, Endereco endereco, string foneRes, string foneCelular, Data nascimento)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Endereco = endereco;
            this.FoneRes = foneRes;
            this.FoneCelular = foneCelular;
            this.Nascimento = nascimento;
        }
    }
}
