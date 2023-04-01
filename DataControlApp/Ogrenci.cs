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
        public int sirano { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public int numara { get; set; }
        public int sınıf { get; set; } 
        public char şube { get; set; }
        public bool yatılılık { get; set; }
        public long telno { get; set; }
        public string veliisim { get; set; }
        public string velimeslek { get; set; }
        public long annetelno { get; set; }
        public long babatelno { get; set; }
        public string hobi { get; set; }
        public double girişyüzdesi { get; set; }
        public long tcno { get; set; }

        public Ogrenci()
        {
        }

        public Ogrenci(int sirano, string isim, string soyisim, int numara, int sınıf, char şube, bool yatılılık)
        {
            this.sirano = sirano;
            this.isim = isim;
            this.soyisim = soyisim;
            this.numara = numara;
            this.sınıf = sınıf;
            this.şube = şube;
            this.yatılılık = yatılılık;
        }

        public Ogrenci(int sirano, string isim, string soyisim, int numara, int sınıf, char şube, bool yatılılık, long telno, string veliisim, string velimeslek, long annetelno,long babatelno, string hobi, double girişyüzdesi,long tcno)
        {
            this.sirano = sirano;
            this.isim = isim;
            this.soyisim = soyisim;
            this.numara = numara;
            this.sınıf = sınıf;
            this.şube = şube;
            this.yatılılık = yatılılık;
            this.telno = telno;
            this.veliisim = veliisim;
            this.velimeslek = velimeslek;
            this.annetelno = annetelno;
            this.babatelno = babatelno;
            this.hobi = hobi;
            this.girişyüzdesi = girişyüzdesi;
            this.tcno=tcno;
        }



        /* public Ogrenci(string isim, string soyisim, int numara, int sınıf, char şube, bool yatılılık)
         {
             this.isim = isim;
             this.soyisim = soyisim;
             this.numara = numara;
             this.sınıf = sınıf;
             this.şube = şube;
             this.yatılılık = yatılılık;
         }

         public void setSirano(int sirano)
         {
             this.sirano = sirano;
         }*/


    }
}
