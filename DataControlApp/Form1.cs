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
using System.ComponentModel.Design.Serialization;
using Newtonsoft.Json;

namespace DataControlApp{

  
    public partial class Form1 : Form
    {

        IFirebaseConfig ifc = new FirebaseConfig(){
            AuthSecret = "qlDUgLSDUYM1OqcOnlecbAEDhbFWJI8MCMUtZpYU",
            BasePath = "https://kkfldatabase-default-rtdb.europe-west1.firebasedatabase.app" 

        };
            IFirebaseClient client;

        IFirebaseConfig ifc2 = new FirebaseConfig()
        {
            AuthSecret = "2inVCykQM5Pd7bwsaCbMYh38tXU8WcQkMSs1qRhl",
            BasePath = "https://privatedata-506ba-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client2;

        public Form1(){
            InitializeComponent();
           

        }

        List<Ogrenci> öğrenciler_list;
        private void Form1_Load(object sender, EventArgs e)
        {
            try{
                client = new FirebaseClient(ifc);
                client2 = new FirebaseClient(ifc2);

            }
            catch{
                MessageBox.Show("there was a problem in your internet");
            }

            fetchData(client);
            
          //  foreach(Ogrenci o in öğrenciler_list){
          //      MessageBox.Show(o.sirano + "  "+o.isim + "  " + o.soyisim+" "+o.numara);
         //   }
         
        }

        
        private void btn_ekle_Click_1(object sender, EventArgs e){
            InsertData_ogrenci(client);
        }

        private void btn_sil_Click(object sender, EventArgs e){
            DeleteData_ogrenci(client);
        }

        private void btn_güncelle_Click(object sender, EventArgs e){
            UpdateData_ogrenci(client);
        }

        private void btn_ara_Click_1(object sender, EventArgs e){
             // Kadir was here haha  
            if (txt_sirano.Text != ""){
                SearchOgrenciById(client, txt_sirano.Text);
            }else if(txt_isim.Text !="" && txt_soyisim.Text != ""){

                SearchOgrenciByNameAndSurname(client, txt_isim.Text.ToLower(), txt_soyisim.Text.ToLower());
            }else if(txt_numara.Text != ""){
                SearchOgrenciByNumber(client, txt_numara.Text.ToLower());
            }
         }
          

        

        public void temizle()
        {
            txt_isim.Text = string.Empty;
            txt_soyisim.Text = string.Empty;
            txt_sınıf.Text = string.Empty;
            txt_sube.Text = string.Empty;
            txt_numara.Text = string.Empty;
            txt_yatılılık.Text = string.Empty;
            txt_anneisim.Text = string.Empty;
            txt_annemeslek.Text = string.Empty;
            txt_annetelno.Text = string.Empty;
            txt_babaisim.Text = string.Empty;
            txt_babameslek.Text = string.Empty;
            txt_babatelno.Text = string.Empty;
            txt_bosSoru.Text = string.Empty;
            txt_burs.Text = string.Empty;
            txt_cinsiyet.Text = string.Empty;
            txt_hobiler.Text = string.Empty;
            txt_dogumGunu.Text = string.Empty;
            txt_LgsPuanı.Text = string.Empty;
            txt_oBeklenti.Text = string.Empty;
            txt_tcno.Text = string.Empty;
            txt_telno.Text = string.Empty;
            txt_yanlisSoru.Text = string.Empty;
            txt_yüzde.Text = string.Empty;
        }


        private void btn_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InsertData_öğretmen(client);
        }

        private void btn_ösil_Click(object sender, EventArgs e)
        {
            DeleteData_öğretmen(client);
        }

        private void btn_ögüncelle_Click(object sender, EventArgs e){
            UpdateData_öğretmen(client);
        }

        private void btn_idareekle_Click(object sender, EventArgs e){
            InsertData_idare(client);
        }

        private void btn_idaresil_Click(object sender, EventArgs e){
            DeleteData_idare(client);
        }

        private void btn_idaregünc_Click(object sender, EventArgs e){
            UpdateData_idare(client);
        }

