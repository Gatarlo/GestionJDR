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
    public class DeleteModel : PageModel
    {
        private readonly GestionJDR.Data.GestionJDRContext _context;

        public DeleteModel(GestionJDR.Data.GestionJDRContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Personnage = await _context.Personnages.FindAsync(id);

            if (Personnage != null)
            {
                _context.Personnages.Remove(Personnage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
