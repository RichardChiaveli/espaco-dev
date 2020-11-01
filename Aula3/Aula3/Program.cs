using Entities;
using System;

namespace Aula3
{
    public class Program
    {
        protected Program() { }

        public class Usuario : Suporte
        {
            public Usuario() : base("123") { }

            public void ZerarAcesso()
            {
                InstalarDesistalar("ABC", false);
                InstalarDesistalar("DEF", false);
                Formatar();
            }

        }

        static void Main(string[] args)
        {
            var maquina1 = new Maquina(new Internet
            {
                VelocidadeMb = 100
            });
            maquina1.InicializarConexao();

            var maquina2 = new Maquina(new Internet
            {
                VelocidadeMb = 200
            });
            maquina2.InicializarConexao();

            var usuario = new Usuario();
            usuario.ZerarAcesso();

            Console.ReadKey();
        }
    }
}
