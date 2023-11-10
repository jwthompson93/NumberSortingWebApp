using Microsoft.AspNetCore.Mvc;
using NumberSortingWebApp.Library.Alert;
using NumberSortingWebApp.Library.Algorithm.Sorting;
using NumberSortingWebApp.Library.Database.Object;
using NumberSortingWebApp.Library.Database.Sql;
using NumberSortingWebApp.Library.Process;
using NumberSortingWebApp.Library.TempData;
using NumberSortingWebApp.Models;
using System.Diagnostics;

namespace NumberSortingWebApp.Controllers
{
    public class NumberSortingController : Controller
    {
        public IActionResult List()
        {
            var model = new ListViewModel(TempData.Get<Alert>("alert"));

            return View(model);
        }

        public IActionResult New()
        {
            var model = new CreateViewModel(TempData.Get<Alert>("alert"));
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(string NumbersInput, int SortDirection)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    int[] convertIntArray = NumbersInput.Split(',').Select(int.Parse).ToArray();

                    var sortedNumbersRow = new SortArrayProcess(new Quicksort(), SortDirection).Process(convertIntArray);

                    if (new InsertProcess().Process(sortedNumbersRow))
                    {
                        TempData.Put("alert", new Alert(AlertType.success, "Job has been successfully submitted!"));

                        // Take user back to List page
                        return RedirectToAction("List");
                    }
                } 
                catch (FormatException fex)
                {
                    TempData.Put("alert", new Alert(AlertType.danger, fex.Message));
                }
            }
            else
            {
                TempData.Put("alert", new Alert(AlertType.danger, "Model State not valid"));
            }

            return RedirectToAction("New");
        }
    }
}
