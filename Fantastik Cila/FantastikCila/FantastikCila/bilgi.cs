using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FantastikCila
{
    public partial class bilgi : Form
    {
        public bilgi()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand komut = new OleDbCommand();
        DataSet ds;
     
        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=fantastik.accdb");
            da = new OleDbDataAdapter("select * From musteri  ORDER BY verilecek_trh", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "musteri");
            dataGridView1.DataSource = ds.Tables["musteri"];
        }

        private void bilgi_Load(object sender, EventArgs e)
        {
         
            griddoldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
          
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            comboBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox4.Text=dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
           
            double a, b,sonuc;
            a = Convert.ToDouble(textBox7.Text);
            b = Convert.ToDouble(textBox8.Text);
            sonuc = a - b;
            string c = Convert.ToString(sonuc);
            textBox4.Text = c;
            label10.Text = textBox4.Text;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int a, b, sonuc;
            a = Convert.ToInt16(textBox7.Text);
            b = Convert.ToInt16(textBox8.Text);
            sonuc = a - b;
            string c = Convert.ToString(sonuc);
            textBox4.Text = c;
            label10.Text = textBox4.Text;
            OleDbCommand cmd = new OleDbCommand();

            cmd.Connection = con;
            cmd.CommandText = "update musteri set ad='" + textBox3.Text + "',soyad='" + textBox2.Text + "',verilecek_trh='" + dateTimePicker2.Text + "',telefon='" + textBox5.Text + "',eposta='" + textBox6.Text + "',fiyat='" + textBox7.Text + "',alinan='" + textBox8.Text + "',alma_turu='" + comboBox1.Text + "',kalan='" + textBox4.Text + "' where kimlik=" + id.Text + "";
            cmd.ExecuteNonQuery();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sorgu;
            sorgu = "Select  * From musteri where ad Like '" + textBox1.Text + "%'";
            OleDbDataAdapter getir = new OleDbDataAdapter(sorgu, con);
            DataSet göster = new DataSet();
            getir.Fill(göster, "musteri");
            dataGridView1.DataSource = göster.Tables["musteri"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ekleme ek = new ekleme();
            ek.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            silinenler sln = new silinenler();
            sln.Show();
            this.Hide();
        }
    }
}
