using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using asmt10.Models;
using Microsoft.EntityFrameworkCore;

namespace asmt10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private RecipesContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, RecipesContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index(long? mealtypeid, int pageNum = 0)
        {
            int pageSize = 3;

            // passes the info to the view, but must still be rendered in the view to actually be displayed
            return View(context.Recipes
                //.FromSqlInterpolated($"SELECT * FROM Recipes WHERE RecipeClassID = {mealtypeid} OR {mealtypeid} IS NULL" )

                ////.FromSqlRaw("SELECT * FROM Recipes WHERE RecipeTitle LIKE \"%Nachos%\"")
                //// ^ commented out for sql interpolated, which allows feeding of a variable as parameter instead

                ////.Where(x => x.RecipeTitle.Contains("Nachos")) 
                ////.OrderBy(x => x.RecipeTitle)
                //// commented out for sqlraw above

                //.ToList());

                .Where(m => m.RecipeClassId == mealtypeid || mealtypeid == null)
                .OrderBy(m => m.RecipeTitle)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList());



        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
