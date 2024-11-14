using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAKE_ENTERPRISE_LTDA
{
    public class EntradaDados
    {
        Data data;
        public int LeInteiro(string mensagem) //Entrada de dados com consistência - executa até ser digitado um inteiro. Mensagem de entrada inválida
        {
            string aux;
            int n = 0;
            bool teste = false;
            do
            {
                Console.WriteLine(mensagem);
                aux = Console.ReadLine();
                teste = int.TryParse(aux, out n);
                if (teste == false)
                {
                    Console.WriteLine("Valor inválido! Tente Novamente!");
                }
            } while (teste == false);
            return n;
        }
        public int LeInteiro(string mensagem, int min, int max) // Entrada de dados com consistência - executa até ser digitado um inteiro. Mensagem de entrada inválida
        {
            int n = 0;
            bool teste = false;
            do
            {
                Console.WriteLine(mensagem);
                string aux = Console.ReadLine();
                teste = int.TryParse(aux, out n);

                if (!teste || n < min || n > max)
                {
                    Console.WriteLine("Entrada inválida! Digite novamente!");
                    teste = false; // Reinicia o teste para repetir o loop
                }
            } while (!teste);

            return n;
        }
        public double LeDouble(string mensagem) //Entrada de dados com consistência - executa até ser digitado um inteiro. Mensagem de entrada inválida
        {
            string aux;
            double n = 0.0;
            bool teste = false;
            do
            {
                Console.WriteLine(mensagem);
                aux = Console.ReadLine();
                teste = double.TryParse(aux, out n);
                if (teste == false)
                {
                    Console.WriteLine("Valor inválido! Tente Novamente!");
                }
            } while (teste == false);
            return n;
        }
        public float LeFloat(string mensagem)
        {
            string aux;
            float m = 0.0f;
            bool teste = false;
            do
            {
                Console.WriteLine(mensagem);
                aux = Console.ReadLine();
                teste = float.TryParse(aux, out m);
                if (teste == false)
                {
                    Console.WriteLine("Valor inválido, tente novamente!");
                }
            } while (teste == false);
            return m;
        }
        public char LeChar(string mensagem) //Entrada de dados com consistência - executa até ser digitado um inteiro. Mensagem de entrada inválida
        {
            string aux;
            char c = ' ';
            bool teste = false;
            do
            {
                Console.WriteLine(mensagem);
                aux = Console.ReadLine();
                teste = char.TryParse(aux, out c);
                if (teste == false)
                {
                    Console.WriteLine("Caractere inválido! Tente Novamente!");
                }
            } while (teste == false);
            return c;
        }
        public string LeString(string mensagem) //Entrada de dados com consistência - executa até ser digitado um inteiro. Mensagem de entrada inválida
        {
            string aux;
            Console.WriteLine(mensagem);
            aux = Console.ReadLine();
            return aux;
        }

        public string LeString(string mensagem, string referencia1, string referencia2)
        {
            string aux;
            bool teste = false;

            do
            {
                Console.WriteLine(mensagem);
                aux = Console.ReadLine().Trim(); // Remove espaços em branco extras

                if (aux.Equals(referencia1, StringComparison.InvariantCultureIgnoreCase) ||
                    aux.Equals(referencia2, StringComparison.InvariantCultureIgnoreCase))
                {
                    teste = true;
                }
                else
                {
                    Console.WriteLine($"Resposta inválida, digite {referencia1} ou {referencia2}");
                }
            } while (!teste);

            return aux;
        }

        public Data LeData()
        {
            bool valida = false;
            data = new Data();
            do
            {
                var dia = LeInteiro("Digite o dia: ", 1, 31);
                var mes = LeInteiro("Digite o mês", 1, 12);
                var ano = LeInteiro("Digite o ano: ");
                if (data.Valida(dia, mes, ano))
                {
                    data = new Data(dia, mes, ano);
                    valida = true;
                }
                else
                {
                    Console.WriteLine("Data inválida!");
                }
            } while (!valida);
            return data;
        }
    }
}

