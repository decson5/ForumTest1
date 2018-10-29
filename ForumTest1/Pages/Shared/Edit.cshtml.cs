using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ForumTest1.Models;
using ForumTest1.Data;
using Microsoft.EntityFrameworkCore;

namespace ForumTest1.Pages.Shared
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Topic topic { get; set; }

        public EditModel(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            topic = await _context.Topics.FindAsync(id);

            if (topic == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(topic).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Topics.Any(e => e.ID == topic.ID)) return NotFound();
                else throw;
            }
            return RedirectToPage("Forum");
        }
    }
}