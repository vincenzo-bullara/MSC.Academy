using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Day4
{
    public enum Materia { Italiano, Matematica, Storia, Geografia, Arte}
    public class Voto
    {
        public int ID { get; set; }
        public Materia materia { get; set; }
        public DateTime Data { get; set; }
        public string IdStudente { get; set; }
        public decimal Valutazione { get; set; }
    }
}