        private void SearchOgrenciById(IFirebaseClient client, String sira){
            FirebaseResponse result = client.Get(@"StudentList/Öğrenci" + sira);
            Ogrenci ogrenci_result = result.ResultAs<Ogrenci>();
            string ismi = Convert.ToString(ogrenci_result.isim);
            string soyismi = Convert.ToString(ogrenci_result.soyisim);
            string numarasi = Convert.ToString(ogrenci_result.numara);
            string sinifi = Convert.ToString(ogrenci_result.sınıf);
            string şubesi = Convert.ToString(ogrenci_result.şube);
            if (ogrenci_result.yatılılık)
            {
                txt_yatılılık.Text = "1";
            }
            else
            {
                txt_yatılılık.Text = "0";
            }
            string tc_numarasi = Convert.ToString(ogrenci_result.tcno);
            string telefon_numarasi = Convert.ToString(ogrenci_result.telno);
            string anne_ismi = Convert.ToString(ogrenci_result.anneisim);
            string anne_telefon_numarsi = Convert.ToString(ogrenci_result.annetelno);
            string anne_mesleği = Convert.ToString(ogrenci_result.annemeslek);
            string baba_ismi = Convert.ToString(ogrenci_result.babaisim);
            string baba_mesleği = Convert.ToString(ogrenci_result.babameslek);
            string baba_telefon_numarasi = Convert.ToString(ogrenci_result.babatelno);
            string hobileri = Convert.ToString(ogrenci_result.hobi);
            string sira_nosu = Convert.ToString(ogrenci_result.sirano);
            string yüzdeliği = Convert.ToString(ogrenci_result.girişyüzdesi);
            if (Convert.ToString(ogrenci_result.lgsPuan) != "")
            {
                string lgsPuani = Convert.ToString(ogrenci_result.lgsPuan);
                txt_LgsPuanı.Text = lgsPuani;
            }
            txt_isim.Text = ismi;
            txt_soyisim.Text = soyismi;
            txt_sirano.Text = sira_nosu;
            txt_numara.Text = numarasi;
            txt_sınıf.Text = sinifi;
            txt_sube.Text = şubesi;
            txt_tcno.Text = tc_numarasi;
            txt_telno.Text = telefon_numarasi;
            txt_anneisim.Text = anne_ismi;
            txt_annetelno.Text = anne_telefon_numarsi;
            txt_annemeslek.Text = anne_mesleği;
            txt_babaisim.Text = baba_ismi;
            txt_babameslek.Text = baba_mesleği;
            txt_babatelno.Text = baba_telefon_numarasi;
            txt_hobiler.Text = hobileri;
            txt_yüzde.Text = yüzdeliği;
           
        }

        private void SearchOgrenciByNameAndSurname(IFirebaseClient client, String name, String surname)
        {
            fetchData(client);
            foreach(Ogrenci o in öğrenciler_list){
            if(name.ToLower().Equals(o.isim.ToLower()) && surname.ToLower().Equals(o.soyisim.ToLower())) {
                    string ismi = Convert.ToString(o.isim);
                    string soyismi = Convert.ToString(o.soyisim);
                    string numarasi = Convert.ToString(o.numara);
                    string sinifi = Convert.ToString(o.sınıf);
                    string şubesi = Convert.ToString(o.şube);
                    string yatililik_durumu = Convert.ToString(o.yatılılık);
                    if (o.yatılılık){ 
                        txt_yatılılık.Text = "1";
                    }else{
                        txt_yatılılık.Text = "0";
                    }
                    string tc_numarasi = Convert.ToString(o.tcno);
                    string telefon_numarasi = Convert.ToString(o.telno);
                    string anne_ismi = Convert.ToString(o.anneisim);
                    string anne_telefon_numarsi = Convert.ToString(o.annetelno);
                    string anne_mesleği = Convert.ToString(o.annemeslek);
                    string baba_ismi = Convert.ToString(o.babaisim);
                    string baba_mesleği = Convert.ToString(o.babameslek);
                    string baba_telefon_numarasi = Convert.ToString(o.babatelno);
                    string hobileri = Convert.ToString(o.hobi);
                    string sira_nosu = Convert.ToString(o.sirano);
                    string yüzdeliği = Convert.ToString(o.girişyüzdesi);
                    if (Convert.ToString(o.lgsPuan) != ""){
                        string lgsPuani = Convert.ToString(o.lgsPuan);
                        txt_LgsPuanı.Text = lgsPuani;
                    }
                    txt_isim.Text = ismi;
                    txt_soyisim.Text = soyismi;
                    txt_sirano.Text = sira_nosu;
                    txt_numara.Text = numarasi;
                    txt_sınıf.Text = sinifi;
                    txt_sube.Text = şubesi;
                    txt_tcno.Text = tc_numarasi;
                    txt_telno.Text = telefon_numarasi;
                    txt_anneisim.Text = anne_ismi;
                    txt_annetelno.Text = anne_telefon_numarsi;
                    txt_annemeslek.Text = anne_mesleği;
                    txt_babaisim.Text = baba_ismi;
                    txt_babameslek.Text = baba_mesleği;
                    txt_babatelno.Text = baba_telefon_numarasi;
                    txt_hobiler.Text = hobileri;
                    txt_yüzde.Text = yüzdeliği;
                }
            }
        }

