using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NumberSortingWebApp.Library.Alert;
using NumberSortingWebApp.Library.Database.Object;
using NumberSortingWebApp.Library.Database.Sql;
using System.Data.Common;

namespace NumberSortingWebApp.Models
{
    public class CreateViewModel : PageModel
    {
        [BindProperty]
        public SortedNumbersRow SortedNumbersRow { get; set; }

        public Alert Alert { get; set; }

        public CreateViewModel(Alert alert)
        {
            this.Alert = alert;
        }
    }
}
