using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionJDR.Data
{
    public class Possede
    {
        public int PossedeID { get; set; }
        public int JoueurID { get; set; }
        public int PersonnageID { get; set; }

        public Joueur Joueur{ get; set; }
        public Personnage Personnage { get; set; }
    }
}
