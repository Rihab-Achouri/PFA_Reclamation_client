﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BEL;
using DAL;
using System.Data.OleDb;

namespace ApplicationWinforms
{
    public partial class Passer_Gérer_commande : Form
    {
        public Passer_Gérer_commande()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Accueil Form = new Accueil();
            Authentification f = new Authentification();
            if (f.comboBox1.Text == "Client")
            {
                Form.button13.Visible = false;
                Form.button17.Visible = false;
                Form.button16.Visible = false;
                Form.button7.Visible = false;
                Form.button10.Visible = false;
                Form.button6.Visible = false;
                Form.button12.Visible = false;
                Form.button1.Visible = false;
                Form.button8.Visible = false;
                Form.button4.Visible = false;
                Form.pictureBox4.Visible = false;
                Form.pictureBox3.Visible = false;
                Form.pictureBox6.Visible = false;
            }
            if (f.comboBox1.Text == "Admin")
            {
                Form.button2.Visible = false;
                Form.button9.Visible = false;
                Form.button14.Visible = false;
                Form.button11.Visible = false;
                Form.button15.Visible = false;
                Form.pictureBox2.Visible = false;
                Form.pictureBox4.Visible = false;
                Form.pictureBox6.Visible = false;
            }
            if (f.comboBox1.Text == "Responsable Qualité")
            {
                Form.button6.Visible = false;
                Form.button1.Visible = false;
                Form.button16.Visible = false;
                Form.button7.Visible = false;
                Form.button13.Visible = false;
                Form.button10.Visible = false;
                Form.button12.Visible = false;
                Form.button2.Visible = false;
                Form.button9.Visible = false;
                Form.button14.Visible = false;
                Form.button11.Visible = false;
                Form.button15.Visible = false;
                Form.pictureBox2.Visible = false;
                Form.pictureBox6.Visible = false;

            }
            if (f.comboBox1.Text == "Responsable Production")
            {
                Form.button2.Visible = false;
                Form.button16.Visible = false;
                Form.button17.Visible = false;
                Form.button9.Visible = false;
                Form.button14.Visible = false;
                Form.button11.Visible = false;
                Form.button15.Visible = false;
                Form.pictureBox2.Visible = false;
                Form.button1.Visible = false;
                Form.button12.Visible = false;
                Form.button13.Visible = false;
                Form.button7.Visible = false;
                Form.button8.Visible = false;
                Form.pictureBox4.Visible = false;
            }
            if (f.comboBox1.Text == "Responsable Traitement")
            {
                Form.button6.Visible = false;
                Form.button17.Visible = false;
                Form.button8.Visible = false;
                Form.button16.Visible = false;
                Form.button7.Visible = false;
                Form.button13.Visible = false;
                Form.button10.Visible = false;
                Form.button12.Visible = false;
                Form.button2.Visible = false;
                Form.button9.Visible = false;
                Form.button14.Visible = false;
                Form.button11.Visible = false;
                Form.button15.Visible = false;
                Form.pictureBox4.Visible = false;
                Form.pictureBox6.Visible = false;
            }
            Form.ShowDialog();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<Commande> Listcommande = CommandeDAO.Get_commande_id(int.Parse(textBox1.Text));
                dataGridView1.DataSource = Listcommande;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Commande p = CommandeDAO.Get_commande_reference(int.Parse(textBox3.Text));
                textBox3.Text = p.Num_commande.ToString();
                comboBox1.Text = p.Reference_produit.ToString();
                textBox2.Text = p.Qt.ToString();
                dateTimePicker1.Text = p.Date_commande.ToString();
                dateTimePicker2.Text = p.Date_livraison_souhaité.ToString();

                List<Commande> L = new List<Commande>();
                L.Add(p);
                dataGridView1.DataSource = L;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                

                CommandeDAO.Update_commande(int.Parse(textBox1.Text), int.Parse(comboBox1.Text), int.Parse(textBox2.Text), DateTime.Parse(dateTimePicker1.Text), DateTime.Parse(dateTimePicker2.Text));
                MessageBox.Show("UPDATE done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {


                CommandeDAO.passer_commande(int.Parse(textBox1.Text), int.Parse(comboBox1.Text), int.Parse(textBox2.Text), DateTime.Parse(dateTimePicker1.Text), DateTime.Parse(dateTimePicker2.Text));

                string requete = string.Format("select Max(Num_commande) from Commande;");
                OleDbDataReader rd = utils.lire(requete);
                int A = 0;
                while (rd.Read())
                {
                    A = rd.GetInt32(0);
                }
                utils.Disconnect();
                textBox3.Text = A.ToString();
                
                MessageBox.Show("Le numéro de votre commande est: "+A);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Passer_commande_Load(object sender, EventArgs e)
        {

        }

        

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
             
                CommandeDAO.Delete_commande(int.Parse(textBox9.Text));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Vous ne pouvez pas annuler une commande sans appeler directement le service d'achat");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                List<Commande> Listcommande = CommandeDAO.Get_commande_non_traitée();
                dataGridView1.DataSource = Listcommande;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                List<Commande> Listcommande = CommandeDAO.Get_commande();
                dataGridView1.DataSource = Listcommande;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Commande p = CommandeDAO.Get_commande_reference(int.Parse(textBox5.Text));
                textBox5.Text = p.Num_commande.ToString();
                textBox8.Text = p.Reference_produit.ToString();
                textBox7.Text = p.Qt.ToString();
                textBox7.Text = p.ID_cl.ToString();
                dateTimePicker4.Text = p.Date_commande.ToString();
                dateTimePicker3.Text = p.Date_livraison_souhaité.ToString();
                dateTimePicker5.Text = p.Date_livraison_réel.ToString();
                comboBox2.Text = p.Etat_commande.ToString();

                List<Commande> L = new List<Commande>();
                L.Add(p);
                dataGridView1.DataSource = L;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                CommandeDAO.date_livraison(int.Parse(textBox5.Text),DateTime.Parse(dateTimePicker5.Text), comboBox2.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                CommandeDAO.date_livraison(int.Parse(textBox5.Text), DateTime.Parse(dateTimePicker5.Text), comboBox2.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
