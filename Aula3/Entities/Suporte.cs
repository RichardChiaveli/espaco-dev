using System;

namespace Entities
{
    public class Suporte
    {
        private readonly string _senha;

        public Suporte(string senha)
        {
            _senha = senha;
        }

        protected void InstalarDesistalar(string software, bool instalar = true)
        {
            Console.WriteLine($"Software {software} {(instalar ? $"instalado" : "desinstalado")} com sucesso!");
        }

        protected void Formatar()
        {
            if (ValidarSenhaAdm(_senha))
            {
                new Administrador().Formatar();
            }
            else
            {
                Console.WriteLine("Usuário sem permissão!");
            }
        }

        private static bool ValidarSenhaAdm(string senha) => !string.IsNullOrWhiteSpace(senha) && senha == "123";
    }
}
