using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionJDR.Data
{
    public class Personnage
    {
        //Informations générales
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonnageID { get; set; }

        [Required]
        [Display(Name = "Nom du Joueur")]
        public string PlayerName { get; set; }

        [Required]
        [Display(Name = "Nom du Personnage")]
        public string CharacterName { get; set; }
        
        [Required]
        [Display(Name = "Métier")]
        public string Profession { get; set; }
        
        [Required]
        [Display(Name = "Vitalité")]
        public int Vitality { get; set; }
        
        [Required]
        [Display(Name = "Folie")]
        public int Madness { get; set; }

        //Attributs d'Actions
        [Display(Name = "Combat")]
        public int Combat { get; set; }

        [Display(Name = "Magie")]
        public int Magic { get; set; }

        [Display(Name = "Analyse")]
        public int Analysis { get; set; }
        [Display(Name = "Survie")]
        public int Survival { get; set; }

        [Display(Name = "Urgence")]
        public int Emergency { get; set; }

        [Display(Name = "Artisanat")]
        public int Craft { get; set; }

        [Display(Name = "Débrouillardise")]
        public int Resourcefulness { get; set; }

        //Attributs Passifs
        [Required]
        [Display(Name = "Force")]
        public int Strenght { get; set; }

        [Required]
        [Display(Name = "Endurance")]
        public int Endurance { get; set; }

        [Required]
        [Display(Name = "Dextérité")]
        public int Dexterity { get; set; }

        [Required]
        [Display(Name = "Vitesse")]
        public int Speed { get; set; }

        [Required]
        [Display(Name = "Perception")]
        public int Perception { get; set; }

        [Required]
        [Display(Name = "Intelligence")]
        public int Intelligence { get; set; }

        [Required]
        [Display(Name = "Volonté")]
        public int Will { get; set; }

        //Protection
        [Display(Name = "Protection Physique")]
        public int PhysicalProtection { get; set; }
        [Display(Name = "Protection Magique")]
        public int MagicalProtection { get; set; }

        //Compétences
        [Display(Name = "Compétence")]
        public string CompetenceName { get; set; }
        [Display(Name = "Effet")]
        public string CompetenceEffect { get; set; }

        //Armes
        [Display(Name = "Arme")]
        public string WeaponName { get; set; }
        [Display(Name = "Effet")]
        public string WeaponEffect { get; set; }
        [Display(Name = "Description")]
        public string WeaponDescription { get; set; }

        //Armures
        [Display(Name = "Armure")]
        public string ArmorName { get; set; }
        [Display(Name = "Effet")]
        public string ArmorEffect { get; set; }
        [Display(Name = "Description")]
        public string ArmorDescription { get; set; }

        //Objets
        [Display(Name = "Objet")]
        public string ObjectName { get; set; }
        [Display(Name = "Effet")]
        public string ObjectEffect { get; set; }
        [Display(Name = "Description")]
        public string ObjectDescription { get; set; }

        //Gemmes
        [Display(Name = "Gemme")]
        public string GemName { get; set; }
        [Display(Name = "Elément")]
        public string GemElement { get; set; }
        [Display(Name = "Carats")]
        public int GemCarats { get; set; }
        [Display(Name = "Aspect")]
        public string GemAspect { get; set; }

        //Notes
        [Display(Name = "Notes")]
        public string Note { get; set; }

        //Lore
        [Display(Name = "Lore")]
        public string Lore { get; set; }


        public ICollection<Possede> Possedent { get; set; }

    }
}
