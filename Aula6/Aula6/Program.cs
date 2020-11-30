using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Aula6
{
    public class Program
    {
        protected Program() { }

        static void Main(string[] args)
        {
            long? cpf = null;

            Console.WriteLine("Deseja informar o CPF na NF ? [S] ou [N]");
            var informarCpf = Console.ReadLine() == "S";

            if (informarCpf)
            {
                Console.WriteLine("Digite o CPF:");
                var digito = Console.ReadLine();

                if (long.TryParse(digito, out var cpfValido))
                {
                    cpf = cpfValido;
                }
            }

            var cpfFormatado = FormatarCpf(cpf?.ToString() ?? "0");
            Imprimir($"CPF informado pelo Cliente: {cpfFormatado}");

            var nomes = new List<string>
            {
                "Adrian Scott Pyke", "Willian Souza Reis", "Alex Pierre D'Lamore",
                "Richard Chiaveli", "Herbert Richers", "Richerland O'Brien Souza",
                "Ryan D'Freire", "Ryland Jhonny", "Remington Souza Cruz", "Raymond D'Castro Lima",
                "Roy Chierro Calatierre", "Adam Luiz Muzzy"
            };

            Imprimir("Digite o nome da Família");
            var nomeFamilia = Console.ReadLine();

            var pesquisa = ListarPorFiltros(nomes,
                i => i.ToLower().EndsWith(nomeFamilia?.ToLower() ?? string.Empty),
                out var tempo);

            Imprimir(pesquisa.Any()
                    ? $"Pessoas encontradas: {string.Join(",", pesquisa)}"
                    : "Nenhuma Pessoa foi encontrada");
            Imprimir($"Tempo Processamento: {tempo?.Elapsed.Milliseconds.ToString() ?? string.Empty}s");
        }

        public static string FormatarCpf(string cpf) =>
            Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");

        public static void Imprimir(List<string> valores) =>
            Console.WriteLine(string.Join(",", valores));

        public static void Imprimir(string texto) =>
            Console.WriteLine(texto);

        public static List<string> ListarPorFiltros(List<string> lista, Func<string, bool> filtro, out Stopwatch tempoPesquisa)
        {
            tempoPesquisa = new Stopwatch();
            tempoPesquisa.Start();

            if (lista == null || !lista.Any() || !lista.Any(filtro ?? (s => true)))
            {
                tempoPesquisa.Stop();
                return new List<string>();
            }

            var pesquisa = lista.Where(filtro ?? (s => true)).ToList();
            tempoPesquisa.Stop();

            return pesquisa;
        }
    }
}
