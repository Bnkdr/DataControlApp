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
        Dictionary<string, bool> changed_list = new Dictionary<string, bool>();
        private void Form1_Load(object sender, EventArgs e)
        {
            try{
                client = new FirebaseClient(ifc);
                client2 = new FirebaseClient(ifc2);

            }
            catch{
                MessageBox.Show("there was a problem in your internet");
            }

            string directory = "2022-2023";
            fetchData(client,directory);
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
                if (comboBox_dir.SelectedItem != null)
                {
                    string directory = comboBox_dir.SelectedItem.ToString();
                    SearchOgrenciById(client, txt_sirano.Text,directory);
                }
                else
                {
                    MessageBox.Show("Lütfen yıl seçimi yapınız.");
                }
                
            }else if(txt_isim.Text !="" && txt_soyisim.Text != ""){
                if (comboBox_dir.SelectedItem != null)
                {
                    string directory = comboBox_dir.SelectedItem.ToString();
                    if (txt_isim.Text != null&&txt_soyisim.Text!=null)
                    {
                        SearchOgrenciByNameAndSurname(client, txt_isim.Text.ToLower(), txt_soyisim.Text.ToLower(), directory);
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Eksik isim veya soyismi giriniz");
                    }

                    
                }
                else
                {
                    MessageBox.Show("Lütfen yıl seçimi yapınız.");
                }

            }
            else if(txt_numara.Text != ""){
                if (comboBox_dir.SelectedItem != null)
                {
                    string directory = comboBox_dir.SelectedItem.ToString();
                    SearchOgrenciByNumber(client, txt_numara.Text.ToLower(),directory);
                }
                else
                {
                    MessageBox.Show("Lütfen yıl seçimini yapınız");
                }
            }
            else
            {
                MessageBox.Show("Lütfen arama kriterlerinden birini giriniz.(Sıra Numarası, Okul Numarası, İsim-Soyisim)");
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
            txt_memleket.Text = string.Empty;
            txt_yerlestigiYer.Text = string.Empty;
            txt_siralama.Text = string.Empty;
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

        private void SearchOgrenciById(IFirebaseClient client, String sira,string directory){
            fetchData(client, directory);
            FirebaseResponse result = client.Get(@"StudentList/"+directory+"/"+"Öğrenci" + sira);
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
            string yanlisSorusu = ogrenci_result.yanlisSoru.ToString();
            string bursu = ogrenci_result.burs.ToString();
            string bosSorusu = ogrenci_result.bosSoru.ToString();
            string oBeklentisi = ogrenci_result.oBeklenti;
            string DogumGunu = ogrenci_result.DogumGunu;
            string cinsiyet = ogrenci_result.cinsiyet;
            string memleket = ogrenci_result.memleket;
            string yerlestigiYer = ogrenci_result.yerlestigiYer;
            string siralama = ogrenci_result.siralama;
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
            txt_yanlisSoru.Text = yanlisSorusu;
            txt_burs.Text = bursu;
            txt_bosSoru.Text = bosSorusu;
            txt_oBeklenti.Text = oBeklentisi;
            txt_dogumGunu.Text = DogumGunu;
            txt_cinsiyet.Text = cinsiyet;
            txt_memleket.Text = memleket;
            txt_yerlestigiYer.Text = yerlestigiYer;
            txt_siralama.Text = siralama;
           
        }

        private void SearchOgrenciByNameAndSurname(IFirebaseClient client, String name, String surname,string directory)
        {
            fetchData(client,directory);
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
                    string yanlisSorusu = o.yanlisSoru.ToString();
                    string bursu = o.burs.ToString();
                    string bosSorusu = o.bosSoru.ToString();
                    string oBeklentisi = o.oBeklenti;
                    string DogumGunu = o.DogumGunu;
                    string cinsiyet = o.cinsiyet;
                    string memleket = o.memleket;
                    string yerlestigiYer = o.yerlestigiYer;
                    string siralama = o.siralama;
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
                    txt_yanlisSoru.Text = yanlisSorusu;
                    txt_burs.Text = bursu;
                    txt_bosSoru.Text = bosSorusu;
                    txt_oBeklenti.Text = oBeklentisi;
                    txt_dogumGunu.Text = DogumGunu;
                    txt_cinsiyet.Text = cinsiyet;
                    txt_memleket.Text = memleket;
                    txt_yerlestigiYer.Text = yerlestigiYer;
                    txt_siralama.Text = siralama;
                }
            }
        }

        private void SearchOgrenciByNumber(IFirebaseClient client, String numara,string directory)
        {
            fetchData(client,directory);
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
                    string yanlisSorusu = o.yanlisSoru.ToString();
                    string bursu =o.burs.ToString();
                    string bosSorusu = o.bosSoru.ToString();
                    string oBeklentisi = o.oBeklenti;
                    string DogumGunu = o.DogumGunu;
                    string cinsiyet = o.cinsiyet;
                    string memleket = o.memleket;
                    string yerlestigiYer = o.yerlestigiYer;
                    string siralama = o.siralama;
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
                    txt_yanlisSoru.Text = yanlisSorusu;
                    txt_burs.Text = bursu;
                    txt_bosSoru.Text = bosSorusu;
                    txt_oBeklenti.Text = oBeklentisi;
                    txt_dogumGunu.Text = DogumGunu;
                    txt_cinsiyet.Text = cinsiyet;
                    txt_memleket.Text = memleket;
                    txt_yerlestigiYer.Text = yerlestigiYer;
                    txt_siralama.Text = siralama;
                }
            }
        }

        private bool boolTostring(string variable,bool result)
        {
            if (variable.ToLower() == "1")
            {
                result = true;
                return result;
            }
            else if (variable.ToLower() == "0")
            {
                result = false;
                return result;
            }
            else
            {
                MessageBox.Show($"Hatalı {variable} Bilgisi", "Hata");
                return result;
            }
           
        }
        bool mezun = false;
        bool siralama_bool = false;
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
            int yanlisSoru = Convert.ToInt32(txt_yanlisSoru.Text);
            int bosSoru = Convert.ToInt32(txt_bosSoru.Text);


            bool girilenYatılılık = false;
            girilenYatılılık =boolTostring(txt_yatılılık.Text, girilenYatılılık);
            bool burs = false;
            burs=boolTostring(txt_burs.Text, burs);



            string yerlesme = "Not graduated";
            string siralama = "Not graduated";

            if (checkBox_mezun.Checked == true)
            {
                yerlesme = txt_yerlestigiYer.Text.ToLower();
                siralama = txt_siralama.Text;
                mezun = true;
            }


            if(mezun!=true)
            {
                yerlesme = "Not graduated";
                siralama = "Not graduated";
            }
            if (comboBox_dir.SelectedItem != null)
            {

                string directory = comboBox_dir.SelectedItem.ToString();
                Ogrenci o2 = new Ogrenci(girilenSirano, txt_isim.Text.ToLower(), txt_soyisim.Text.ToLower(), girilenNumara, girilenSınıf, girilenSube, girilenYatılılık, girilenTelno, txt_anneisim.Text.ToLower(), txt_annemeslek.Text.ToLower(), girilenAnnetelno, girilenBabatelno, txt_hobiler.Text.ToLower(), girilenYüzdelik, girilenNOno, txt_babaisim.Text.ToLower(), txt_babameslek.Text.ToLower(), girilenLgsPuan, yanlisSoru, burs, bosSoru, txt_oBeklenti.Text.ToLower(), txt_dogumGunu.Text.ToLower(), txt_cinsiyet.Text.ToLower(), txt_memleket.Text.ToLower(), yerlesme, siralama);

                client.Set($"StudentList/{directory}/" + "Öğrenci" + txt_sirano.Text, o2);
                client2.Set($"StudentList/{directory}/" + "Öğrenci" + txt_sirano.Text, o2);

                MessageBox.Show("data inserted successfully");
                fetchData(client, directory);
            }
            else
            {
                MessageBox.Show("Lütfen yıl seçimi yapınız.");
            }

           
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
            int yanlisSoru = Convert.ToInt32(txt_yanlisSoru.Text);
            int bosSoru = Convert.ToInt32(txt_bosSoru.Text);


            bool girilenYatılılık = false;
            girilenYatılılık = boolTostring(txt_yatılılık.Text, girilenYatılılık);
            bool burs = false;
            burs = boolTostring(txt_burs.Text, burs);



            string yerlesme = "Not graduated";
            string siralama = "Not graduated";

            if (checkBox_mezun.Checked == true)
            {
                yerlesme = txt_yerlestigiYer.Text.ToLower();
                siralama = txt_siralama.Text;
                mezun = true;
            }
            if (mezun != true)
            {
                yerlesme = "Not graduated";
                siralama = "Not graduated";
            }

            if (comboBox_dir.SelectedItem != null)
            {
                string directory = comboBox_dir.SelectedItem.ToString();



                Ogrenci o2 = new Ogrenci(girilenSirano, txt_isim.Text.ToLower(), txt_soyisim.Text.ToLower(), girilenNumara, girilenSınıf, girilenSube, girilenYatılılık, girilenTelno, txt_anneisim.Text.ToLower(), txt_annemeslek.Text.ToLower(), girilenAnnetelno, girilenBabatelno, txt_hobiler.Text.ToLower(), girilenYüzdelik, girilenNOno, txt_babaisim.Text.ToLower(), txt_babameslek.Text.ToLower(), girilenLgsPuan, yanlisSoru, burs, bosSoru, txt_oBeklenti.Text.ToLower(), txt_dogumGunu.Text.ToLower(), txt_cinsiyet.Text.ToLower(), txt_memleket.Text.ToLower(), yerlesme, siralama);

                //Ogrenci o = new Ogrenci(girilenSirano, txt_isim.Text, txt_soyisim.Text, girilenNumara, girilenSınıf, girilenSube, girilenYatılılık, girilenTelno, txt_anneisim.Text, txt_annemeslek.Text, txt_babaisim.Text, txt_babameslek.Text,girilenAnnetelno,girilenBabatelno);
                client.Update($"StudentList/{directory}/" + "Öğrenci" + txt_sirano.Text, o2);
                client2.Set($"StudentList/{directory}/" + "Öğrenci" + txt_sirano.Text, o2);
                client2.Update($"StudentList/{directory}/" + "Öğrenci" + txt_sirano.Text, o2);
                fetchData(client, directory);
            }
            else
            {
                MessageBox.Show("Lütfen arama yılını giriniz");
            }
            
        }

        private void DeleteData_ogrenci(IFirebaseClient client)
        {
            if (comboBox_dir.SelectedItem != null)
            {

                string directory = comboBox_dir.SelectedItem.ToString();
                client.Delete($"StudentList/{directory}/" + "Öğrenci" + txt_sirano.Text);
                client2.Delete($"StudentList/{directory}/" + "Öğrenci" + txt_sirano.Text);

                fetchData(client, directory);

            }
            else
            {
                MessageBox.Show("Lütfen yıl seçimi yapınız.");
            }

          
            
        }

        private void InsertData_öğretmen(IFirebaseClient client)
        {
            int girilenÖğretmenSirano = Convert.ToInt32(txt_ösirano.Text);
            int girilenÖğretmenDoğumTarihi = Convert.ToInt32(txt_ödoğumtarihi.Text);

            Öğretmen öğretmen = new Öğretmen(girilenÖğretmenSirano, txt_öisim.Text, txt_ösoyisim.Text, txt_ders.Text, girilenÖğretmenDoğumTarihi);

            client.Set("TeacherList/" + "Öğretmen" + girilenÖğretmenSirano, öğretmen);

            MessageBox.Show("Data inserted successfully", "Bilgilendirme");


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
        private void fetchData(IFirebaseClient client,string directory){
            int count = 0;

            FirebaseResponse res = client.Get(@"StudentList/"+directory);
            Dictionary<string, Ogrenci> data = JsonConvert.DeserializeObject<Dictionary<string, Ogrenci>>(res.Body.ToString());
            if (data == null)
            {
                MessageBox.Show("Seçtiğiniz yılda girilmiş öğrenci verisi bulunmamaktadır");
                öğrenciler_list =new List<Ogrenci>();
            }
            else
            {
                öğrenciler_list = new List<Ogrenci>(data.Values);
                foreach (Ogrenci og in öğrenciler_list)
                {
                    count++;

                    //    MessageBox.Show("oldu aldik" +"  "+ og.sirano+" "+og.isim+" "+öğrenciler_list.Count+" "+count);

                }
                client.Set(@"IndexCount", count);
            }
            
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void searchStudentByName(IFirebaseClient client,string directory)
        {

            fetchData(client,directory);
          
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

      


        private void searchStudentBySurname(IFirebaseClient client,string directory)
        {
            string girilenSoyisim = txt_soyisimleara.Text;


            fetchData(client,directory);
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
            if (cmbox_aramayil.SelectedItem != null)
            {
                string directory = cmbox_aramayil.SelectedItem.ToString();
                fetchData(client, directory);
                searchStudentByName(client, directory);
            }
            else
            {
                MessageBox.Show("Lütfen arayacağınız yılları seçiniz.");
            }
            

        }

        private void btn_soyisimleara_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (cmbox_aramayil.SelectedItem != null)
            {
                string directory = cmbox_aramayil.SelectedItem.ToString();
                fetchData(client, directory);
                searchStudentBySurname(client, directory);
            }
            else
            {
                MessageBox.Show("Lütfen arayacağınız yılları seçiniz.");
            }
           
            
            
        }

        private void rd_btn_mezun_CheckedChanged(object sender, EventArgs e)
        {
            
            txt_yerlestigiYer.Visible = true;
            lbl_yerlestigiYer.Visible = true;
            txt_siralama.Visible = true;
            lbl_siralama.Visible = true;
        }

        private void checkBox_mezun_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_mezun.Checked == true)
            {
                txt_yerlestigiYer.Visible = true;
                lbl_yerlestigiYer.Visible = true;
                txt_siralama.Visible = true;
                lbl_siralama.Visible = true;
            }
            else
            {
                txt_yerlestigiYer.Visible = false;
                lbl_yerlestigiYer.Visible = false;
                txt_siralama.Visible = false;
                lbl_siralama.Visible = false;
            }
        }
        List<Ogrenci> filter = new List<Ogrenci>();
       

        private void btn_topluara_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (cmbox_aramayil.SelectedItem != null)
            {
                string directory = cmbox_aramayil.SelectedItem.ToString();
                fetchData(client, directory);
                if (filter.Count != 0)
                {
                    filter=new List<Ogrenci>();
                }


                SearchStudentFiltered();
            }
            else
            {
                MessageBox.Show("Lütfen arayacağınız yılları seçiniz.");
            }

           

        }

        async void SearchStudentFiltered()
        {
           

            if (txt_isimleara.Text!=string.Empty)
            {
                for(int i=0;i<öğrenciler_list.Count;i++)
                {
                    if (öğrenciler_list[i].isim.ToLower().Contains(txt_isimleara.Text.ToLower()))
                    {
                        filter.Add(öğrenciler_list[i]);
                    }
                }
            }
            if (txt_soyisimleara.Text!=string.Empty)
            {
                if (filter.Count==0)
                {
                    for(int i=0;i<öğrenciler_list.Count;i++)
                    {
                        if (öğrenciler_list[i].soyisim.ToLower()==txt_soyisimleara.Text.ToLower())
                        {
                            filter.Add(öğrenciler_list[i]);
                        }
                    }
                }
                else
                {
                    for (int i=0;i<filter.Count;i++)
                    {
                        if (filter[i].soyisim!=txt_soyisimleara.Text.ToLower())
                        {
                            filter.Remove(filter[i]);

                            if (i != 0)
                            {
                                i--;
                            }
                        }
                    }
                }

            }
            if (txt_toptelno.Text!=string.Empty)
            {
                if (filter.Count == 0)
                {
                    for(int i=0;i<öğrenciler_list.Count; i++)
                    {
                        if (öğrenciler_list[i].telno.ToString()==txt_toptelno.Text)
                        {
                            filter.Add(öğrenciler_list[i]);
                        }
                    }
                }
                else
                {

                    for (int i=0;i<filter.Count;i++)
                    {
                        if (filter[i].telno.ToString()!=txt_toptelno.Text)
                        {
                            filter.Remove(filter[i]);

                            if (i != 0)
                            {
                                i--;
                            }
                        }
                    }
                }

            }
            if (txt_topdogtar.Text!=string.Empty)
            {
                if (filter.Count == 0)
                {
                    for(int i=0;i<öğrenciler_list.Count;i++)
                    {
                        if (öğrenciler_list[i].DogumGunu.Contains(txt_topdogtar.Text))
                        {
                            filter.Add(öğrenciler_list[i]);
                        }
                    }
                }
                else
                {
                    for (int i=0;i<filter.Count;i++)
                    {
                        if (!filter[i].DogumGunu.Contains(txt_topdogtar.Text))
                        {

                            filter.Remove(filter[i]);

                            if (i != 0)
                            {
                                i--;
                            }
                        }
                    }
                }

            }
            if (txt_topsınıf.Text!=string.Empty)
            {
                if (filter.Count ==0)
                {
                    for(int i=0;i<öğrenciler_list.Count;i++)
                    {
                        if (öğrenciler_list[i].sınıf.ToString()==txt_topsınıf.Text.ToLower())
                        {
                            filter.Add(öğrenciler_list[i]);
                        }
                    }
                }
                else
                {
                    for(int i=0;i<filter.Count;i++)
                    {
                        if (filter[i].sınıf.ToString()!=txt_topsınıf.Text)
                        {
                            
                            filter.Remove(filter[i]);

                            if (i != 0)
                            {
                                i--;
                            }

                        }
                    }
                }

            }
            if (txt_topşube.Text!=string.Empty)
            {
                if (filter.Count == 0)
                {
                    for(int i=0;i<öğrenciler_list.Count;i++)
                    {
                        if (öğrenciler_list[i].şube.ToString()==txt_topşube.Text.ToUpper())
                        {
                            filter.Add(öğrenciler_list[i]);
                        }
                    }
                }
                else
                {

                    for (int i=0;i<filter.Count;i++)
                    {
                        if (filter[i].şube.ToString()!=txt_topşube.Text.ToUpper())
                        {
                            filter.Remove(filter[i]);

                            if (i != 0)
                            {
                                i-=2;
                            }
                        }
                    }
                }

            }
            if (checkbox_yatililik.Checked)
            {
                if (filter.Count == 0)
                {
                    for(int i = 0; i < öğrenciler_list.Count;i++)
                    {
                        if (öğrenciler_list[i].yatılılık == true)
                        {
                            filter.Add(öğrenciler_list[i]);
                        }
                    }
                }
                else
                {

                    for (int i=0;i<filter.Count;i++)
                    {
                        if (filter[i].yatılılık == false)
                        {
                            filter.Remove(filter[i]);

                            if (i != 0)
                            {
                                i--;
                            }
                        }
                    }
                }

            }

            foreach (Ogrenci og in filter)
            {
                dataGridView1.Rows.Add(og.isim, og.soyisim, og.sirano, og.sınıf + "/" + og.şube, og.numara, og.yatılılık, og.telno, og.DogumGunu, og.girişyüzdesi);
            }
        }




        private void txt_isimleara_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_soyisimleara_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_toptelno_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_topdogtar_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txt_topsınıf_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_topşube_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void checkbox_yatililik_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
