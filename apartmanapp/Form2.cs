using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace apartmanapp
{
    public partial class Form2 : Form
    {
        public string ad;
        public string soyad;
        public string telno;
        public string daireno;
        public int aidat;
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=apartmandb;Uid=root;Pwd='';");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = ad+" "+soyad;
            label4.Text = telno;
            label5.Text = daireno;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int toplam = aidat += int.Parse(textBox1.Text);
            string sql = "UPDATE kisiler SET aidat=@aidat WHERE ad=@ad OR soyad=@soyad OR telno=@telno OR daireno=@daireno";
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ad", ad);
            cmd.Parameters.AddWithValue("@soyad", soyad);
            cmd.Parameters.AddWithValue("@telno", telno);
            cmd.Parameters.AddWithValue("@daireno", daireno);
            cmd.Parameters.AddWithValue("@aidat", toplam);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Aidat Eklendi.");
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int toplam = aidat -= int.Parse(textBox1.Text);
            string sql = "UPDATE kisiler SET aidat=@aidat WHERE ad=@ad OR soyad=@soyad OR telno=@telno OR daireno=@daireno";
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ad", ad);
            cmd.Parameters.AddWithValue("@soyad", soyad);
            cmd.Parameters.AddWithValue("@telno", telno);
            cmd.Parameters.AddWithValue("@daireno", daireno);
            cmd.Parameters.AddWithValue("@aidat", toplam);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Aidat Ödendi.");
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