        private void SearchOgrenciByNumber(IFirebaseClient client, String numara)
        {
            fetchData(client);
            foreach (Ogrenci o in öğrenciler_list)
            {
                if (numara.ToLower().Equals(Convert.ToString(o.numara).ToLower())){
                    string ismi = Convert.ToString(o.isim);
                    string soyismi = Convert.ToString(o.soyisim);
                    string numarasi = Convert.ToString(o.numara);
                    string sinifi = Convert.ToString(o.sınıf);
                    string şubesi = Convert.ToString(o.şube);
                    string yatililik_durumu = Convert.ToString(o.yatılılık);
                    if (o.yatılılık)
                    {
                        txt_yatılılık.Text = "1";
                    }
                    else
                    {
                        txt_yatılılık.Text = "0";
                    }
                    string tc_numarasi = Convert.ToString(o.tcno);
                    string telefon_numarasi = Convert.ToString(o.telno);
                    string anne_ismi = Convert.ToString(o.anneisim);
                    string anne_telefon_numarsi = Convert.ToString(o.annetelno);
                    string anne_mesleği = Convert.ToString(o.annemeslek);
                    string baba_ismi = Convert.ToString(o.babaisim);
                    string baba_mesleği = Convert.ToString(o.babameslek);
                    string baba_telefon_numarasi = Convert.ToString(o.babatelno);
                    string hobileri = Convert.ToString(o.hobi);
                    string sira_nosu = Convert.ToString(o.sirano);
                    string yüzdeliği = Convert.ToString(o.girişyüzdesi);
                    if (Convert.ToString(o.lgsPuan) != "")
                    {
                        string lgsPuani = Convert.ToString(o.lgsPuan);
                        txt_LgsPuanı.Text = lgsPuani;
                    }
                    txt_isim.Text = ismi;
                    txt_soyisim.Text = soyismi;
                    txt_sirano.Text = sira_nosu;
                    txt_numara.Text = numarasi;
                    txt_sınıf.Text = sinifi;
                    txt_sube.Text = şubesi;
                    txt_tcno.Text = tc_numarasi;
                    txt_telno.Text = telefon_numarasi;
                    txt_anneisim.Text = anne_ismi;
                    txt_annetelno.Text = anne_telefon_numarsi;
                    txt_annemeslek.Text = anne_mesleği;
                    txt_babaisim.Text = baba_ismi;
                    txt_babameslek.Text = baba_mesleği;
                    txt_babatelno.Text = baba_telefon_numarasi;
                    txt_hobiler.Text = hobileri;
                    txt_yüzde.Text = yüzdeliği;
                }
            }
        }

