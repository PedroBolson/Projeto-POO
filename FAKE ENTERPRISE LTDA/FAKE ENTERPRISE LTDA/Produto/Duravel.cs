using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class Duravel : Produto
    {

        public int Garantia { get; set; }
        public string Material { get; set; }
        public bool Manutencao { get; set; }

        public Duravel(int codigo, string descricao, string fabricante, int garantia, string material, bool manutencao) : base(codigo, descricao, fabricante)
        {
            this.Garantia = garantia;
            this.Material = material;
            this.Manutencao = manutencao;
        }
        public override void ExibirDetalhes()
        {
            Console.WriteLine($"Produto Durável - Código: {Codigo}, Descrição: {Descricao}, Fabricante: {Fabricante}, Garantia: {Garantia} Meses, Material: {Material}, Manutenção: {(Manutencao ? "Sim" : "Não")}");
        }
    }
}
