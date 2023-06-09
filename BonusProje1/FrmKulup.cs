﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BonusProje1
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=RIFAT;Initial Catalog=BonusOkul;Integrated Security=True");
         public void liste ()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLKULUPLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmKulup_Load(object sender, EventArgs e)
        {
            liste();

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("INSERT INTO TBLKULUPLER (KULUPAD) VALUES (@P1)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKulüpAd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Listeye Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKulüpId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulüpAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete From TBLKULUPLER WHERE KULUPID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKulüpId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Silindi");
            liste();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update TBLKULUPLER SET KULUPAD=@P1 WHERE KULUPID=@P2", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKulüpAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtKulüpId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup Güncelleme Yapıldı.");
            liste();

        }
    }
}
