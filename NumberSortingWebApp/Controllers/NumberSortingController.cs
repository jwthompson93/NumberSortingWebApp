﻿using Microsoft.AspNetCore.Mvc;
using NumberSortingWebApp.Library.Alert;
using NumberSortingWebApp.Library.Algorithm.Sorting;
using NumberSortingWebApp.Library.Database.Object;
using NumberSortingWebApp.Library.Database.Sql;
using NumberSortingWebApp.Library.TempData;
using NumberSortingWebApp.Models;
using System.Diagnostics;

namespace NumberSortingWebApp.Controllers
{
    public class NumberSortingController : Controller
    {
        private SortedNumberConnection connection;
        private ISort<int> sortingAlgorithmn;

        public NumberSortingController()
        {
            connection = new SortedNumberConnection();
            sortingAlgorithmn = new Quicksort();
        }

        public IActionResult List()
        {
            var model = new ListViewModel(connection, TempData.Get<Alert>("alert"));

            return View(model);
        }

        public IActionResult New()
        {
            var model = new CreateViewModel(TempData.Get<Alert>("alert"));
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SortedNumbersRow sortedNumbersRow)
        {
            if(ModelState.IsValid)
            {
                long id = connection.Insert(sortedNumbersRow);

                // Insert initial value
                if (id > 0)
                {
                    // Process sort and update
                    sortedNumbersRow.Id = id;

                    int[] convertIntArray = sortedNumbersRow.SortedArray.Split(',').Select(int.Parse).ToArray();

                    Stopwatch sw = Stopwatch.StartNew();
                    sw.Start();
                    sortedNumbersRow.SortedArray = String.Join(',', sortingAlgorithmn.Sort(convertIntArray, sortedNumbersRow.SortDirection));
                    sw.Stop();

                    sortedNumbersRow.TimeTaken = sw.ElapsedMilliseconds;
                    sortedNumbersRow.IsSorted = true;

                    id = connection.Update(sortedNumbersRow);
                }

                TempData.Put<Alert>("alert", new Alert(AlertType.success, "Job has been successfully submitted!"));

                // Take user back to List page
                return RedirectToAction("List");
            }

            TempData.Put<Alert>("alert", new Alert(AlertType.danger, "ModelState not valid"));

            return RedirectToAction("New");
        }
    }
}
