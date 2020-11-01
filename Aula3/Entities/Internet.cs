using System;
using System.Globalization;

namespace Entities
{
    public class Internet
    {
        public Ip ObterDadosIp { get; }
        public int VelocidadeMb { get; set; }

        public Internet()
        {
            var ip = new Ip { Publico = GerarIpDinamico() };
            ObterDadosIp = ip;
        }

        private static string GerarIpDinamico()
        {
            const double minimo = 111111111111d;

            var meuIp =
                (new Random().Next() + minimo).ToString(CultureInfo.InvariantCulture);

            return $"{meuIp.Substring(0, 3)}.{meuIp.Substring(3, 3)}." +
                   $"{meuIp.Substring(6, 3)}.{meuIp.Substring(9, 3)}";
        }
    }
}
