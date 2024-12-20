﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class ItemVenda
    {
        public Produto Item { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }

        public ItemVenda(Produto item, int quantidade, double valor)
        {
            this.Item = item;
            this.Quantidade = quantidade;
            this.Valor = valor;
        }

        public override string ToString() 
        {
            return $"Produto: {Item.Descricao} / Quantidade: {Quantidade} / Preço unitário: R$ {Valor/Quantidade:F2} / Valor total do produto: R$ {Valor:F2}";
        }
    }
}
