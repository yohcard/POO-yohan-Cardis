using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///Eleve : Yohan Cardis
///École: ETML
///Date: 03.11/2023

namespace POO_YohCardisv2
{
    public class Enemy
    {
        public int PosX { get; private set; } // Position en X de l'ennemi
        public int PosY { get; private set; } // Position en Y de l'ennemi
        static Random random = new Random(); // Générateur de nombres aléatoires pour réinitialiser l'emplacement de l'ennemi

        // Méthode pour initialiser la position de l'ennemi 
        public void Initialize(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        // Méthode pour déplacer l'ennemi vers le bas
        public void Move()
        {
            PosY++;
            if (PosY >= Console.WindowHeight)
            {
                // Si l'ennemi atteint le bas de l'écran, réinitialise sa position en X et le replace en haut de l'écran
                PosX = random.Next(Console.WindowWidth);
                PosY = 0;
            }
        }

        // Méthode pour dessiner l'ennemi sur l'écran
        public void Draw()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('V'); // Dessine l'ennemi sous forme de 'V'
            Console.ResetColor();
        }
    }
}
