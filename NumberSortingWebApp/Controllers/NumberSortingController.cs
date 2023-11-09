﻿using Microsoft.AspNetCore.Mvc;
using NumberSortingWebApp.Library.Algorithm.Sorting;
using NumberSortingWebApp.Library.Database.Object;
using NumberSortingWebApp.Library.Database.Sql;
using NumberSortingWebApp.Models;
using System.Diagnostics;
using System.Reflection;

namespace NumberSortingWebApp.Controllers
{
    public class NumberSortingController : Controller
    {
        private SortedNumberConnection connection = new SortedNumberConnection();
        private ISort<int> sortingAlgorithmn = new Quicksort();

        public IActionResult List()
        {
            var model = new ListViewModel(connection);
            return View(model);
        }

        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost]
        public IActionResult Create(SortedNumbersRow sortedNumbersRow)
        {

            Console.WriteLine("Sorted Array: {0}", sortedNumbersRow.SortedArray.ToString());
            Console.WriteLine("Sorted Direction: {0}", sortedNumbersRow.SortDirection);

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
                id = connection.Update(sortedNumbersRow);
            }

            // Take user back to List page
            return RedirectToAction("List");
        }
    }
}