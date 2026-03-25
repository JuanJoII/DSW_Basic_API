using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DSW_Basic_API.Filters
{
    public class Filtrico : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Ejecutando el filtro después de la acción.");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Ejecutando el filtro antes de la acción.");
        }
    }
}