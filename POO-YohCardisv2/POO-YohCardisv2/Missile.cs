using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///Eleve : Yohan Cardis
///École: ETML
///Date: 29/10/2023

namespace POO_YohCardisv2
{
    public class Missile
    {
        public int PosX { get; private set; } // Position X du missile
        public int PosY { get; private set; } // Position Y du missile

        // Méthode pour initialiser la position du missile
        public void Initialize(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        // Méthode pour déplacer le missile vers le haut
        public void Move()
        {
            PosY--;
        }

        // Méthode pour dessiner le missile à sa position actuelle
        public void Draw()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.Write('|'); // Dessiner le missile sous forme de '|'
        }

        // Méthode pour vérifier s'il y a une collision entre le missile et un ennemi
        public bool CollidesWith(Enemy enemy)
        {
            return PosX == enemy.PosX && PosY == enemy.PosY; // Vérifier si les positions correspondent
        }
    }
}
