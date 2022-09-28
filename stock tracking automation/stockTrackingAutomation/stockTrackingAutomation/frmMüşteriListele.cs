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

namespace stockTrackingAutomation
{
    public partial class frmMüşteriListele : Form
    {

        // https://www.youtube.com/watch?v=-4E5qZtRz6M // 
        public frmMüşteriListele()
        {
            InitializeComponent();
        }
        private void frmMüşteriListele_Load(object sender, EventArgs e)
        {
            LoadOrRefreshPage();
            // ctrl+r+m  = yeni method haline getirir...
        }

        private void LoadOrRefreshPage()
        {
            SqlCommand commandList = new SqlCommand("select * from musteri",SqlOperations.connection);
            
            SqlOperations.CheckConnection(SqlOperations.connection);
            
            SqlDataAdapter da = new SqlDataAdapter(commandList);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            tboxTC.Text = dataGridView1.CurrentRow.Cells["TC"].Value.ToString();
            tboxAdsoyad.Text = dataGridView1.CurrentRow.Cells["AdSoyad"].Value.ToString();
            tboxTel.Text = dataGridView1.CurrentRow.Cells["Telefon"].Value.ToString();
            tboxADres.Text = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
            tboxEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand commandUpdate = new SqlCommand("Update musteri set AdSoyad=@adsoyad,Telefon=@ptelefon,Adres=@padres,email=@email where TC=@ptc ", SqlOperations.connection);

            commandUpdate.Parameters.AddWithValue("@ptc", tboxTC.Text);
            commandUpdate.Parameters.AddWithValue("@padsoyad", tboxAdsoyad.Text);
            commandUpdate.Parameters.AddWithValue("@ptelefon", tboxTel.Text);
            commandUpdate.Parameters.AddWithValue("@padres", tboxADres.Text);
            commandUpdate.Parameters.AddWithValue("@pemail", tboxEmail.Text);

            commandUpdate.ExecuteNonQuery();

            LoadOrRefreshPage();

            MessageBox.Show("Müşteri Kaydı Güncellendi.");

            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand commandDelete = new SqlCommand("Delete from musteri where TC= '"+dataGridView1.CurrentRow.Cells["TC"].Value.ToString()+"' ",SqlOperations.connection);

            SqlOperations.CheckConnection(SqlOperations.connection);

            commandDelete.ExecuteNonQuery();

            LoadOrRefreshPage();

            MessageBox.Show("Kayıt Silindi");
        }

        private void txtTcArama_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from musteri where TC like '%"+txtTcArama.Text+"%'",SqlOperations.connection);

            SqlOperations.CheckConnection(SqlOperations.connection);

            DataTable tablo = new DataTable();

            da.Fill(tablo);

            dataGridView1.DataSource = tablo;
        }
    }
}
