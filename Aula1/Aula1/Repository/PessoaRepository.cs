using Aula1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula1.Repository
{
    /// <summary>
    /// Repositório da Pessoa
    /// </summary>
    public class PessoaRepository
    {
        /// <summary>
        /// Mock de dados de Pessoas
        /// </summary>
        public List<Pessoa> Pessoas { get; private set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public PessoaRepository()
        {
            Pessoas = new List<Pessoa>
            {
                new Pessoa
                {
                    IdPessoa = new Guid("a5290826-8975-4bc2-852a-787840b0dc2e"),
                    Nome = "Ester Isabel Tânia Ferreira",
                    CpfCnpj = 97721330831,
                    Nascimento = new DateTime(1996, 06, 14)
                }
            };
        }

        /// <summary>
        /// Adiciona uma Pessoa no Banco
        /// </summary>
        /// <param name="pessoa"></param>
        public void Salvar(params Pessoa[] pessoa)
        {
            Pessoas.AddRange(pessoa);
        }

        /// <summary>
        /// Buscar Pessoas pelo Identificador
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<Pessoa> BuscarPorId(params Guid[] ids)
        {
            return Pessoas.Where(i => ids.Contains(i.IdPessoa)).ToList();
        }

        /// <summary>
        /// Busca Pessoas de acordo com os Filtros
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cpfCnpj"></param>
        /// <returns></returns>
        public List<Pessoa> Buscar(string nome = null, decimal? cpfCnpj = null)
        {
            var pesquisa = Pessoas;

            if (!string.IsNullOrWhiteSpace(nome))
            {
                pesquisa = pesquisa.Where(i =>
                    i.Nome.ToLower().Contains(nome.Trim().ToLower())).ToList();
            }

            if (cpfCnpj.HasValue)
            {
                pesquisa = pesquisa.Where(i => i.CpfCnpj == cpfCnpj).ToList();
            }

            return pesquisa;
        }
    }
}
