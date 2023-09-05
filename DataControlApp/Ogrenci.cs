using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
using System.Text;
using System.Threading.Tasks;

namespace DataControlApp
{
    internal class Ogrenci
    {
        public string anneisim { get; set; }
        public string annemeslek { get; set; }
        public int sirano { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public int numara { get; set; }
        public int sınıf { get; set; } 
        public char şube { get; set; }
        public bool yatılılık { get; set; }
        public long telno { get; set; }
        public string babaisim { get; set; }
        public string babameslek { get; set; }
        public long annetelno { get; set; }
        public long babatelno { get; set; }
        public string hobi { get; set; }
        public double girişyüzdesi { get; set; }
        public long tcno { get; set; }
        public double lgsPuan { get; set; }
        public int yanlisSoru { get; set; }
        public bool burs { get; set; }
        public int bosSoru { get; set; }
        public string oBeklenti { get; set; }
        public string DogumGunu { get; set; }
        public string cinsiyet { get; set; }
        public string memleket { get; set; }
        public string yerlestigiYer { get; set; }
        public string siralama { get; set; }

        public Ogrenci()
        {
        }

        public Ogrenci(int sirano, string isim, string soyisim, int numara, int sınıf, char şube, bool yatılılık, long telno, string anneisim, string annemeslek, long annetelno, long babatelno, string hobi, double girişyüzdesi, long tcno, string babaisim, string babameslek, double lgsPuan,int yanlisSoru,bool burs, int bosSoru, string oBeklenti, string dogumGunu, string cinsiyet, string memleket,string yerlestigiYer,string siralama)
        {
            this.sirano = sirano;
            this.isim = isim;
            this.soyisim = soyisim;
            this.numara = numara;
            this.sınıf = sınıf;
            this.şube = şube;
            this.yatılılık = yatılılık;
            this.telno = telno;
            this.anneisim = anneisim;
            this.annemeslek = annemeslek;
            this.annetelno = annetelno;
            this.babatelno = babatelno;
            this.hobi = hobi;
            this.girişyüzdesi = girişyüzdesi;
            this.tcno = tcno;
            this.babaisim = babaisim;
            this.babameslek = babameslek;
            this.lgsPuan = lgsPuan;
            this.yanlisSoru = yanlisSoru;
            this.burs = burs;
            this.bosSoru = bosSoru;
            this.oBeklenti = oBeklenti;
            this.DogumGunu = dogumGunu;
            this.cinsiyet = cinsiyet;
            this.memleket = memleket;
            this.yerlestigiYer = yerlestigiYer;
            this.siralama = siralama;
        }



    }
}
