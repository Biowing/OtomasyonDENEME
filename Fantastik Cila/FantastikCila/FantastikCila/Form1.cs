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
using System.Media;

namespace FantastikCila
{
    public partial class Form1 : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand komut = new OleDbCommand();
        DataSet ds;
        OleDbDataReader dr;
        public Form1()
        {

            InitializeComponent();
        }

        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=fantastik.accdb");
            da = new OleDbDataAdapter("select * From musteri  ORDER BY verilecek_trh", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "musteri");
            dataGridView1.DataSource = ds.Tables["musteri"];
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           

            textBox2.Text = DateTime.Now.ToShortDateString();
            DateTime a = Convert.ToDateTime(textBox2.Text);



            griddoldur();

            string trh=textBox3.Text;

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM musteri where verilecek_trh='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                


                notifyIcon1.ShowBalloonTip(2000, "Uyarı!", "Verilecek Teslimatlar Var!!", ToolTipIcon.Info);
                label2.ForeColor = Color.Red;
                label2.Text = "Verilecek Teslimatlarınız Var!";
                SoundPlayer ses = new SoundPlayer();
                string dizin = Application.StartupPath + "\\Whatsapp Bildirim Sesi ( Orjinal ).wav";
                ses.SoundLocation = dizin;
                ses.Play();
            }
            else
            {
               
                label2.Text = "Verilecek Teslimatlarınız Yok";
            }

            }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ekleme ek = new ekleme();
            ek.Show();

        }

      
 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            bilgi blg = new bilgi();
            blg.Show();
          
        }



       private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            string sorgu;
            sorgu = "Select  * From musteri where ad Like '" + textBox1.Text + "%'";
            OleDbDataAdapter getir = new OleDbDataAdapter(sorgu, con);
            DataSet göster = new DataSet();
            getir.Fill(göster, "musteri");
            dataGridView1.DataSource = göster.Tables["musteri"];
            getir.Dispose();
        }
        
        private void button6_Click(object sender, EventArgs e)
        {

            if (ad.Text == "")
            {
                MessageBox.Show("Tıklamayı Unuttunuz!!");
                return;

            }
            else
            {
                OleDbCommand cmd = new OleDbCommand();

                string tarih = dateTimePicker1.Value.ToShortDateString();
                string tarih2 = dateTimePicker2.Value.ToShortDateString();
                cmd.Connection = con;
                cmd.CommandText = "insert into silinen (ad,soyad,alinan_trh,verilecek_trh,telefon,eposta,fiyat,alinan,alma_turu,kalan) values ('" + ad.Text + "','" + soyad.Text + "','" + tarih + "','" + tarih2 + "','" + telefon.Text + "','" + eposta.Text + "','" + fiyat.Text + "','" + alinan.Text + "','" + alma.Text + "','" + kalan.Text + "')";
                cmd.ExecuteNonQuery();

                komut.Connection = con;

                komut.CommandText = ("Delete From musteri where Kimlik=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "");
                komut.ExecuteNonQuery();
                Application.Restart();
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            silinenler sln = new silinenler();
            sln.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            soyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            telefon.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            eposta.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            fiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            alinan.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            alma.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            kalan.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
        }

        private void fiyat_TextChanged(object sender, EventArgs e)
        {

        }

        private void eposta_TextChanged(object sender, EventArgs e)
        {

        }

        private void telefon_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void soyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void ad_TextChanged(object sender, EventArgs e)
        {

        }

        private void alma_TextChanged(object sender, EventArgs e)
        {

        }

        private void kalan_TextChanged(object sender, EventArgs e)
        {

        }

        private void alinan_TextChanged(object sender, EventArgs e)
        {

        }
    }
        }
    
