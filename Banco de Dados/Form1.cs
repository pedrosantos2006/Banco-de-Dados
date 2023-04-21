﻿using MySql.Data.MySqlClient;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=pokeagenda;password=;");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM t_pokemon", conn);

            // DataTable = armazenar os resultados da consulta
            DataTable dt = new DataTable();
            conn.Open();

            // MySqlDataAdapter = preencher os resultados da consulta
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();

            //Vincule o DataTable ao DataGridView para exibir os dados na grade
            dataGridView1.DataSource = dt;
        }

        private void TextBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            string pesquisa = TextBoxPesquisa.Text;
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=pokeagenda;password=;");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM t_pokemon where nome like '%"+pesquisa+"%'", conn);

            DataTable dt = new DataTable();
            conn.Open();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();

            dataGridView1.DataSource = dt;

        }

        private void ButtonCadastro_Click(object sender, EventArgs e)
        {
            Form fcadstro = new Form2();
            fcadstro.Show();
        }
    }
}
