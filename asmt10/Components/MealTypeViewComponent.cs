using System;
using System.Linq;
using asmt10.Models;
using Microsoft.AspNetCore.Mvc;

namespace asmt10.Components
{
    public class MealTypeViewComponent : ViewComponent
    {
        private RecipesContext context;

        // we need the data, like we would pull/build in the controller
        // constructor to build that information
        public MealTypeViewComponent(RecipesContext ctx)
        {
            context = ctx;
        }


       public IViewComponentResult Invoke()
        {

            // default view is whatever we set up in the views that corresponds with this 
            return View(context.RecipeClasses
                .Distinct()
                .OrderBy(x => x));

        }
    }
}
