using Aula2.Entities;
using System;

namespace Aula2
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
            var divida = new Divida
            {
                IdDivida = Guid.NewGuid(),
                Valor = 200.50M,
                DataHoraCadastro = DateTime.Now
            };

            decimal valorPagamento = 0;
            ImprimirDadosDivida(0, valorPagamento, divida);

            valorPagamento = 200;
            PagarDivida(valorPagamento, ref divida, out var troco);
            ImprimirDadosDivida(troco, valorPagamento, divida);
            
            valorPagamento = 1;
            PagarDivida(valorPagamento, ref divida, out troco);
            ImprimirDadosDivida(troco, valorPagamento, divida);

            Console.ReadKey();
        }

        /// <summary>
        /// Realiza o Pagamento da Dívida
        /// </summary>
        /// <param name="valorPagamento"></param>
        /// <param name="divida"></param>
        /// <param name="troco"></param>
        public static void PagarDivida(decimal valorPagamento, ref Divida divida, out decimal troco)
        {
            var inicializarDataPagamento = true;
            troco = 0;

            if (valorPagamento <= 0)
            {
                divida.Situacao = SituacaoDivida.EmAberto;
                inicializarDataPagamento = false;
            }
            else if (valorPagamento >= divida.Valor)
            {
                divida.Situacao = SituacaoDivida.Paga;
                troco = valorPagamento - divida.Valor;
                divida.Valor = 0;
            }
            else if (valorPagamento > 0 && valorPagamento < divida.Valor)
            {
                divida.Situacao = SituacaoDivida.PagaParcialmente;
                divida.Valor -= valorPagamento;
            }

            if (inicializarDataPagamento)
                divida.DataPagamento = DateTime.Now;
        }

        /// <summary>
        /// Impressão dos Dados da Dívida
        /// </summary>
        /// <param name="troco"></param>
        /// <param name="valorPago"></param>
        /// <param name="divida"></param>
        public static void ImprimirDadosDivida(in decimal troco, in decimal valorPago, Divida divida)
        {
            Console.WriteLine($@"--> EXTRATO
                (-) VALOR DA DÍVIDA: {divida.Valor:C2}
                (+) VALOR DO PAGAMENTO: {valorPago:C2}
                (=) TROCO: {troco:C2}                
                *** SITUAÇÃO DA DÍVIDA: {divida.Situacao}
                *** DATA HORA CADASTRADO: {divida.DataHoraCadastro:dd/MM/yyyy}
                *** DATA DO PAGAMENTO: {(divida.DataPagamento.HasValue ? $"{divida.DataPagamento:dd/MM/yyyy}" : "-")}
            ");
        }
    }
}
