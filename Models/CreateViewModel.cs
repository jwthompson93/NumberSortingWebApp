using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NumberSortingWebApp.Library.Database.Object;

namespace NumberSortingWebApp.Models
{
    public class CreateViewModel : PageModel
    {
        [BindProperty]
        public SortedNumbersRow SortedNumbersRow { get; set; }
    }
}
