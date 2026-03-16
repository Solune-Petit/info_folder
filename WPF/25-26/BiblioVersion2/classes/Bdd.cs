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
            MySqlConnection conn = new MySqlConnection(ConnectionBdd());
            string query = $"SELECT id FROM abonnes WHERE nom = @nom AND prenom = @prenom AND email = @email AND login = @login AND motDePasse = @mdp";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@mdp", mdp);
                MySqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
                id = int.Parse(reader["id"].ToString());
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public bool AjouterLivre(string titre, string nomAuteur, string prenomAuteur, DateOnly datePublication)
        {
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
            abo = null;

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
            livres = null;
            MySqlConnection conn = new MySqlConnection(ConnectionBdd());
            string query = $"SELECT * FROM livres";
            try
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                
                
                da.Fill(livres, "livres");
                conn.Close();
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
            emprunts = null;
            MySqlConnection conn = new MySqlConnection(ConnectionBdd());
            string query = $"SELECT * FROM emprunts";
            try
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(emprunts, "emprunts");
                conn.Close();
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
