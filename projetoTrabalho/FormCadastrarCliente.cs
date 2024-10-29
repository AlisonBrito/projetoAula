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
    public partial class FormCadastrarCliente : Form
    {

        public FormCadastrarCliente()
        {
            InitializeComponent();
        }
        GerenciadorBD gbd = new GerenciadorBD();
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Preencha todas as informações");
                }
                if (string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Preencha todas as informações");
                }

                string connection = gbd.getConnectionString();
                MySqlConnection conn = new MySqlConnection(connection);

                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into clientes (nome, cpf) " +
                    "values(@nome, @cpf)";
                    cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                    cmd.Parameters.AddWithValue("@cpf", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sucesso");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string connection = gbd.getConnectionString();
                MySqlConnection conn = new MySqlConnection(connection);

                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into clientes (nome, cpf) " +
                    "values(@nome, @cpf)";
                    cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                    cmd.Parameters.AddWithValue("@cpf", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sucesso");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FormCadastrarCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
