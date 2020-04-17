using DemoVjezbe.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoVjezbe.Controllers
{
    public class AutomobilProizvodjacViewModel
    {
        public List<Automobil> Automobili { get; set; }
        public SelectList Proizvodjaci { get; set; }
        public string NazivProizvodjaca { get; set; }
        public string Upit { get; set; }
    }
}
