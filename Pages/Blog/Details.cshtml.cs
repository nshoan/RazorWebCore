using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorWeb6.Models;

namespace RazorWeb6.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly RazorWeb6.Models.MyBlogContext _context;

        public DetailsModel(RazorWeb6.Models.MyBlogContext context)
        {
            _context = context;
        }

      public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Article == null)
            {
                return NotFound();
            }

            var article = await _context.Article.FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }
            else 
            {
                Article = article;
            }
            return Page();
        }
    }
}
