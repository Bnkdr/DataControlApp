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
using FireSharp.Response;
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

        
        private void btn_ekle_Click_1(object sender, EventArgs e)
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

        private void btn_ara_Click_1(object sender, EventArgs e)
        {
             // Kadir was here haha  
            //sira no bazli öğrenci sorgulama
            //yapim aşamasında ben kendim devam edicem  for döngüsünde tüm kişiler gözüküyo bunu listeye aktarmak kaldi birde sorgulama fonksiyonlarini yapmak (kadir)
            if (txt_sirano.Text != ""){
                FirebaseResponse result = client.Get(@"StudentList/Öğrenci"+txt_sirano.Text);
                Ogrenci ogrenci_result = result.ResultAs<Ogrenci>();
                MessageBox.Show("İsmi : " + Convert.ToString(ogrenci_result.isim) + " " + " Soyismi : " + Convert.ToString(ogrenci_result.soyisim) + " Numarasi : " + Convert.ToString(ogrenci_result.numara), "Bilgilendirme");
            }
            else{
                int sinif_var = 0;
                int sube_var = 0;
                int sira_var = 0;
                for(sinif_var = 9; sinif_var < 13; sinif_var++)
                {
                    for (sube_var = 1; sube_var< 5; sube_var++)
                    {
                        for (sira_var = 1; sira_var < 100; sira_var++)
                        {
                            String siraString;
                            if (sira_var < 10)
                            {
                                siraString = Convert.ToString(sinif_var) + Convert.ToString(sube_var) + "0" +Convert.ToString(sira_var);
                            }
                            else
                            {
                                siraString =Convert.ToString(sinif_var)+Convert.ToString(sube_var)+Convert.ToString(sira_var);
                            }


                            if (client.Get(@"StudentList/Öğrenci" +siraString).ResultAs<Ogrenci>() == null)
                            {
                                break;
                                MessageBox.Show(siraString + " Belirtilen sayida öğrenci bulunamadi", "Bilgilendirme");
                            }
                            else
                            {
                                var yanit = client.Get(@"StudentList/Öğrenci" + siraString);
                                Ogrenci ogrenci_var = yanit.ResultAs<Ogrenci>();
                                String ismi = ogrenci_var.isim;
                                String soyismi = ogrenci_var.soyisim;
                                int numarasi = ogrenci_var.numara;
                                // MessageBox.Show("İsmi : " + Convert.ToString(ismi) + " " + "Soyismi : " + Convert.ToString(soyismi) + "Numarasi : " + Convert.ToString(numarasi), "Bilgilendirme");
                                // MessageBox.Show(Convert.ToString(ogrenci_var.isim) + " " + Convert.ToString(ogrenci_var.soyisim), "Bilgilendirme");
                                // MessageBox.Show(siraString, "Bilgilendirme");
                                if (ogrenci_var == null)
                                {
                                    break;
                                    MessageBox.Show(Convert.ToString(ogrenci_var.sirano) + " Belirtilen sayida öğrenci bulunamadi", "Bilgilendirme");
                                }
                            }
                        }
                    }
                }
              
                    
                    
                    
                
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

        private void button4_Click(object sender, EventArgs e)
        {
            int girilenÖğretmenSirano = Convert.ToInt32(txt_ösirano.Text);

            Öğretmen öğretmen = new Öğretmen(girilenÖğretmenSirano, txt_öisim.Text, txt_ösoyisim.Text, txt_ders.Text);

            client.Set("TeacherList/" + "Öğretmen" + girilenÖğretmenSirano, öğretmen);

            MessageBox.Show("Data inserted successfully", "Bilgilendirme");

            temizle();

        }

        private void btn_ösil_Click(object sender, EventArgs e)
        {
            int girilenÖğretmenSirano = Convert.ToInt32(txt_ösirano.Text);

            client.Delete("TeacherList/" + "Öğretmen" + girilenÖğretmenSirano);


        }

        private void btn_ögüncelle_Click(object sender, EventArgs e)
        {
            int girilenÖğretmenSirano = Convert.ToInt32(txt_ösirano.Text);

            Öğretmen öğretmen = new Öğretmen(girilenÖğretmenSirano, txt_öisim.Text, txt_ösoyisim.Text, txt_ders.Text);
            client.Update("TeacherList/" + "Öğretmen" + girilenÖğretmenSirano, öğretmen);

        }

        private void btn_idareekle_Click(object sender, EventArgs e)
        {
            int girilenİdareSirano = Convert.ToInt32(txt_idaresirano.Text);

            İdare idare = new İdare(girilenİdareSirano, txt_idareisim.Text, txt_idaresoyisim.Text, txt_görev.Text);

            client.Set("AdministrationList/" + "İdareci" + girilenİdareSirano, idare);

            MessageBox.Show("Data inserted successfully;", "Bilgilendirme");

            temizle();


        }

        private void btn_idaresil_Click(object sender, EventArgs e)
        {
            int girilenİdareSirano = Convert.ToInt32(txt_idaresirano.Text);

            client.Delete("AdministrationList/" + "İdareci" + girilenİdareSirano);
        }

        private void btn_idaregünc_Click(object sender, EventArgs e)
        {
            int girilenİdareSirano = Convert.ToInt32(txt_idaresirano.Text);

            İdare idare = new İdare(girilenİdareSirano, txt_idareisim.Text, txt_idaresoyisim.Text, txt_görev.Text);

            client.Update("AdministrationList/" + "İdareci" + girilenİdareSirano, idare);
        }

       

        
    }
}
