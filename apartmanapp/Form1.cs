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
    public partial class Form1 : Form
    {

        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=apartmandb;Uid=root;Pwd='';");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        public string id;
        public Form1()
        {
            InitializeComponent();
        }

        void VeriGetir()
        {
            dt = new DataTable();
            conn.Open();
            adapter = new MySqlDataAdapter("SELECT *FROM kisiler", conn);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VeriGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into kisiler (ad,soyad,telno,daireno) values (@ad,@soyad,@telno,@daireno)";
            cmd = new MySqlCommand(sorgu, conn);
            cmd.Parameters.AddWithValue("@ad", txtad.Text);
            cmd.Parameters.AddWithValue("@soyad", txtsoyad.Text);
            cmd.Parameters.AddWithValue("@telno", txttel.Text);
            cmd.Parameters.AddWithValue("@daireno", txtdaire.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            VeriGetir();
            MessageBox.Show("Kayıt Eklendi.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "Delete From kisiler Where telno=@telno";
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@telno", txttel.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            VeriGetir();
            MessageBox.Show("Kayıt silindi.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE kisiler SET ad=@ad, soyad=@soyad, telno=@telno, daireno=@daireno WHERE id="+id;
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ad", txtad.Text);
            cmd.Parameters.AddWithValue("@soyad", txtsoyad.Text);
            cmd.Parameters.AddWithValue("@telno", txttel.Text);
            cmd.Parameters.AddWithValue("@daireno", txtdaire.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            VeriGetir();
            MessageBox.Show("Kayıt güncellendi.");
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txttel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtdaire.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "ad LIKE '" + txtara.Text + "%' OR soyad LIKE '" + txtara.Text + "%' OR telno LIKE '" + txtara.Text + "%' OR daireno LIKE '" + txtara.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ad = dataGridView1.CurrentRow.Cells[1].Value.ToString(); 
            form2.soyad = dataGridView1.CurrentRow.Cells[2].Value.ToString(); 
            form2.telno = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            form2.daireno = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            form2.aidat = int.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            form2.Show();
            this.Hide();
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
           
        }
    }
}
