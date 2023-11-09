﻿using Microsoft.AspNetCore.Mvc;
using NumberSortingWebApp.Library.Alert;
using NumberSortingWebApp.Library.Database.Object;
using NumberSortingWebApp.Library.Database.Sql;

namespace NumberSortingWebApp.Models
{
    public class ListViewModel
    {
        private SortedNumberConnection _connection;
        public List<SortedNumbersRow> sortedNumberRowList { get; set; }

        [TempData]
        public Alert Alert { get; set; }

        public ListViewModel(Alert alert) { 
            this.Alert = alert;

            _connection  = new SortedNumberConnection();
            sortedNumberRowList = _connection.GetAll();
        }

    }
}
