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
            MySqlDataReader reader;
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

        public bool CreerAbo(string nom, string prenom, string mail, string pseudo, string mdp)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionBdd());
            string query = $"INSERT INTO abonne (nom, prenom, email, pseudo, mdp) VALUES ({nom}, {prenom}, {mail}, {pseudo}, {mdp})";


            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
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
    }
}
