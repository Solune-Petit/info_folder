using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using ZstdSharp.Unsafe;
using Mysqlx.Connection;
using System.Windows;

namespace BiblioVersion1.classes
{
    internal class Bdd
    {
        public string ConnectionBdd()
        {
            string connexionString = "";


            try
            {
                connexionString = "server=10.10.51.98;database=biblio;port=3306;UserId=solune;password=root";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            return connexionString;
        }

        public void TrouverAbo(string mail, string nom, string mdp, out bool aboTrouve, out DataSet abo)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionBdd());
            string query = $"SELECT * FROM abonne WHERE email = {mail} AND nom = {nom} AND mdp = {mdp}";
            aboTrouve = true;
            abo = null;

            try
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(abo, "abo");
                conn.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

            if (abo.Tables[0].Rows[0]["id"] is null)
            {
                aboTrouve = false;
            }
        }

        public bool AjouterAbo(string nom, string prenom, string mail, string login, string mdp)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionBdd());
            string query = $"INSERT INTO abonnes (nom, prenom, email, login, motDePasse) VALUES (@nom, @prenom, @mail, @login, @mdp)";


            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@mdp", mdp);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public bool ChercherAbonne(string nom, string prenom, string email, string login, string mdp, out int id)
        {
            bool ok = false;
            MySqlConnection maConnection = new MySqlConnection(ConnectionBdd());
            string query = "";
            id = 1;
            try
            {
                maConnection.Open();

                query = "INSERT INTO abonnes (nom, prenom, email, login, motDePasse) values (@nom, @prenom, @email, @login, @motDePasse);";

                MySqlCommand insertCommand = new MySqlCommand(query, maConnection);

                insertCommand.Parameters.AddWithValue("@nom", nom);
                insertCommand.Parameters.AddWithValue("@prenom", prenom);
                insertCommand.Parameters.AddWithValue("@email", email);
                insertCommand.Parameters.AddWithValue("@login", login);
                insertCommand.Parameters.AddWithValue("@motDePasse", mdp);

                // Ajout des données à la source de données
                if (insertCommand.ExecuteNonQuery() > 0)
                {
                    ok = true;
                    id = (int)insertCommand.LastInsertedId;
                }
                maConnection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

            return ok;
        }

        public bool AjouterLivre(string titre, string nomAuteur, string prenomAuteur, DateOnly datePublication, out DataSet livre)
        {
            livre = new DataSet();
            MySqlConnection conn = new MySqlConnection(ConnectionBdd());
            string query = $"INSERT INTO livres (titre, nom, prenom, annee_parution) VALUES (@titre, @nom, @prenom, @annee_parution)";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@titre", titre);
                cmd.Parameters.AddWithValue("@nom", nomAuteur);
                cmd.Parameters.AddWithValue("@prenom", prenomAuteur);
                cmd.Parameters.AddWithValue("@annee_parution", int.Parse(datePublication.Year.ToString()));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

            query = $"SELECT * FROM livres WHERE titre = {titre} AND nom = {nomAuteur} AND prenom = {prenomAuteur} AND annee_parution = {datePublication}";
            try
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(livre, "livre");
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public bool RecupAbonnes(out DataSet abo)
        {
            abo = new DataSet();

            MySqlConnection conn = new MySqlConnection(ConnectionBdd());
            string query = $"SELECT * FROM abonnes";
            try
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(abo, "abo");
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public bool RecupLivres(out DataSet livres)
        {
            livres = new DataSet();
            using var conn = new MySqlConnection(ConnectionBdd());
            string query = "SELECT * FROM livres";
            try
            {
                conn.Open();
                using var da = new MySqlDataAdapter(query, conn);
                da.Fill(livres, "livres");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public bool RecupEmprunts(out DataSet emprunts)
        {
            emprunts = new DataSet();
            MySqlConnection conn = new MySqlConnection(ConnectionBdd());
            string query = "SELECT * FROM emprunts";
            try
            {
                conn.Open();
                using var da = new MySqlDataAdapter(query, conn);
                da.Fill(emprunts, "emprunts");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public bool DegradeLivre(string titre)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionBdd());
            string query = $"UPDATE livres SET etat = etat - 1 WHERE titre = @titre";
            try
            {
                conn.Open();
                using var da = new MySqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@titre", titre);
                da.SelectCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public bool SupprimerLivresAbimes()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionBdd());
            string query = $"DELETE FROM livres WHERE etat <= 0";
            try
            {
                conn.Open();
                using var da = new MySqlDataAdapter(query, conn);
                da.SelectCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public bool EmprunterLivre(Livre livre, int idAbonne, Bibliotheque biblio)
        {
            bool ok = false;
            foreach (var emprunt in biblio.Emprunts)
            {
                if (emprunt.LivreEmprunte.Id == livre.Id)
                {
                    return true;
                }
            }

            if (!ok)
            {
                MySqlConnection conn = new MySqlConnection(ConnectionBdd());
                string query = $"INSERT INTO emprunts (idLivre, idabonne, dateEmprunt) VALUES (@idLivre, @idAbonne, @dateEmprunt)";
                try
                {
                    conn.Open();
                    using var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idLivre", livre.Id);
                    cmd.Parameters.AddWithValue("@idAbonne", idAbonne);
                    cmd.Parameters.AddWithValue("@dateEmprunt", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }
            }
            else
            {
                return false;
            }
        }

        public bool RetoursLivre(int emprunt, DateTime dateRetour)
        {
            bool ok = false;
            MySqlConnection conn = new MySqlConnection(ConnectionBdd());
            string query = $"UPDATE emprunts SET dateRetour = @dateRetour WHERE idEmprunt = @idEmprunt";
            try
            {
                conn.Open();
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dateRetour", dateRetour);
                cmd.Parameters.AddWithValue("@idEmprunt", emprunt);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}