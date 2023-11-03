using projet_space_invaders_v1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
///Eleve : Yohan Cardis
///École: ETML
///Date: 03.11/2023
namespace POO_YohCardisv2
{
    internal class Program
    {
        // Méthode principale du programme
        static void Main(string[] args)
        {
            var baseDeDonnes = new BaseDeDonne();
            var jeux = new Game();

            // Configuration de la fenêtre de la console
            Console.WindowHeight = 30;
            Console.WindowWidth = 60;
            Console.BufferHeight = 30;
            Console.BufferWidth = 60;
            Console.CursorVisible = false;

            while (true)
            {
                Console.Clear();

                // Affichage du menu principal
                Console.SetCursorPosition(20, 10);
                Console.WriteLine("Space Invaders");
                Console.SetCursorPosition(20, 12);
                Console.WriteLine("1. Commencer");
                Console.SetCursorPosition(20, 13);
                Console.WriteLine("2. Instructions");
                Console.SetCursorPosition(20, 14);
                Console.WriteLine("3. Meilleur score");
                Console.SetCursorPosition(20, 15);
                Console.WriteLine("4. Quitter");

                var choix = Console.ReadKey(true).Key;

                // Gestion du choix de l'utilisateur
                switch (choix)
                {
                    case ConsoleKey.D1:
                        jeux.StartGame();
                        break;
                    case ConsoleKey.D2:
                        ShowInstructions();
                        break;
                    case ConsoleKey.D3:
                        baseDeDonnes.showdatabase();
                        break;
                    case ConsoleKey.D4:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        // Méthode pour afficher les instructions
        private static void ShowInstructions()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 10);
            Console.WriteLine("Instructions:");
            Console.SetCursorPosition(15, 12);
            Console.WriteLine("Utilisez les flèches pour bouger.");
            Console.SetCursorPosition(15, 14);
            Console.WriteLine("Appuyez sur espace pour tirer.");
            Console.SetCursorPosition(15, 16);
            Console.WriteLine("Appuyez sur n'importe quelle touche pour");
            Console.SetCursorPosition(15, 17);
            Console.WriteLine("revenir à l'écran d'accueil.");
            Console.ReadKey(true);
        }
    }
}
