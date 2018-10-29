using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ForumTest1.Models;
using ForumTest1.Data;

namespace ForumTest1.Pages
{
    public class ForumModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Topic> Topics { get; set; }
        public ForumModel(ApplicationDbContext db)
        {
            _context = db;
        }

        public async Task OnGetAsync()
        {
            Topics = await _context.Topics.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var topic = await _context.Topics.FindAsync(id);

            if (topic != null)
            {
                _context.Topics.Remove(topic);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}