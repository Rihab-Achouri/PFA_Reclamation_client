﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BEL;
using System.Data.OleDb;

namespace ApplicationWinforms
{
    public partial class Reclamation_client : Form
    {
        public Reclamation_client()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string requete = String.Format("update Reclamation set Etat_reclamation='{0}'" +
                " where Num={1};", "Réclamation annulée", int.Parse(textBox2.Text));
            utils.miseajour(requete);
            MessageBox.Show("la modification a été effectuée avec succès");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               

                ReclamationDAO.Insert_reclamation_client(richTextBox1.Text, comboBox2.Text, int.Parse(textBox1.Text), int.Parse(comboBox1.Text), DateTime.Parse(dateTimePicker1.Text));
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
                try
                {
                    Reclamation p = ReclamationDAO.Get_reclamation_num(int.Parse(textBox4.Text));
                    textBox4.Text = p.Num.ToString();
                    richTextBox1.Text = p.Sujet;
                    comboBox1.Text = p.Ref_prod.ToString();
                    comboBox2.Text = p.Departement;
                    dateTimePicker1.Text = p.Date_ouverture.ToString();
                    List<Reclamation> L = new List<Reclamation>();
                    L.Add(p);
                    dataGridView1.DataSource = L;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            else if (textBox1.Text != "")
                try
                {
                    List<Reclamation> Listreclamation = ReclamationDAO.Get_reclamation_id_client(int.Parse(textBox1.Text));
                    dataGridView1.DataSource = Listreclamation;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            else MessageBox.Show("Si vous avez oublié le numéro de votre réclamation essayer avec votre identifiant");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ReclamationDAO.Update_reclamation_client(int.Parse(textBox4.Text), richTextBox1.Text, comboBox2.Text, int.Parse(comboBox1.Text), DateTime.Parse(dateTimePicker1.Text));
                MessageBox.Show("UPDATE DONE");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Accueil f1 = new Accueil();
            f1.ShowDialog();
            this.Hide();
        }
    }
}
