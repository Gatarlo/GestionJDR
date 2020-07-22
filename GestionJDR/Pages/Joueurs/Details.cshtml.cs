using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionJDR.Data;
using GestionJDR.Data;

namespace GestionJDR.Pages.Joueurs
{
    public class DetailsModel : PageModel
    {
        private readonly GestionJDR.Data.GestionJDRContext _context;

        public DetailsModel(GestionJDR.Data.GestionJDRContext context)
        {
            _context = context;
        }

        public Joueur Joueur { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Joueur = await _context.Joueurs.FirstOrDefaultAsync(m => m.ID == id);

            if (Joueur == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
