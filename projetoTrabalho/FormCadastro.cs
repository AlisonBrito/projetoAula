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
            bool MAIUSCULA = false;
            bool MINISCULA = false;
            bool CARACTERESPECIAL = false;

            // Verificar se os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Preencha todas as informações");
                return;
            }

            foreach (char c in textBox2.Text)
            {
                if (c >= 65 && c <= 90)
                {
                    MAIUSCULA = true;
                }

                if (c >= 97 && c <= 122)
                {
                    MINISCULA = true;
                }

                if ((c >= 33 && c <= 47) || (c >= 58 && c <= 64) || (c >= 91 && c <= 96) || (c >= 123 && c <= 126))
                {
                    CARACTERESPECIAL = true;
                }

                if (MAIUSCULA && MINISCULA && CARACTERESPECIAL)
                {
                    break; // Pode sair do loop se todos os critérios forem atendidos
                }
            }

            // Verificar se todos os critérios foram atendidos
            if (MAIUSCULA && MINISCULA && CARACTERESPECIAL)
            {
                MessageBox.Show("Cadastrado");

                MySqlCommand cmd = new MySqlCommand();
                string connection = gbd.getConnectionString();
                MySqlConnection conn = new MySqlConnection(connection);

                try
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO funcionarios (usuario, senha) VALUES (@usuario, @senha)";
                    cmd.Parameters.AddWithValue("@usuario", textBox1.Text);
                    cmd.Parameters.AddWithValue("@senha", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sucesso");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close(); // Sempre feche a conexão
                }
            }
            else
            {
                MessageBox.Show("A senha deve haver, LETRAS MAIÚSCULAS, MINÚSCULAS E CARACTERES ESPECIAIS");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormCadastro_Load(object sender, EventArgs e)
        {

        }

        private void FormCadastro_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
        
