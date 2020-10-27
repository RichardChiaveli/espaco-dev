using System;

namespace Aula1.Entities
{
    /// <summary>
    /// Entidade de Pessoa
    /// </summary>
    public class Pessoa
    {
        /// <summary>
        /// Identificador da Pessoa
        /// </summary>
        public Guid IdPessoa { get; set; }

        /// <summary>
        /// Nome da Pessoa
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Data de Nascimento
        /// </summary>
        public DateTime Nascimento { get; set; }

        /// <summary>
        /// CPF ou CNPJ Pessoa Jurídica ou Física
        /// </summary>
        public decimal CpfCnpj { get; set; }
    }
}
