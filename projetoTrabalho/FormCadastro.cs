using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using projetoTrabalho.Classes;

namespace projetoTrabalho
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
        }
        GerenciadorBD gbd = new GerenciadorBD();
        private void button2_Click(object sender, EventArgs e)
        {
            
            MySqlCommand cmd = new MySqlCommand();

            string connection = gbd.getConnectionString();
            MySqlConnection conn = new MySqlConnection(connection);

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "insert into funcionarios (usuario, senha) " +
                "values(@usuario, @senha)";
                cmd.Parameters.AddWithValue("@usuario", textBox1.Text);
                cmd.Parameters.AddWithValue("@senha", textBox2.Text);
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
