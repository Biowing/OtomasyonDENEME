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
    public partial class ekleme : Form
    {
        OleDbConnection con;

        OleDbCommand cmd;


        public ekleme()
        {
            InitializeComponent();
        }
        double fyt, aln, sonuc;

        private void ekleme_Load(object sender, EventArgs e)
        {

            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=fantastik.accdb");



        }

        private void button2_Click(object sender, EventArgs e)
        {
            bilgi blg = new bilgi();
            blg.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            silinenler sln = new silinenler();
            sln.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {


            string tarih = dateTimePicker1.Value.ToShortDateString();
            string tarih2 = dateTimePicker2.Value.ToShortDateString();



            fyt = Convert.ToDouble(textBox7.Text);
            aln = Convert.ToDouble(textBox8.Text);
            sonuc = fyt - aln;
            textBox3.Text = Convert.ToString(sonuc);
            cmd = new OleDbCommand();
            label11.Text = sonuc.ToString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into musteri (ad,soyad,alinan_trh,verilecek_trh,telefon,eposta,fiyat,alinan,alma_turu,kalan) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + tarih + "','" + tarih2 + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "')";
            cmd.ExecuteNonQuery();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }
    }
}