        private void InsertData_ogrenci(IFirebaseClient client)
        {
            int girilenSirano = Convert.ToInt32(txt_sirano.Text);
            int girilenNumara = Convert.ToInt32(txt_numara.Text);
            int girilenSınıf = Convert.ToInt32(txt_sınıf.Text);
            char girilenSube = Convert.ToChar(txt_sube.Text);
            long girilenTelno = Convert.ToInt64(txt_telno.Text);
            long girilenAnnetelno = Convert.ToInt64(txt_annetelno.Text);
            long girilenBabatelno = Convert.ToInt64(txt_babatelno.Text);
            float girilenLgsPuan = (float) Convert.ToDouble(txt_LgsPuanı.Text);
            double girilenYüzdelik = Convert.ToDouble(txt_yüzde.Text);
            long girilenNOno = Convert.ToInt64(txt_tcno.Text);

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

            //var result = client.Get("IndexCount");
            //int i = result.ResultAs<int>();

            // i++;

            // Ogrenci o = new Ogrenci(girilenSirano, txt_isim.Text, txt_soyisim.Text, girilenNumara, girilenSınıf, girilenSube, girilenYatılılık, girilenTelno, txt_anneisim.Text, txt_annemeslek.Text, txt_babaisim.Text, txt_babameslek.Text,girilenAnnetelno,girilenBabatelno);
            Ogrenci o2 = new Ogrenci(girilenSirano, txt_isim.Text, txt_soyisim.Text, girilenNumara, girilenSınıf, girilenSube, girilenYatılılık, girilenTelno, txt_anneisim.Text, txt_annemeslek.Text, girilenAnnetelno, girilenBabatelno, txt_hobiler.Text, girilenYüzdelik, girilenNOno, txt_babaisim.Text, txt_babameslek.Text, girilenLgsPuan);

            client.Set("StudentList/" + "Öğrenci" + girilenSirano, o2);
            client2.Set("StudentList/" + "Öğrenci" + girilenSirano, o2);
            fetchData(client);
            MessageBox.Show("data inserted successfully");
            // client.Update("IndexCount/", Convert.ToInt32(i));
            fetchData(client);
            temizle();
        }


        private void UpdateData_ogrenci(IFirebaseClient client)
        {
            int girilenSirano = Convert.ToInt32(txt_sirano.Text);
            int girilenNumara = Convert.ToInt32(txt_numara.Text);
            int girilenSınıf = Convert.ToInt32(txt_sınıf.Text);
            char girilenSube = Convert.ToChar(txt_sube.Text);
            long girilenTelno = Convert.ToInt64(txt_telno.Text);
            long girilenAnnetelno = Convert.ToInt64(txt_annetelno.Text);
            long girilenBabatelno = Convert.ToInt64(txt_babatelno.Text);
            double girilenLgsPuan = Convert.ToDouble(txt_LgsPuanı.Text);
            double girilenYüzdelik = Convert.ToDouble(txt_yüzde.Text);
            long girilenNOno = Convert.ToInt64(txt_tcno.Text);

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




            Ogrenci o2 = new Ogrenci(girilenSirano, txt_isim.Text, txt_soyisim.Text, girilenNumara, girilenSınıf, girilenSube, girilenYatılılık, girilenTelno, txt_anneisim.Text, txt_annemeslek.Text, girilenAnnetelno, girilenBabatelno, txt_hobiler.Text, girilenYüzdelik, girilenNOno, txt_babaisim.Text, txt_babameslek.Text, girilenLgsPuan);
            //Ogrenci o = new Ogrenci(girilenSirano, txt_isim.Text, txt_soyisim.Text, girilenNumara, girilenSınıf, girilenSube, girilenYatılılık, girilenTelno, txt_anneisim.Text, txt_annemeslek.Text, txt_babaisim.Text, txt_babameslek.Text,girilenAnnetelno,girilenBabatelno);
            client.Update("StudentList/" + "Öğrenci" + girilenSirano, o2);
            client2.Set("StudentList/" + "Öğrenci" + girilenSirano, o2);
            client2.Update("StudentList/" + "Öğrenci" + girilenSirano, o2);
            fetchData(client);
        }

        private void DeleteData_ogrenci(IFirebaseClient client)
        {
            int girilenSirano = Convert.ToInt32(txt_sirano.Text);


            client.Delete("StudentList/" + "Öğrenci" + girilenSirano);
            client2.Delete("StudentList/" + "Öğrenci" + girilenSirano);
            fetchData(client);
        }

        private void InsertData_öğretmen(IFirebaseClient client)
        {
            int girilenÖğretmenSirano = Convert.ToInt32(txt_ösirano.Text);
            int girilenÖğretmenDoğumTarihi = Convert.ToInt32(txt_ödoğumtarihi.Text);

            Öğretmen öğretmen = new Öğretmen(girilenÖğretmenSirano, txt_öisim.Text, txt_ösoyisim.Text, txt_ders.Text, girilenÖğretmenDoğumTarihi);

            client.Set("TeacherList/" + "Öğretmen" + girilenÖğretmenSirano, öğretmen);

            MessageBox.Show("Data inserted successfully", "Bilgilendirme");

            temizle();
        }
        private void UpdateData_öğretmen(IFirebaseClient client)
        {
            int girilenÖğretmenSirano = Convert.ToInt32(txt_ösirano.Text);
            int girilenÖğretmenDoğumTarihi = Convert.ToInt32(txt_ödoğumtarihi.Text);


            Öğretmen öğretmen = new Öğretmen(girilenÖğretmenSirano, txt_öisim.Text, txt_ösoyisim.Text, txt_ders.Text, girilenÖğretmenDoğumTarihi);
            client.Update("TeacherList/" + "Öğretmen" + girilenÖğretmenSirano, öğretmen);
        }

