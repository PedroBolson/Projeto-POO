using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class Data
    {
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public Data(int dia, int mes, int ano)
        {
            var valida = Valida(dia, mes, ano);
            if (valida == false)
            {
                Console.WriteLine("Data inválida!");
            }
            else
            {
                this.Dia = dia;
                this.Mes = mes;
                this.Ano = ano;
            }
        }

        private bool AnoBissexto(int ano)
        {
            return (ano % 4 == 0 && ano % 100 != 0) || (ano % 400 == 0);

        }

        public int DiasTotais(Data data)
        {
            int dias = 0;
            // Adiciona todos os dias do ano até o ano anterior da data
            for (int ano = 1; ano < data.Ano; ano++)
            {
                dias += AnoBissexto(ano) ? 366 : 365;
            }

            int[] diasMes = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (AnoBissexto(data.Ano))
            {
                diasMes[1]++;
            }
            // Adiciona todos os dias até o mes anterior da data
            for (int mes = 1; mes < data.Mes; mes++)
            {
                dias += diasMes[mes - 1];
            }
            // Adiciona os dias do mes em que a data está situada
            dias += data.Dia;
            return dias;
        }

        public bool Valida(int dia, int mes, int ano)
        {
            if (mes < 1 || mes > 12)
            {
                return false;
            }

            if (dia < 1 || dia > 31)
            {
                return false;
            }
            int[] diasMes = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (AnoBissexto(ano) && Mes == 2)
            {
                diasMes[1]++;
            }
            return dia <= diasMes[mes - 1];
        }
        public override string ToString()
        {
            return $"{Dia:D2}/{Mes:D2}/{Ano:D4}";
        }
    }
}
