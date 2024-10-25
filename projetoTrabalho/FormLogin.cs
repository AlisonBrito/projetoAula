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
                if(nomeOK && senhaOK)
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

            /*
            string usuario = "abc", senha = "dfg", retorno = "";
            bool verificaLogin = false;
                
            if(textBox1.Text != usuario)
            {
                retorno += "O usuario esta incorreto\n";
                verificaLogin = true;
            }

            if(textBox2.Text != senha) 
            {
                retorno += "A senha esta incorreta";
                verificaLogin = true;
            }

            if(verificaLogin) 
            {
                MessageBox.Show("Algo deu errado: \n" + retorno);
            }
            else
            {
                MessageBox.Show("Bem Vindo!");
            }*/
        } 
    

        private void button2_Click(object sender, EventArgs e)
        {
                FormCadastro fcf = new FormCadastro();
                fcf.ShowDialog(); 
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}  
