using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class Perecivel : Produto
    {
        Data data = new Data();
        public Data DataValidade { get; set; }
        public bool Organico { get; set; }
        public string Ingredientes { get; set; }

        public Perecivel(int codigo, string descricao, string fabricante, Data dataValidade, bool organico, string ingredientes) : base(codigo, descricao, fabricante)
        {
            this.DataValidade = dataValidade;
            this.Organico = organico;
            this.Ingredientes = ingredientes;
        }
        public int DiasAteVencimento(Data dataRef)
        {
            int data1 = 0;
            int data2 = 0;
            data1 = data.DiasTotais(dataRef);
            data2 = data.DiasTotais(this.DataValidade);

            if (data1 > data2)
            {
                Console.Write($"Cuidado! Em {dataRef} o produto estará vencido há");
                var data3 = data1 - data2;
                return data3;
            }
            else
            {
                Console.Write($"A validade do produto em {dataRef} terá mais");
                var data3 = data2 - data1;
                return data3;
            }
        }

        public override void ExibirDetalhes()
        {
            Console.WriteLine($"Código: {Codigo}, Descrição: {Descricao}, Fabricante: {Fabricante}, Data de Validade: {DataValidade.ToString()}, Organico: {(Organico ? "Sim" : "Não")}, Ingredientes: {Ingredientes}");
        }
    }
}
