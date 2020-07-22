using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionJDR.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionJDR.Pages.Personnages
{
    public class IndexModel : PageModel
    {
        private readonly GestionJDR.Data.GestionJDRContext _context;

        public IndexModel(GestionJDR.Data.GestionJDRContext context)
        {
            _context = context;
        }

        public IList<Personnage> Personnage { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Noms { get; set; }
        [BindProperty(SupportsGet = true)]
        public string NomPersonnage { get; set; }


        public async Task OnGetAsync()
        {

            IQueryable<string> genreQuery = from m in _context.Personnages
                                            orderby m.CharacterName
                                            select m.CharacterName;

            var personnages = from p in _context.Personnages
                              select p;

            if (!string.IsNullOrEmpty(SearchString))
            {
                personnages = personnages.Where(s => s.PlayerName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(NomPersonnage))
            {
                personnages = personnages.Where(x => x.CharacterName == NomPersonnage);
            }
            Noms = new SelectList(await genreQuery.Distinct().ToListAsync());
            Personnage = await personnages.ToListAsync();
        }
    }
}
