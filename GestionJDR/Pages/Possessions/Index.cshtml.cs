using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionJDR.Data;

namespace GestionJDR.Pages.Possessions
{
    public class IndexModel : PageModel
    {
        private readonly GestionJDR.Data.GestionJDRContext _context;

        public IndexModel(GestionJDR.Data.GestionJDRContext context)
        {
            _context = context;
        }

        public IList<Possede> Possede { get;set; }

        public async Task OnGetAsync()
        {
            Possede = await _context.Possedent
                .Include(p => p.Joueur)
                .Include(p => p.Personnage).ToListAsync();
        }
    }
}
