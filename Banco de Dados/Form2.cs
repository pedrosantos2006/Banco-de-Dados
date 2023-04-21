using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_de_Dados
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=pokeagenda;password=;");
            MySqlCommand cmd =   new MySqlCommand("INSERT INTO t_pokemon ( nome, peso, altura, tipo, grau_evolucao, cidade) VALUES ( @Nome, @Peso, @Altura, @Tipo, @Grau_evolucao, @Cidade)", conn);

           // cmd.Parameters.AddWithValue("@Codigo", TextBoxCodigo.Text);
            cmd.Parameters.AddWithValue("@Nome", TextBoxNome.Text);
            cmd.Parameters.AddWithValue("@Peso", TextBoxPeso.Text);
            cmd.Parameters.AddWithValue("@Altura", TextBoxAltura.Text);
            cmd.Parameters.AddWithValue("@Tipo", TextBoxTipo.Text);
            cmd.Parameters.AddWithValue("@Grau_evolucao", TextBoxGrauEvolucao.Text);
            cmd.Parameters.AddWithValue("@Cidade", TextBoxCidade.Text);

            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Dados inseridos com sucesso!");
            }
            else
            {
                MessageBox.Show("Falha ao inserir os dados!");
            }

        }
    }
}
