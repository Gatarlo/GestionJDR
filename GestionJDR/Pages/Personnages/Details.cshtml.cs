using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionJDR.Data;

namespace GestionJDR.Pages.Personnages
{
    public class DetailsModel : PageModel
    {
        private readonly GestionJDR.Data.GestionJDRContext _context;

        public DetailsModel(GestionJDR.Data.GestionJDRContext context)
        {
            _context = context;
        }

        public Personnage Personnage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Personnage = await _context.Personnages.FirstOrDefaultAsync(m => m.PersonnageID == id);

            if (Personnage == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
