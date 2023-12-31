﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30, ErrorMessage = "30 Karakteri Aşamazsınız.")]
        public string CariAd { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30, ErrorMessage = "30 Karakteri Aşamazsınız.")]
        public string CariSoyad { get; set; }
        public string CariUnvan { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(13)]
        public string CariSehir { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string CariMail { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string CariSifre { get; set; }

        public bool Durum { get; set; }
        public ICollection<SatisHaraket> SatisHarakets { get; set; }
    }
}