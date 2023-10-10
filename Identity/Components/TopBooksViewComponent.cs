using Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public TopBooksViewComponent(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = _context.applicationUsers.FirstOrDefault();
            return View(data);
        }

    }
}
