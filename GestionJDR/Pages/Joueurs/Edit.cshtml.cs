using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionJDR.Data;

namespace GestionJDR.Pages.Joueurs
{
    public class EditModel : PageModel
    {
        private readonly GestionJDR.Data.GestionJDRContext _context;

        public EditModel(GestionJDR.Data.GestionJDRContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Joueur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JoueurExists(Joueur.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JoueurExists(int id)
        {
            return _context.Joueurs.Any(e => e.ID == id);
        }
    }
}