        private void DeleteData_öğretmen(IFirebaseClient client)
        {
            int girilenÖğretmenSirano = Convert.ToInt32(txt_ösirano.Text);

            client.Delete("TeacherList/" + "Öğretmen" + girilenÖğretmenSirano);
        }

        private void InsertData_idare(IFirebaseClient client)
        {
            int girilenİdareSirano = Convert.ToInt32(txt_idaresirano.Text);
            int girilenİdareDoğumTarihi = Convert.ToInt32(txt_idaredogtar.Text);

            İdare idare = new İdare(girilenİdareSirano, txt_idareisim.Text, txt_idaresoyisim.Text, txt_görev.Text,girilenİdareDoğumTarihi);

            client.Set("AdministrationList/" + "İdareci" + girilenİdareSirano, idare);

            MessageBox.Show("Data inserted successfully;", "Bilgilendirme");

            temizle();
        }
        private void UpdateData_idare(IFirebaseClient client)
        {
            int girilenİdareSirano = Convert.ToInt32(txt_idaresirano.Text);
            int girilenİdareDoğumTarihi = Convert.ToInt32(txt_idaredogtar.Text);

            İdare idare = new İdare(girilenİdareSirano, txt_idareisim.Text, txt_idaresoyisim.Text, txt_görev.Text, girilenİdareDoğumTarihi);

            client.Update("AdministrationList/" + "İdareci" + girilenİdareSirano, idare);
            client2.Set("AdministrationList/" + "İdareci" + girilenİdareSirano, idare);
            client2.Update("AdministrationList/" + "İdareci" + girilenİdareSirano, idare);
        }

        private void DeleteData_idare(IFirebaseClient client)
        {
            int girilenİdareSirano = Convert.ToInt32(txt_idaresirano.Text);

            client.Delete("AdministrationList/" + "İdareci" + girilenİdareSirano);
            client2.Delete("AdministrationList/" + "İdareci" + girilenİdareSirano);
        }
        private void fetchData(IFirebaseClient client){
            int count = 0;
            FirebaseResponse res = client.Get(@"StudentList");
            Dictionary<string, Ogrenci> data = JsonConvert.DeserializeObject<Dictionary<string, Ogrenci>>(res.Body.ToString());
            öğrenciler_list = new List<Ogrenci>(data.Values);
            foreach (Ogrenci og in öğrenciler_list){
                count++;
               
                //    MessageBox.Show("oldu aldik" +"  "+ og.sirano+" "+og.isim+" "+öğrenciler_list.Count+" "+count);

            }
            client.Set(@"IndexCount", count);
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void searchStudentByName(IFirebaseClient client)
        {
            fetchData(client);
          
            foreach (Ogrenci og in öğrenciler_list)
            {
                string girilenİsim = txt_isimleara.Text;
                bool kontrol = false;

                kontrol = og.isim.ToLower().Contains(girilenİsim.ToLower());

             

                if (kontrol)
                {
                    dataGridView1.Rows.Add(og.isim, og.soyisim, og.sınıf + "/" + og.şube, og.numara, og.yatılılık, og.telno, og.anneisim, og.babaisim, og.girişyüzdesi);
                }


            }
        

        }

      


        private void searchStudentBySurname(IFirebaseClient client)
        {
            string girilenSoyisim = txt_soyisimleara.Text;

            fetchData(client);
            foreach(Ogrenci og in öğrenciler_list)
            {
                if(og.soyisim.ToLower().Equals(girilenSoyisim.ToLower()))
                {
                    dataGridView1.Rows.Add(og.isim, og.soyisim, og.sınıf + "/" + og.şube, og.numara, og.yatılılık, og.telno, og.anneisim, og.babaisim, og.girişyüzdesi);
                }
            }
        }

        private void btn_isimleara_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            searchStudentByName(client);
        }

        private void btn_soyisimleara_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            searchStudentBySurname(client);
            
        }
    }
}
