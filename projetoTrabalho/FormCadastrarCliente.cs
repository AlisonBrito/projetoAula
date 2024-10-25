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
}
