using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionJDR.Data;

namespace GestionJDR.Pages.Personnages
{
    public class EditModel : PageModel
    {
        private readonly GestionJDR.Data.GestionJDRContext _context;

        public EditModel(GestionJDR.Data.GestionJDRContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Personnage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonnageExists(Personnage.PersonnageID))
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

        private bool PersonnageExists(int id)
        {
            return _context.Personnages.Any(e => e.PersonnageID == id);
        }
    }
}
