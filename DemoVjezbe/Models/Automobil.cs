using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoVjezbe.Models
{
    public class Automobil
    {
        public int Id { get; set; }
        [Display (Name = "Naziv modela")]
        [Required(ErrorMessage ="Ovo polje je obavezno za unos")]
        public string NazivModela { get; set; }
        [Display(Name = "Godina proizvodnje")]
        public int GodinaProizvodnje { get; set; }
        [Display(Name = "Proizvođač")]
        public int ProizvodjacId { get; set; }
        public string VrstaGoriva { get; set; }
        public virtual Proizvodjac Proizvodjac { get; set; }
    }
}

