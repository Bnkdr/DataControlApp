using System;
using System.Collections.Generic;
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
