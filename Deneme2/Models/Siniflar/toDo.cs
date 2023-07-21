using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class toDo
    {

        [Key]
        public int todoid { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string baslik { get; set; }
        [Column(TypeName = "bit")]
        public bool durum { get; set; }
       
    }
}