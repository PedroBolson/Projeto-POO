using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class Perecivel : Produto
    {
        Data data;
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
            var data1 = data.DiasTotais(dataRef);
            var data2 = data.DiasTotais(this.DataValidade);

            if (data1 > data2)
            {
                Console.WriteLine($"Cuidado! No dia {dataRef} o produto estará vencido há");
                var data3 = data1 - data2;
                return data3;
            }
            else
            {
                Console.WriteLine($"A validade do produto até {dataRef} tem mais");
                var data3 = data2 - data1;
                return data3;
            }
        }

        public override void ExibirDetalhes()
        {
            Console.WriteLine($"Produto Perecível - Código: {Codigo}, Descrição: {Descricao}, Fabricante: {Fabricante}, Data de Validade: {DataValidade.ToString()}, Organico: {(Organico ? "Sim" : "Não")}, Ingredientes: {Ingredientes}");
        }
    }
}
