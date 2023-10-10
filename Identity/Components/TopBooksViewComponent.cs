using Microsoft.AspNetCore.Mvc;

namespace Identity.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}
