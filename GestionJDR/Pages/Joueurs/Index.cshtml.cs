using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionJDR.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionJDR.Pages.Joueurs
{
    public class IndexModel : PageModel
    {
        private readonly GestionJDR.Data.GestionJDRContext _context;

        public IndexModel(GestionJDR.Data.GestionJDRContext context)
        {
            _context = context;
        }

        public IList<Joueur> Joueur { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Players { get; set; }
        [BindProperty(SupportsGet = true)]
        public string NomJoueur { get; set; }

        public IList<Joueur> Joueurs { get;set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Joueurs
                                            orderby m.PlayerName
                                            select m.PlayerName;

            var joueurs = from m in _context.Joueurs
                          select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                joueurs = joueurs.Where(s => s.Jdr.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(NomJoueur))
            {
                joueurs = joueurs.Where(x => x.PlayerName == NomJoueur);
            }
            Players = new SelectList(await genreQuery.Distinct().ToListAsync());
            Joueur = await joueurs.ToListAsync();
        }
    }
}
