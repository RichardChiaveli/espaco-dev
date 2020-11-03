using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Aula5
{
    public class Program
    {
        protected Program() { }

        static void Main(string[] args)
        {
            var palavras = new List<string>
            {
                "casarão", "vó", "mãe", "vô", "está",
                "já", "olá", "até", "é", "és", "olé",
                "pontapé", "dominó", "paletó", "não",
                "flexão", "detê-lo", "fazê-la", "vê-la",
                "compô", "repô-la", "pô-la"
            };

            palavras.Select(RemoverAcentos).ToList().ForEach(Imprimir);

            var numero = 2020;
            Imprimir($"O número {numero} {(VerificaNumeroPar(numero) ? "par" : "impar")}");

            numero = 7741;
            Imprimir($"O número {numero} {(VerificaNumeroPar(numero) ? "par" : "ímpar")}");

            Console.ReadKey();
        }

        public static string RemoverAcentos(string palavra)
        {
            var sbReturn = new StringBuilder();
            var arrayText = palavra.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (var letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        public static bool VerificaNumeroPar(int numero) => numero % 2 == 0;

        public static void Imprimir(string texto) => Console.WriteLine(texto);
    }
}
