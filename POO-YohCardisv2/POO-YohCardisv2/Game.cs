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
    public class Game
    {
        private bool ok; // Variable pour gérer l'interaction avec le joueur
        public string nomJoueur; // Nom du joueur
        private Ship playerShip; // Vaisseau du joueur
        private List<Enemy> enemies; // Liste des ennemis
        private List<Missile> missiles; // Liste des missiles
        public int score; // Score du joueur
        private bool gameOver; // Indique si le jeu est terminé
        static Random random = new Random(); // Générateur de nombres aléatoires
        private GameOutcome gameOutcome; // Gestion des résultats du jeu

        // Constructeur de la classe Game
        public Game()
        {
            nomJoueur = "";
            playerShip = new Ship();
            enemies = new List<Enemy>();
            missiles = new List<Missile>();
            score = 0;
            gameOver = false;
            gameOutcome = new GameOutcome();
           
        }

        // Méthode pour démarrer le jeu
        public void StartGame()
        {
            var basededonne = new BaseDeDonne();
            var gameoutcome = new GameOutcome();
            int y = 14;
            int x = 15;
            nomJoueur = ProfilJoueur(ok); // Initialisation du nom du joueur
            Console.Clear();
            InitializeGame();

            while (!gameOver)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    playerShip.Move(key);

                    if (key == ConsoleKey.Spacebar)
                    {
                        Shoot(); // Le joueur tire un missile
                    }
                }

                UpdateGame();
                StyleDuJeu(); // Rafraîchit l'affichage
                Thread.Sleep(125);

                gameOutcome.CheckOutcome(playerShip, enemies);
                if (gameOutcome.IsGameOver)
                {
                    // Affiche un message de fin de partie
                    Console.WriteLine(gameOutcome.GetOutcomeMessage());
                    basededonne.EnregistrerScoreDePartie(nomJoueur, score);
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine($"Ton score: {score}");
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine($"Vie restante: {playerShip.Lives}");
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine("Appuyer R pour recommencer ou Q pour quitter.");
                    // Gère les options de recommencement ou de quitter ici
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.R)
                    {
                        gameoutcome.ReInitializeGame(playerShip, enemies);
                        StartGame(); // Recommence le jeu
                    }
                    else if (key == ConsoleKey.Q)
                    {
                        gameoutcome.ReInitializeGame(playerShip, enemies);
                        break; // Quitte le jeu
                    }
                }
            }
        }

        // Méthode pour initialiser le jeu
        private void InitializeGame()
        {
            playerShip.Initialize(Console.WindowWidth / 2, 20); // Initialise la position du vaisseau du joueur
            enemies.Clear();
            missiles.Clear();
            score = 0;
            gameOver = false;

            for (int i = 0; i < 0; i++) // 10 enemis ajouté à la list
            {
                Enemy enemy = new Enemy();
                enemy.Initialize(random.Next(Console.WindowWidth), random.Next(5, 10));
                enemies.Add(enemy);
            }
        }

        // Méthode pour mettre à jour l'état du jeu
        private void UpdateGame()
        {
            if (!gameOver)
            {
                MoveEnemies(); // Déplace les ennemis
                MoveMissiles(); // Déplace les missiles
                DetectCollisions(); // Détecte les collisions
                CheckGameOver(); // Vérifie si la partie est terminée
            }
        }

        // Méthode pour rafraîchir l'affichage du jeu
        private void StyleDuJeu()
        {
            Console.Clear();

            playerShip.Draw(); // Dessine le vaisseau du joueur
            foreach (var enemy in enemies)
            {
                enemy.Draw(); // Dessine les ennemis
            }

            foreach (var missile in missiles)
            {
                missile.Draw(); // Dessine les missiles
            }

            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Score: {score}");
            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"Vies: {playerShip.Lives}");
        }

        // Méthode pour que le joueur tire un missile
        private void Shoot()
        {
            Missile missile = new Missile();
            missile.Initialize(playerShip.PosX, playerShip.PosY - 1);
            missiles.Add(missile);
        }

        // Méthode pour déplacer les ennemis
        private void MoveEnemies()
        {
            foreach (var enemy in enemies)
            {
                enemy.Move(); // Déplace les ennemis vers le bas
            }
        }

        // Méthode pour déplacer les missiles et gérer les missiles sortis de l'écran
        private void MoveMissiles()
        {
            foreach (var missile in missiles)
            {
                missile.Move(); // Déplace les missiles vers le haut
            }

            missiles.RemoveAll(missile => missile.PosY < 0); // Supprime les missiles hors de l'écran
        }

        // Méthode pour détecter les collisions
        private void DetectCollisions()
        {
            for (int i = missiles.Count - 1; i >= 0; i--)
            {
                for (int j = enemies.Count - 1; j >= 0; j--)
                {
                    if (missiles[i].CollidesWith(enemies[j]))
                    {
                        score += 500; // Augmente le score en cas de collision
                        missiles.RemoveAt(i); // Supprime le missile
                        enemies.RemoveAt(j); // Supprime l'ennemi
                        break;
                    }
                }
            }

            foreach (var enemy in enemies)
            {
                if (playerShip.CollidesWith(enemy))
                {
                    playerShip.Lives--; // Réduit les vies du joueur en cas de collision avec un ennemi
                    if (playerShip.Lives <= 0)
                    {
                        gameOver = true; // La partie est terminée si le joueur n'a plus de vies
                    }
                }
            }
        }

        // Méthode pour vérifier si la partie est terminée
        private void CheckGameOver()
        {
            if (enemies.Count == 0)
            {
                gameOver = true; // La partie est terminée si tous les ennemis ont été vaincus
            }
        }

        // Méthode pour gérer la création du profil du joueur
        private string ProfilJoueur(bool ok)
        {
            Console.Clear();
            Console.SetCursorPosition(17, 10);
            Console.Write("Nom du joueur : ");
            nomJoueur = Console.ReadLine();
            Console.WriteLine();

            do
            {
                Console.Clear();
                Console.SetCursorPosition(17, 10);
                Console.WriteLine("Espace pour commencer");
                ok = Console.ReadKey().Key != ConsoleKey.Spacebar;
            } while (ok);

            return nomJoueur;
        }
    }
}
