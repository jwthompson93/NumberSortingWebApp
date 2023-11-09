using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NumberSortingWebApp.Library.Alert;

namespace NumberSortingWebApp.Models
{
    public class CreateViewModel : PageModel
    {
        [BindProperty]
        public string NumbersInput { get; set; }
        public int SortDirection { get; set; }

        public Alert Alert { get; set; }

        public CreateViewModel(Alert alert)
        {
            this.Alert = alert;
        }
    }
}
