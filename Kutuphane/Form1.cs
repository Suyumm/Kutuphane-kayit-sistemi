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

namespace Kutuphane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection ray = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");

        int kayitsayisi = 0;

        private void kayit()
        {
            try
            {
                ray.Open();
                OleDbDataAdapter liste = new OleDbDataAdapter("select * from kutup", ray);
                DataSet dsBilgi = new DataSet();
                liste.Fill(dsBilgi);
                dataGridView1.DataSource = dsBilgi.Tables[0];
                ray.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                ray.Close();
            }
        }

        private void Say()
        {
            kayitsayisi = dataGridView1.RowCount;
            kayitsayisi--;
            label9.Text = kayitsayisi.ToString();

            kayit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kayit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ray.Open();
            OleDbCommand kaydet = new OleDbCommand("insert into kutup(isbn,adi,yazar_adi,sayfaSayisi,turu,yayinEvi,seri)values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "')", ray);
            kaydet.ExecuteNonQuery();
            ray.Close();

            MessageBox.Show("Kitap kaydedildi");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            kayit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ray.Open();
            OleDbCommand sil = new OleDbCommand("delete from kutup where isbn='" + textBox1.Text + "'", ray);
            sil.ExecuteNonQuery();
            ray.Close();

            MessageBox.Show("Kitap Silindi");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;

            kayit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ray.Open();
            OleDbCommand guncelle = new OleDbCommand("update kutup set adi= '" + textBox2.Text + "',yazar_adi='" + textBox3.Text + "',sayfaSayisi='" + textBox4.Text + "',turu='" + comboBox1.Text + "',yayinEvi='" + textBox5.Text + "',seri='" + comboBox2.Text + "' where isbn='" + textBox1.Text + "'", ray);
            guncelle.ExecuteNonQuery();
            ray.Close();

            MessageBox.Show("Kitap Güncellendi");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;

            kayit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ray.Open();
                OleDbDataAdapter ara = new OleDbDataAdapter("select * from kutup where isbn ='" + textBox1.Text + "'", ray);
                DataSet ds = new DataSet();
                ara.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                ray.Close();

                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                ray.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 ray2 = new Form2();
            ray2.Show();

            try
            {
                ray.Open();
                OleDbDataAdapter liste = new OleDbDataAdapter("select * from kutup where adi ='" + textBox2.Text + "'", ray);
                DataSet dsBilgi = new DataSet();
                liste.Fill(dsBilgi);
                ray2.dataGridView1.DataSource = dsBilgi.Tables[0];
                ray.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                ray.Close();

                kayit();
            }
        }
    }
}
