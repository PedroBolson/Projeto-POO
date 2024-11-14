using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class Digital : Produto
    {

        public float Tamanho { get; set; }
        public string Formato { get; set; }
        public string Link { get; set; }

        public Digital(int codigo, string descricao, string fabricante, float tamanho, string formato, string link) : base(codigo, descricao, fabricante)
        {
            this.Tamanho = tamanho;
            this.Formato = formato;
            this.Link = link;
        }


        public override void ExibirDetalhes()
        {
            Console.WriteLine($"Produto Digital - Código: {Codigo}, Descrição: {Descricao}, Fabricante: {Fabricante}, Tamanho: {Tamanho}, Formato: {Formato}, Link: {Link}");
        }
    }
}
