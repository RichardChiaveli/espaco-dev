using System;

namespace Aula2.Entities
{
    /// <summary>
    /// Enum da Situação da Dívida
    /// </summary>
    public enum SituacaoDivida
    {
        /// <summary>
        /// Em Aberto
        /// </summary>
        EmAberto,

        /// <summary>
        /// Paga parcialmente
        /// </summary>
        PagaParcialmente,

        /// <summary>
        /// Paga
        /// </summary>
        Paga
    }

    /// <summary>
    /// Entidade da Dívida
    /// </summary>
    public class Divida
    {
        /// <summary>
        /// Identificador da Dívida
        /// </summary>
        public Guid IdDivida { get; set; }

        /// <summary>
        /// Valor da Dívida
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Situação da Dívida
        /// </summary>
        public SituacaoDivida Situacao { get; set; }

        /// <summary>
        /// Data e Hora do Cadastro da Dívida
        /// </summary>
        public DateTime DataHoraCadastro { get; set; }

        /// <summary>
        /// Data de Pagamento da Dívida
        /// </summary>
        public DateTime? DataPagamento { get; set; }
    }
}
