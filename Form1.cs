using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-KMVKNF3\\SQLEXPRESS;Initial Catalog=Personeller;Integrated Security=True");
        DataTable  dt;

        private void Listele()
        {
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select * from Personel", baglanti); // sorguyu çalıştırır
            SqlDataReader sonuc = sorgu.ExecuteReader();

            dt = new DataTable();

            dt.Load(sonuc);

            dataGridView1.DataSource = dt;

            baglanti.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into Personel(ad_soyad, gorevi, ucret, giris_tarihi, bolum_no) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);

            cmd.ExecuteNonQuery();

            baglanti.Close();

            Listele();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("ad_soyad LIKE '" + textBox6.Text + "%'");

            dataGridView1.DataSource = dv;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand sil = new SqlCommand("delete from Personel where personel_no =" + textBox7.Text, baglanti);

            sil.ExecuteNonQuery();

            baglanti.Close();

            Listele();

            textBox7.Clear();
        }
    }
}
