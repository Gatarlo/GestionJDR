using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionJDR.Data;

namespace GestionJDR.Pages.Possessions
{
    public class EditModel : PageModel
    {
        private readonly GestionJDR.Data.GestionJDRContext _context;

        public EditModel(GestionJDR.Data.GestionJDRContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["JoueurID"] = new SelectList(_context.Joueurs, "ID", "FamilyName");
           ViewData["PersonnageID"] = new SelectList(_context.Personnages, "PersonnageID", "CharacterName");
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

            _context.Attach(Possede).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PossedeExists(Possede.PossedeID))
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

        private bool PossedeExists(int id)
        {
            return _context.Possedent.Any(e => e.PossedeID == id);
        }
    }
}
