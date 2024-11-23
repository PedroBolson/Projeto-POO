using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class Endereco
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

        public Endereco(string rua, int numero, string complemento, string bairro, string cep, string cidade, string uf)
        {
            this.Rua = rua;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Cep = cep;
            this.Cidade = cidade;
            this.Uf = uf;
        }
        public override string ToString()
        {
            return $" {Rua}, {Numero}, Complemento: {Complemento}, Bairro: {Bairro}, CEP: {Cep}, Cidade:{Cidade}, UF:{Uf}";
        }

    }
}
