using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }
        [Column(TypeName ="VarChar")]
        [StringLength(400)]
        public string PersonelAdres { get; set; }
        [Column(TypeName ="VarChar")]
        [StringLength(400)]
        public string PersonelAciklama { get; set; }
        [Column(TypeName ="VarChar")]
        [StringLength(15)]
        public string PersonelTelefon { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }

        public ICollection<SatisHaraket> SatisHarakets { get; set; }
        public int Departmanid { get; set; }

        public virtual Departman Departman { get; set; }
    }
}