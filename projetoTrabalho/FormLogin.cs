using MySql.Data.MySqlClient;
using projetoTrabalho.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoTrabalho
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        GerenciadorBD gbd = new GerenciadorBD();
        private void button1_Click(object sender, EventArgs e)
        {
  
        } 
    

        private void button2_Click(object sender, EventArgs e)
        {
                FormCadastro fcf = new FormCadastro();
                fcf.ShowDialog(); 
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.Enter)
            {
                string connection = gbd.getConnectionString();

                MySqlConnection conn = new MySqlConnection(connection);
                string nome = textBox1.Text;
                string senha = textBox2.Text;
                bool nomeOK = false;
                bool senhaOK = false;

                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from funcionarios";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (nome == reader.GetValue(1).ToString())
                        {
                            nomeOK = true;
                        }
                        if (nomeOK)
                        {
                            if (senha == reader.GetValue(2).ToString())
                            {
                                senhaOK = true;
                            }
                            break;
                        }
                    }
                    if (nomeOK && senhaOK)
                    {
                        MessageBox.Show("Bem vindo ao sistema");
                    }
                    else
                    {
                        MessageBox.Show("Dados Incorretos");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            FormPosLogin fcf = new FormPosLogin();
            fcf.ShowDialog();
            }
        } 


        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode == Keys.Enter)
            {
                string connection = gbd.getConnectionString();

                MySqlConnection conn = new MySqlConnection(connection);
                string nome = textBox1.Text;
                string senha = textBox2.Text;
                bool nomeOK = false;
                bool senhaOK = false;

                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from funcionarios";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (nome == reader.GetValue(1).ToString())
                        {
                            nomeOK = true;
                        }
                        if (nomeOK)
                        {
                            if (senha == reader.GetValue(2).ToString())
                            {
                                senhaOK = true;
                            }
                            break;
                        }
                    }
                    if (nomeOK && senhaOK)
                    {
                        MessageBox.Show("Bem vindo ao sistema");
                    }
                    else
                    {
                        MessageBox.Show("Dados Incorretos");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                FormPosLogin fcf = new FormPosLogin();
                fcf.ShowDialog();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }
    }
}  
