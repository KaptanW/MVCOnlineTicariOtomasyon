using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHaraket
    {
        [Key]
        public int SatisId { get; set; }
        //ürün
        //cari
        //personel
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get;set; }

        public Urun Urun { get; set; }

        public Cariler Cariler { get; set; }

        public Personel Personel { get; set; }

    }
}