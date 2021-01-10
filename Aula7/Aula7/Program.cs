using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Aula7
{
    public class Program
    {
        protected Program() { }

        public static void Main()
        {
            // PARTE 1
            var numeros = Enumerable.Range(0, 10).ToArray();

            var minimo = numeros.Min();
            var maximo = numeros.Max();

            var numeroSorteado = new Random().Next(minimo, maximo);

            const string mensagem = @"Você escolheu o número {0} de {1}-{2} e o número sorteado foi {3}, {4}!";

            Console.Write($"Digite um número de {minimo}-{maximo}:");
            var numeroEscolhido = Console.ReadLine();

            var acertou = Convert.ToInt32(numeroEscolhido) == numeroSorteado;
            var msgParametrizada = string.Format(mensagem, numeroEscolhido, minimo, maximo, numeroSorteado,
                acertou ? "Parabéns" : "Tente novamente");

            Console.WriteLine(msgParametrizada);

            // PARTE 2

            Console.Write("Digite o código de barras:");
            var codigoBarras = Console.ReadLine();

            var gtin8 = codigoBarras?.PadLeft(8, '0');
            Console.WriteLine($"Código barras no formato do GTIN8: {gtin8}");

            // PARTE 3
            Console.Write("Digite o seu e-mail:");
            var email = Console.ReadLine();

            var emailValido = ValidarEmail(email);
            Console.WriteLine($"O email {email} digitado é {(emailValido ? "válido" : "inválido")}!");

            if (emailValido)
            {
                Console.WriteLine($"Usuário apartir do e-mail: {GerarUsuario(email)}");
                Console.WriteLine($"E-mail ofuscado: {RetornarEmailOfuscado(email)}");
            }

            // PARTE 4

            Console.WriteLine($"Data e Hora Atual: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");

            var valor = 1.258m;
            Console.WriteLine($"Valor em Reais (R$): {valor:C2}");

            valor = FormatarDecimal("100,50");
            Console.WriteLine($"Valor em Reais (R$): {valor:C2}");

            valor = FormatarDecimal("1.200,55");
            Console.WriteLine($"Valor em Reais (R$): {valor:C2}");

            valor = FormatarDecimal("1200,55");
            Console.WriteLine($"Valor em Reais (R$): {valor:C2}");

            valor = FormatarDecimal("1.200.550,55");
            Console.WriteLine($"Valor em Reais (R$): {valor:C2}");

            // PARTE 5

            var linha = EscreverLinhaArquivo(
                "Espaço Dev", "Operações com String", "Dotnet Core", "Richard Cleyton Chiaveli");

            Console.WriteLine(linha);

            ProcessarImportacao();

            Console.ReadKey();
        }

        public static void ProcessarImportacao()
        {
            var caminho = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, @"importacao.txt");
            var conteudoArquivo = File.ReadAllText(caminho) ?? string.Empty;
            const char separador = '|';

            Regex.Split(conteudoArquivo, Environment.NewLine).ToList().ForEach(linha =>
            {
                var colunas = linha.Split(separador);

                Console.WriteLine($@"
                    Usuário: {colunas[0]}
                    Empresa: {colunas[1]}
                    Conteúdo: {colunas[2]}
                ");
            });
        }

        public static string EscreverLinhaArquivo(params string[] valores)
        {
            const char separador = '|';
            return string.Join(separador, valores);
        }

        public static bool ValidarEmail(string email, string dominio = null)
        {
            var validacaoEmail =
                (email.Contains("@gmail") || email.Contains("@outlook") || !string.IsNullOrWhiteSpace(dominio) && email.Contains($"@{dominio}")) &&
                (email.EndsWith(".com") || email.EndsWith(".com.br"));

            return validacaoEmail;
        }

        public static string GerarUsuario(string email)
        {
            var posicao = email?.IndexOf("@") ?? 0;
            return email?.Substring(0, posicao);
        }

        public static string RetornarEmailOfuscado(string email)
        {
            var separacaoEmail = email.Split('@');
            var primeiraParte = separacaoEmail.FirstOrDefault() ?? string.Empty;

            var primeiraParteOfuscada = primeiraParte.Length > 3
                ? $"{primeiraParte.Substring(0, 3)}{new string('*', primeiraParte.Length - 3)}"
                : primeiraParte;
            
            return $"{primeiraParteOfuscada}@{separacaoEmail.LastOrDefault()}";
        }

        public static decimal FormatarDecimal(string dinheiro)
        {
            var valor = dinheiro;
            
            if (dinheiro.Contains(".") && dinheiro.Contains(","))
                valor = valor.Replace(".", string.Empty);
            else if (dinheiro.Contains("."))
                valor = valor.Replace(".", ",");

            return Math.Round(Convert.ToDecimal(valor), 2);
        }
    }
}
