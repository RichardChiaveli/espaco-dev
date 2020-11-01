using System;

namespace Entities
{
    public class Administrador
    {
        internal void InstalarDesistalar(string software, bool instalar = true)
        {
            Console.WriteLine($"Software {software} {(instalar ? $"instalado" : "desinstalado")} com sucesso!");
        }

        internal void Formatar()
        {
            Console.WriteLine("Formatação inicializada....");
            Console.WriteLine("Formatação finalizada....");
        }
    }
}
