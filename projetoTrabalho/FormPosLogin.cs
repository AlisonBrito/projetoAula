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
    public partial class FormPosLogin : Form
    {
        public FormPosLogin()
        {
            InitializeComponent();
        }
        GerenciadorBD gbd = new GerenciadorBD();
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastrarCliente fcc = new FormCadastrarCliente();
            fcc.ShowDialog();
        }

        private void FormPosLogin_Load(object sender, EventArgs e)
        {
            string connection = gbd.getConnectionString();

            MySqlConnection conn = new MySqlConnection(connection);

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select id_clientes, nome, cpf from clientes";

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable clientes = new DataTable();

                da.Fill(clientes);

                dataGridView1.DataSource = clientes;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string connection = gbd.getConnectionString();

            MySqlConnection conn = new MySqlConnection(connection);

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update clientes set " 
                    + dataGridView1.Columns[e.ColumnIndex].HeaderText +
                    " " +
                    "= @value where id_clientes = @id";

                cmd.Parameters.AddWithValue
                    ("@value", dataGridView1.SelectedRows[0].Cells[e.ColumnIndex].Value);
                cmd.Parameters.AddWithValue
                    ("@id", dataGridView1.SelectedRows[0].Cells[1].Value);
                
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cliente alterado com sucesso");
            }
            catch (Exception)
            {

             
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string connection = gbd.getConnectionString();

            MySqlConnection conn = new MySqlConnection(connection);

            if (dataGridView1.Columns[e.ColumnIndex] is 
                DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                MessageBox.Show("Funcionando");
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from clientes where id_clientes = @id";
                    cmd.Parameters.AddWithValue("@id",
                        dataGridView1.SelectedRows[0].Cells[1].Value);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "select id_clientes, nome, cpf from clientes";

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    DataTable clientes = new DataTable();

                    da.Fill(clientes);

                    dataGridView1.DataSource = clientes;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = gbd.getConnectionString();

            MySqlConnection conn = new MySqlConnection(connection);

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM clientes WHERE nome LIKE @nome";
                cmd.Parameters.AddWithValue("@nome", '%' + textBox1.Text + '%');

                MySqlDataAdapter d = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                d.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception)
            {

               
            }

        }
    }
}
