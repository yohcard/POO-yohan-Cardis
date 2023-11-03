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
    public class Ship
    {
        // Propriétés de la classe Ship
        public int PosX { get; private set; } // Position X du vaisseau
        public int PosY { get; private set; } // Position Y du vaisseau
        public int Lives { get; set; }       // Nombre de vies du vaisseau

        // Constructeur par défaut de la classe Ship
        public Ship()
        {
            // Initialisation des propriétés lors de la création d'une instance
            PosX = 0;
            PosY = 0;
            Lives = 3;
        }

        // Méthode pour initialiser la position du vaisseau
        public void Initialize(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        // Méthode pour déplacer le vaisseau en fonction de la touche appuyée
        public void Move(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (PosX > 0)
                        PosX--; // Déplacer le vaisseau vers la gauche s'il n'est pas déjà à la limite
                    break;
                case ConsoleKey.RightArrow:
                    if (PosX < Console.WindowWidth - 1)
                        PosX++; // Déplacer le vaisseau vers la droite s'il n'est pas déjà à la limite
                    break;
            }
        }

        // Méthode pour dessiner le vaisseau à sa position actuelle
        public void Draw()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('*'); // Dessiner le vaisseau sous forme d'un astérisque vert
            Console.ResetColor();
        }

        // Méthode pour vérifier s'il y a une collision entre le vaisseau et un ennemi
        public bool CollidesWith(Enemy enemy)
        {
            return PosX == enemy.PosX && PosY == enemy.PosY; // Vérifier si les positions correspondent
        }
    }
}
