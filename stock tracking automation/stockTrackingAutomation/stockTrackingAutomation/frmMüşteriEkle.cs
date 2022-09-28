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
    public partial class frmMüşteriEkle : Form
    {

        // // https://www.youtube.com/watch?v=-4E5qZtRz6M //  
        public frmMüşteriEkle()
        {
            InitializeComponent();
        }

        private void frmMüşteriEkle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand commandRegister = new SqlCommand("insert into musteri(TC,AdSoyad,Telefon,Adres,email) values(@ptc,@padsoyad,@ptelefon,@padres,@pemail)",SqlOperations.connection);
            SqlOperations.CheckConnection(SqlOperations.connection);

            commandRegister.Parameters.AddWithValue("@ptc", txtTC.Text);
            commandRegister.Parameters.AddWithValue("@padsoyad", txtAdsoyad.Text);
            commandRegister.Parameters.AddWithValue("@ptelefon", txttel.Text);
            commandRegister.Parameters.AddWithValue("@padres", txtADres.Text);
            commandRegister.Parameters.AddWithValue("@pemail", txtemail.Text);

            commandRegister.ExecuteNonQuery();

            MessageBox.Show("Müşteri Kaydı Eklendi.");

            foreach (Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }

        }
    }
}
