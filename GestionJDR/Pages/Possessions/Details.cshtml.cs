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
    public class DetailsModel : PageModel
    {
        private readonly GestionJDR.Data.GestionJDRContext _context;

        public DetailsModel(GestionJDR.Data.GestionJDRContext context)
        {
            _context = context;
        }

        public Possede Possede { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Possede = await _context.Possedent
                .Include(p => p.Joueur)
                .Include(p => p.Personnage).FirstOrDefaultAsync(m => m.PossedeID == id);

            if (Possede == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
