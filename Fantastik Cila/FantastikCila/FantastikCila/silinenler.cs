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
    public partial class silinenler : Form
    {
        public silinenler()
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
            da = new OleDbDataAdapter("select * From silinen  ORDER BY verilecek_trh", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "musteri");
            dataGridView1.DataSource = ds.Tables["musteri"];

        }
        private void silinenler_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sorgu;
            sorgu = "Select  * From silinen where ad Like '" + textBox1.Text + "%'";
            OleDbDataAdapter getir = new OleDbDataAdapter(sorgu, con);
            DataSet göster = new DataSet();
            getir.Fill(göster, "silinen");
            dataGridView1.DataSource = göster.Tables["silinen"];
            getir.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ekleme ekl = new ekleme();
            ekl.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bilgi blg = new bilgi();
            blg.Show();
            this.Hide();
        }
    }
}
