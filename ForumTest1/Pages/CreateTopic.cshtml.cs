using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ForumTest1.Models;
using ForumTest1.Data;

namespace ForumTest1.Pages
{
    public class CreateTopicModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]

        public Topic topics { get; set; }
        public CreateTopicModel(ApplicationDbContext db)
        {
            _context = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Topics.Add(topics);
                await _context.SaveChangesAsync();
                return RedirectToPage("Forum");
            }
            return Page();
        }
    }
}