using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class Ders
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Adi { get; set; }
        public int Saati { get; set; }
        [StringLength(50)]
        public string Ogretmeni { get; set; }
        public bool Onay { get; set; }
        [StringLength(50)]
        public string? Tur { get; set; }
        public DateTime? Tarih { get; set; }
    }
}
