using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public abstract class Produto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Fabricante { get; set; }
        protected Produto(int codigo, string descricao, string fabricante)
        {
            this.Codigo = codigo;
            this.Descricao = descricao;
            this.Fabricante = fabricante;
        }
        public abstract void ExibirDetalhes();
    }
}
