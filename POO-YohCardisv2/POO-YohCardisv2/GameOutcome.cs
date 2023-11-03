using System;
using System.Collections.Generic;
///Eleve : Yohan Cardis
///École: ETML
///Date: 03.11/2023

namespace POO_YohCardisv2
{
    public class GameOutcome
    {
        public bool IsGameOver { get; private set; }  // Indique si le jeu est terminé
        public bool IsPlayerWinner { get; private set; } // Indique si le joueur a gagné

        // Méthode pour vérifier le résultat de la partie
        public void CheckOutcome(Ship playerShip, List<Enemy> enemies)
        {
            if (playerShip.Lives <= 0)
            {
                IsGameOver = true; // La partie est terminée car le joueur a perdu toutes ses vies
                IsPlayerWinner = false;
            }
            else if (enemies.Count == 0)
            {
                IsGameOver = true; // La partie est terminée car tous les ennemis ont été vaincus
                IsPlayerWinner = true;
            }
            else
            {
                IsGameOver = false; // La partie continue car ni le joueur ni les ennemis n'ont gagné
                IsPlayerWinner = false;
            }
        }

        // Méthode pour obtenir un message de résultat
        public string GetOutcomeMessage()
        {
            if (IsGameOver)
            {
                if (IsPlayerWinner) // Le joueur a gagné
                {
                    Console.Clear();
                    Console.SetCursorPosition(15, 10);
                    return "Félicitations, vous avez gagné !"; 
                }
                else // Le joueur a perdu
                {
                    Console.Clear();
                    Console.SetCursorPosition(15, 10);
                    return "Dommage, vous avez perdu."; 
                }
            }
            else
            {
                return string.Empty; // La partie n'est pas encore terminée, renvoie une chaîne vide
            }
        }

        // Méthode pour réinitialiser le jeu
        public void ReInitializeGame(Ship playerShip, List<Enemy> enemies)
        {
            IsGameOver = false; // Réinitialisation de l'état de la partie
            IsPlayerWinner = false;
            playerShip.Lives = 3; // Réinitialisation des vies du joueur
        }
    }
}
