using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string KullaniciAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Sifre { get;set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        string yetki { get; set; }
    }
}