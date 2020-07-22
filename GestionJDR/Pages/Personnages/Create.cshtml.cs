using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionJDR.Data;

namespace GestionJDR.Pages.Personnages
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
            return Page();
        }

        [BindProperty]
        public Personnage Personnage { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Personnages.Add(Personnage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
