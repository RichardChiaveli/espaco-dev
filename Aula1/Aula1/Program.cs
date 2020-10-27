using Aula1.Entities;
using Aula1.Repository;
using System;
using System.Collections.Generic;

namespace Aula1
{
    /// <summary>
    /// Classe Inicial
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Construtor
        /// </summary>
        protected Program() { }

        /// <summary>
        /// Método de Execução
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var repo = new PessoaRepository();
            var pessoas = new[]
            {
                new Pessoa
                {
                    IdPessoa = Guid.NewGuid(),
                    Nome = "Richard Chiaveli",
                    CpfCnpj = 12345678910,
                    Nascimento = new DateTime(1995, 10, 29)
                },
                new Pessoa
                {
                    IdPessoa = Guid.NewGuid(),
                    Nome = "Espaço Dev",
                    CpfCnpj = 98765432100,
                    Nascimento = new DateTime(2020, 10, 21)
                }
            };

            // Salvar Unitário
            repo.Salvar(new Pessoa
            {
                IdPessoa = new Guid("a3261181-efa4-4450-8edf-e6264e50748e"),
                Nome = "Tereza Jaqueline Silva",
                CpfCnpj = 18510900884,
                Nascimento = new DateTime(1996, 10, 26)
            });

            // Salvar em Lote
            repo.Salvar(pessoas);

            Console.WriteLine(">> Buscar pelo Identificador");
            var pesquisa = repo.BuscarPorId(new Guid("a3261181-efa4-4450-8edf-e6264e50748e"));
            ImprimirPessoa(pesquisa);

            Console.WriteLine(">> Buscar por Identificadores");
            pesquisa = repo.BuscarPorId(new List<Guid>
            {
                new Guid("a5290826-8975-4bc2-852a-787840b0dc2e"),
                new Guid("a3261181-efa4-4450-8edf-e6264e50748e")
            }.ToArray());
            ImprimirPessoa(pesquisa);

            Console.WriteLine(">> Buscar Todos");
            pesquisa = repo.Buscar();
            ImprimirPessoa(pesquisa);

            Console.WriteLine(">> Buscar por Nome");
            pesquisa = repo.Buscar("Tereza");
            ImprimirPessoa(pesquisa);

            Console.WriteLine(">> Buscar por CPF/CNPJ");
            pesquisa = repo.Buscar(cpfCnpj: 97721330831);
            ImprimirPessoa(pesquisa);

            Console.ReadKey();
        }

        public static void ImprimirPessoa(IList<Pessoa> pessoas)
        {
            foreach (var pessoa in pessoas)
            {
                Console.WriteLine($"{pessoa.CpfCnpj} - {pessoa.Nome}");
            }

            Console.WriteLine("");
        }
    }
}
