using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionJDR.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GestionJDRContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Joueurs.Any())
            {
                return;   // DB has been seeded
            }

            var joueurs = new Joueur[]
            {
                new Joueur { ID=1, PlayerName = "Pierre", FamilyName = "Granier", Age = 19, City = "Roujan", Jdr = "Mon JdR / Cthulhu / Naheulbeuk" },
                new Joueur { ID=2, PlayerName = "Vincent ", FamilyName = "Platet", Age = 19, City = "Béziers", Jdr = "Mon JdR" },
                new Joueur { ID=3, PlayerName = "Jenna", FamilyName = "Marty", Age = 32, City = "Chennevières-sur-Marne", Jdr = "Mon JdR" }
            };

            context.Joueurs.AddRange(joueurs);
            context.SaveChanges();

            var personnages = new Personnage[]
            {
                new Personnage{PersonnageID=1, PlayerName="Pierre", CharacterName="Urvan Artionovich", Profession="Trappeur", Vitality=5, Madness=0, Combat=57, Magic=55, Analysis=53, Survival=47, Emergency=50, Craft=57, Resourcefulness=50, Strenght=60, Endurance=55, Dexterity=60, Speed=40, Perception=45, Intelligence=60, Will=50, PhysicalProtection=0, MagicalProtection=0, CompetenceName="Gemmification", CompetenceEffect="Permet de créer des gemmes de pouvoir", WeaponName="", WeaponEffect="", WeaponDescription="", ArmorName="", ArmorEffect="", ArmorDescription="", ObjectName="", ObjectEffect="", ObjectDescription="", GemName="", GemElement="", GemCarats=0, GemAspect="", Note="", Lore=""},
                new Personnage{PersonnageID=2, PlayerName="Vincent", CharacterName="Jean Pecheur", Profession="Pêcheur", Vitality=5, Madness=0, Combat=0, Magic=0, Analysis=0, Survival=0, Emergency=0, Craft=0, Resourcefulness=0, Strenght=0, Endurance=0, Dexterity=0, Speed=0, Perception=0, Intelligence=0, Will=0, PhysicalProtection=0, MagicalProtection=0, CompetenceName="Gemmification", CompetenceEffect="Permet de créer des gemmes de pouvoir", WeaponName="", WeaponEffect="", WeaponDescription="", ArmorName="", ArmorEffect="", ArmorDescription="", ObjectName="", ObjectEffect="", ObjectDescription="", GemName="", GemElement="", GemCarats=0, GemAspect="", Note="", Lore=""},
                new Personnage{PersonnageID=3, PlayerName="Ulrich", CharacterName="Ulrich Couparbre", Profession="Bucheron", Vitality=5, Madness=0, Combat=0, Magic=0, Analysis=0, Survival=0, Emergency=0, Craft=0, Resourcefulness=0, Strenght=0, Endurance=0, Dexterity=0, Speed=0, Perception=0, Intelligence=0, Will=0, PhysicalProtection=0, MagicalProtection=0, CompetenceName="", CompetenceEffect="", WeaponName="", WeaponEffect="", WeaponDescription="", ArmorName="", ArmorEffect="", ArmorDescription="", ObjectName="", ObjectEffect="", ObjectDescription="", GemName="", GemElement="", GemCarats=0, GemAspect="", Note="", Lore=""}
            };

            context.Personnages.AddRange(personnages);
            context.SaveChanges();

            var possedent = new Possede[]
            {
                new Possede{JoueurID=1, PersonnageID=1},
                new Possede{JoueurID=2, PersonnageID=2},
                new Possede{JoueurID=3, PersonnageID=3},
            };

            context.Possedent.AddRange(possedent);
            context.SaveChanges();
        }
    }
}
