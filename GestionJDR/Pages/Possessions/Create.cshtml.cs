using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionJDR.Data;

namespace GestionJDR.Pages.Possessions
{
    public class CreateModel : PageModel
    {
        private readonly GestionJDR.Data.GestionJDRContext _context;

        public CreateModel(GestionJDR.Data.GestionJDRContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["JoueurID"] = new SelectList(_context.Joueurs, "ID", "FamilyName");
        ViewData["PersonnageID"] = new SelectList(_context.Personnages, "PersonnageID", "CharacterName");
            return Page();
        }

        [BindProperty]
        public Possede Possede { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Possedent.Add(Possede);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
