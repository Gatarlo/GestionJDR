using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionJDR.Data
{
    public class Joueur
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string PlayerName { get; set; }

        [Required]
        [Display(Name = "Nom de Famille")]
        public string FamilyName { get; set; }

        [Display(Name = "Âge")]
        public int Age { get; set; }

        [Display(Name = "Ville")]
        public string City { get; set; }

        [Display(Name = "Jeux joués")]
        public string Jdr { get; set; }


        public ICollection<Possede> Possedent { get; set; }
    }
}
