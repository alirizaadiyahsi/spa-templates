using Microsoft.AspNetCore.Mvc.Filters;
using SpaTemplates.EntityFrameworkCore;

namespace SpaTemplates.Web.Server.ActionFilters
{
    public class MyFilter : IActionFilter
    {
        private readonly SpaTemplatesContext _context;

        public MyFilter(SpaTemplatesContext context)
        {
            _context = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _context.SaveChanges();
        }
    }
}