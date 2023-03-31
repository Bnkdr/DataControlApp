using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataControlApp
{
   public class Öğretmen
    {
        public int öğretmensirano { get; set; }
        public string öğretmenisim { get; set; }
        public string öğretmensoyisim { get; set; }
        public string öğretmenders { get; set; }
        public int öğretmendoğumtarihi { get; set; }


        public Öğretmen()
        {

        }

        public Öğretmen(int öğretmensirano, string öğretmenisim, string öğretmensoyisim, string öğretmenders,int öğretmendoğumtarihi)
        {
            this.öğretmensirano = öğretmensirano;
            this.öğretmenisim = öğretmenisim;
            this.öğretmensoyisim = öğretmensoyisim;
            this.öğretmenders = öğretmenders;
            this.öğretmendoğumtarihi = öğretmendoğumtarihi;
        }
    }
}
