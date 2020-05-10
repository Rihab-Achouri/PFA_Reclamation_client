﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using BEL;

namespace DAL
{
    public class ReclamationDAO
    {

        public static bool Insert_reclamation_client(string sujet, string departement, int id_client, int ref_prod, DateTime date_ouverture)
        {
            string req = String.Format("select max (Num) from Reclamation");
            OleDbDataReader rd = utils.lire(req);
            int N = rd.GetInt32(0);
            utils.Disconnect();

            int num = N + 1;
            string requete = String.Format("insert into Reclamation (Num, Sujet, Departement, Id_client, Ref_prod, Decision, Date_ouverture, Etat_reclamation)" +
                " values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", num, sujet, departement, id_client, ref_prod, "Non traitée", date_ouverture, "Réclamation en attente");
            return utils.miseajour(requete);
        }

        public static bool Update_reclamation_client(int num, string sujet, string departement, int ref_prod, DateTime date_ouverture)
        {
            string requete = String.Format("update Reclamation set Sujet='{0}', Departemnt='{1}', Date_ouverture='{2}', Ref_prod = '{3}' " +
                " where Num={4};", sujet, departement, date_ouverture, ref_prod, num);
            return utils.miseajour(requete);
        }

        public static bool Update_reclamation_decision(int num, string decision, string etat, DateTime date_cloture)
        {
            string requete = String.Format("update Reclamation set Decision='{0}', Etat_reclamation='{1}', Date_cloture='{2}'," +
                " where Num={3};", decision, etat, date_cloture, num);
            return utils.miseajour(requete);
        }

        public static bool Delete_reclamation(int num)
        {
            string requete = String.Format("Delete from Reclamation where Num={0};", num);
            return utils.miseajour(requete);
        }

        public static bool Delete_reclamation_annulée()
        {
            string requete = String.Format("Delete from Reclamation where Etat_reclamation = 'Annulée';");
            return utils.miseajour(requete);
        }

        public static Reclamation Get_reclamation_num(int num)
        {
            string requete = String.Format("select * from Reclamation where Num={0};", num);
            OleDbDataReader rd = utils.lire(requete);
            Reclamation c = new Reclamation();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    c.Num = rd.GetInt32(0);
                    c.Sujet = rd.GetString(1);
                    c.Departement = rd.GetString(2);
                    c.Id_client = rd.GetInt32(3);
                    c.Ref_prod = rd.GetInt32(4);
                    c.Decision = rd.GetString(5);
                    c.Date_ouverture = rd.GetDateTime(6);
                    c.Date_ouverture = rd.GetDateTime(7);
                    c.Etat_reclamation = rd.GetString(8);
                }

            }
            utils.Disconnect();
            return c;
        }

        public static List<Reclamation> Get_reclamation()
        {
            string requete = String.Format("select * from Reclamation;");
            OleDbDataReader rd = utils.lire(requete);
            List<Reclamation> L = new List<Reclamation>();
            Reclamation c;
            while (rd.Read())
            {
                c = new Reclamation
                {
                    Num = rd.GetInt32(0),
                    Sujet = rd.GetString(1),
                    Departement = rd.GetString(2),
                    Id_client = rd.GetInt32(3),
                    Ref_prod = rd.GetInt32(4),
                    Decision = rd.GetString(5),
                    Date_ouverture = rd.GetDateTime(6),
                    Date_cloture = rd.GetDateTime(7),
                    Etat_reclamation = rd.GetString(8),
                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;
        }

        public static List<Reclamation> Get_reclamation_non_traitée()
        {
            string requete = String.Format("select * from Reclamation  where Decision=='Non traitée';");
            OleDbDataReader rd = utils.lire(requete);
            List<Reclamation> L = new List<Reclamation>();
            Reclamation c;
            while (rd.Read())
            {
                c = new Reclamation
                {
                    Num = rd.GetInt32(0),
                    Sujet = rd.GetString(1),
                    Departement = rd.GetString(2),
                    Id_client = rd.GetInt32(3),
                    Ref_prod = rd.GetInt32(4),
                    Decision = rd.GetString(5),
                    Date_ouverture = rd.GetDateTime(6),
                    Date_cloture = rd.GetDateTime(7),
                    Etat_reclamation = rd.GetString(8),
                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;

        }
        public static List<Reclamation> Get_reclamation_id_client(int id_client)
        {
            string requete = String.Format("select * from Reclamation where Id_client={0};", id_client);
            OleDbDataReader rd = utils.lire(requete);
            List<Reclamation> L = new List<Reclamation>();
            Reclamation c;
            while (rd.Read())
            {
                c = new Reclamation
                {
                    Num = rd.GetInt32(0),
                    Sujet = rd.GetString(1),
                    Departement = rd.GetString(2),
                    Id_client = rd.GetInt32(3),
                    Ref_prod = rd.GetInt32(4),
                    Decision = rd.GetString(5),
                    Date_ouverture = rd.GetDateTime(6),
                    Date_cloture = rd.GetDateTime(7),
                    Etat_reclamation = rd.GetString(8),
                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;
        }
        public static List<Reclamation> Get_reclamation_annulée()
        {
            string requete = String.Format("select * from Reclamation  where Etat_reclamation ='Annulée';");
            OleDbDataReader rd = utils.lire(requete);
            List<Reclamation> L = new List<Reclamation>();
            Reclamation c;
            while (rd.Read())
            {
                c = new Reclamation
                {
                    Num = rd.GetInt32(0),
                    Sujet = rd.GetString(1),
                    Departement = rd.GetString(2),
                    Id_client = rd.GetInt32(3),
                    Ref_prod = rd.GetInt32(4),
                    Decision = rd.GetString(5),
                    Date_ouverture = rd.GetDateTime(6),
                    Date_cloture = rd.GetDateTime(7),
                    Etat_reclamation = rd.GetString(8),
                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;
        }

        public static bool Insert_decision(string decision, int num, DateTime date_cloture, string etat)
        {
            string requete = String.Format("update Reclamation Decision='{0}', Date_cloture='{1}', " +
               "Etat_reclamation='{2}' where Num={3};", decision, date_cloture, etat, num);
            return utils.miseajour(requete);
        }

        public static List<Client2> Get_reclamation_groupby_client()
        {
            string requete = String.Format("select count(Num), Id_client from Reclamation group by Id_client order by count(Num);");
            OleDbDataReader rd = utils.lire(requete);
            List<Client2> L = new List<Client2>();
            Client2 c;
            while (rd.Read())
            {
                c = new Client2
                {
                    Num2 = rd.GetInt32(0),
                    Reclamation2 = rd.GetString(1),
                   
                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;
        }
    }
}
