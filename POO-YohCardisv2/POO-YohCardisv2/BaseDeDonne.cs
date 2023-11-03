using System;
using System.Collections.Generic;
using System.Linq;
using MySqlConnector;
using System.Threading.Tasks;
///Eleve : Yohan Cardis
///École: ETML
///Date: 03.11/2023

namespace projet_space_invaders_v1._0
{
    internal class BaseDeDonne
    {
        public void showdatabase()
        {
            int x = 40;
            int y = 10;
            int z = 10;
            int w = 20;
            string connectionString = "Server=localhost;Port=6033;Database=db_space_invaders;User=root;Password=root;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            Console.Clear();

            try
            {
                connection.Open();

                // Récupère les cinq meilleurs scores des joueurs depuis la table t_joueur
                string query = "SELECT * FROM t_joueur order by jouNombrePoints desc limit 5;";
                MySqlCommand command = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Affiche les pseudonymes des joueurs
                    while (reader.Read())
                    {
                        Console.SetCursorPosition(15, z);
                        Console.WriteLine(reader["jouPseudo"].ToString());
                        z++;
                    }
                }
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Affiche les scores correspondants
                    while (reader.Read())
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine(reader["jouNombrePoints"].ToString());
                        y++;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erreur de connexion : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            Console.ReadKey(true);
        }

        private List<string> tasks;

        public void Todatabase(List<string> databaseTasks)
        {
            string connectionString = "Server=localhost;Port=6033;Database=db_space_invaders;User=root;Password=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            tasks = new List<string>();

            // Vérifie que les tâches de la base de données ne sont pas nulles.
            if (databaseTasks != null)
            {
                // Parcourt chaque tâche de la base de données et les ajoute à la liste.
                foreach (string task in databaseTasks)
                {
                    tasks.Add(task);
                }
            }
            else
            {
                // Si les tâches de la base de données sont nulles, affiche un message d'erreur.
                Console.WriteLine("Erreur : Les tâches de la base de données sont nulles.");
            }
        }

        public void EnregistrerScore(string nomJoueur, int score)
        {
            string connectionString = "Server=localhost;Port=6033;Database=db_space_invaders;User=root;Password=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // Insérez le nom du joueur et le score dans la table t_joueur
                string insertQuery = "INSERT INTO t_joueur (jouPseudo, jouNombrePoints) VALUES (@nomJoueur, @score)";
                MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@nomJoueur", nomJoueur);
                insertCommand.Parameters.AddWithValue("@score", score);
                insertCommand.ExecuteNonQuery();
                Console.SetCursorPosition(15, 3);
                Console.WriteLine("Score enregistré avec succès !");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erreur de connexion : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void EnregistrerScoreDePartie(string nomJoueur, int score)
        {
            EnregistrerScore(nomJoueur, score);
        }
    }
}
