using System;

namespace Entities
{
    public class Maquina
    {
        private readonly Internet _internet;

        public Maquina(Internet internet)
        {
            _internet = internet;
        }

        public void InicializarConexao()
        {
            Console.WriteLine(
                $@"
                Conexao com a Internet realizado com sucesso !
                Velocidade: {_internet.VelocidadeMb}Mb
                IP Público: {_internet.ObterDadosIp.Publico}
                IP Privado: {_internet.ObterDadosIp.Privado}
            ");
        }
    }
}
