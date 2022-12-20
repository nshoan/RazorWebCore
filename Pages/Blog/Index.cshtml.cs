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
    public class IndexModel : PageModel
    {
        private readonly RazorWeb6.Models.MyBlogContext _context;

        public IndexModel(RazorWeb6.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; } = default!;
        public int PAGE_SIZE { get; set; } = 5;
        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }
        public int countPages { get; set; }

        public async Task OnGetAsync(string SearchString)
        {
            if (_context.Article != null)
            {
                //Article = await _context.Article.ToListAsync();
                int totalArticle = await _context.Article.CountAsync();
                countPages = (int)Math.Ceiling((double)totalArticle / PAGE_SIZE);
                if (currentPage < 1)
                {
                    currentPage = 1;
                }
                if (currentPage > countPages)
                {
                    currentPage = countPages;
                }
                var query = (from a in _context.Article
                             orderby a.Created descending
                             select a).Skip((currentPage - 1) * PAGE_SIZE).Take(PAGE_SIZE);
                if (!String.IsNullOrEmpty(SearchString))
                {
                    Article = await query.Where(x => x.Title.Contains(SearchString)).ToListAsync();
                }
                else
                {
                    Article = await query.ToListAsync();
                }

            }
        }
    }
}
