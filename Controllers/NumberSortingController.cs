using Microsoft.AspNetCore.Mvc;
using NumberSortingLibrary.Database.Object;
using NumberSortingLibrary.Database.Sql;
using NumberSortingWebApp.Models;
using System.Reflection;

namespace NumberSortingWebApp.Controllers
{
    public class NumberSortingController : Controller
    {
        public IActionResult List()
        {
            var model = new ListViewModel();
            return View(model);
        }

        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost]
        public IActionResult Create(SortedNumbersRow sortedNumbersRow)
        {
            Console.WriteLine("Sorted Array: {0}", sortedNumbersRow.sorted_array.ToString());
            Console.WriteLine("Sorted Direction: {0}", sortedNumbersRow.sort_direction);

            // Insert initial value
            var connection = new SortedNumberConnection();

            // Process sort and update
            
            // Take user back to List page
            
            return RedirectToAction("List");
        }
    }
}
