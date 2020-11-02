using System;

namespace Aula4
{
    public class Program
    {
        protected Program() { }

        public enum EtapaEscolar
        {
            // 0 - 5 Anos
            Infantil,
            // 6 - 14 Anos
            Fundamental,
            // 15 - 18 Anos
            Medio,
            // > 18 Anos
            Superior
        }

        public class Pessoa
        {
            public string Nome { get; set; }
            public DateTime DataNascimento { get; set; }
            public EtapaEscolar EtapaEscolar { get; set; }

            public void ImprimirDados()
            {
                Console.WriteLine($@"{Nome} - {DataNascimento:dd/MM/yyyy} ({Idade}) - {EtapaEscolar}");
            }

            public int Idade
            {
                get
                {
                    var dataHoje = DateTime.Now;
                    var idade = dataHoje.Year - DataNascimento.Year;

                    if (DataNascimento > dataHoje.AddYears(-idade))
                    {
                        idade--;
                    }

                    return idade;
                }
            }
        }

        public static void Main(string[] args)
        {
            var p1 = new Pessoa
            {
                Nome = "Richard Cleyton Chiaveli",
                DataNascimento = new DateTime(1995, 11, 2)
            };

            var maiorIdade = p1.Idade >= 18;
            Console.WriteLine($"{p1.Nome} é {(maiorIdade ? "maior" : "menor")} de idade");
            
            p1.EtapaEscolar = p1.Idade switch
            {
                { } n when (n <= 5) => EtapaEscolar.Infantil,
                { } n when (n >= 6 && n <= 14) => EtapaEscolar.Fundamental,
                { } n when (n >= 15 && n <= 18) => EtapaEscolar.Medio,
                _ => EtapaEscolar.Superior
            };

            p1.ImprimirDados();
            Console.ReadKey();
        }
    }
}
