using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace DataControlApp{

  
    public partial class Form1 : Form
    {

        IFirebaseConfig ifc = new FirebaseConfig(){
            AuthSecret = "qlDUgLSDUYM1OqcOnlecbAEDhbFWJI8MCMUtZpYU",
            BasePath = "https://kkfldatabase-default-rtdb.europe-west1.firebasedatabase.app"
        };
            IFirebaseClient client;

        public Form1(){
            InitializeComponent();
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FirebaseClient(ifc);
            }
            catch
            {
                MessageBox.Show("there was a problem in your internet");
            }
            
        }
        
        private void btn_ekle_Click(object sender, EventArgs e)
        {
            int girilenSirano = Convert.ToInt32(txt_sirano.Text);
            int girilenNumara = Convert.ToInt32(txt_numara.Text);
            int girilenSınıf = Convert.ToInt32(txt_sınıf.Text);
            char girilenSube=Convert.ToChar(txt_sube.Text);

            bool girilenYatılılık = false;


            if(txt_yatılılık.Text.ToLower()=="1")
            {
                girilenYatılılık = true;
            }
            else if(txt_yatılılık.Text.ToLower()=="0")
            {
                girilenYatılılık = false;
            }
            else
            {
                MessageBox.Show("Hatalı Yatılılık Bilgisi", "Hata");
            }

            var result = client.Get("IndexCount");
            int i = result.ResultAs<int>();

            i++;

            Ogrenci o = new Ogrenci(girilenSirano,txt_isim.Text,txt_soyisim.Text,girilenNumara,girilenSınıf,girilenSube,girilenYatılılık);
           
            client.Set("StudentList/"+"Öğrenci"+girilenSirano , o);
            MessageBox.Show("data inserted successfully");
           // client.Update("IndexCount/", Convert.ToInt32(i));

            temizle();

        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            int girilenSirano = Convert.ToInt32(txt_sirano.Text);


            client.Delete("StudentList/" + "Öğrenci" + girilenSirano);
        }

        private void btn_güncelle_Click(object sender, EventArgs e)
        {
            int girilenSirano = Convert.ToInt32(txt_sirano.Text);
            int girilenNumara = Convert.ToInt32(txt_numara.Text);
            int girilenSınıf = Convert.ToInt32(txt_sınıf.Text);
            char girilenSube = Convert.ToChar(txt_sube.Text);

            bool girilenYatılılık = false;


            if (txt_yatılılık.Text.ToLower() == "1")
            {
                girilenYatılılık = true;
            }
            else if (txt_yatılılık.Text.ToLower() == "0")
            {
                girilenYatılılık = false;
            }
            else
            {
                MessageBox.Show("Hatalı Yatılılık Bilgisi", "Hata");
            }




            Ogrenci o = new Ogrenci(girilenSirano, txt_isim.Text, txt_soyisim.Text, girilenNumara, girilenSınıf, girilenSube, girilenYatılılık);
            client.Update("StudentList/" + "Öğrenci" + girilenSirano, o);
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {

            if(txt_isim.Text != null){
            
            }else if (txt_soyisim != null){

            }
            else if (txt_soyisim != null){

            }
            else if (txt_soyisim != null){

            }

        }

        public void temizle()
        {
            txt_isim.Text = string.Empty;
            txt_soyisim.Text = string.Empty;
          //  txt_sınıf.Text = string.Empty;
          //  txt_sube.Text = string.Empty;
            txt_numara.Text = string.Empty;
            txt_yatılılık.Text = string.Empty;
        }


        private void btn_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
