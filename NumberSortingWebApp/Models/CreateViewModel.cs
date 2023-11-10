using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NumberSortingWebApp.Library.Alert;
using System.ComponentModel.DataAnnotations;

namespace NumberSortingWebApp.Models
{
    public class CreateViewModel : PageModel
    {
        [BindProperty]
        [Required]
        [RegularExpression("[^\\d+,\\d+$]", ErrorMessage = "Values must be numeric and comma-separated")]
        public string NumbersInput { get; set; }


        [BindProperty]
        [Required]
        public int SortDirection { get; set; }

        public Alert alert { get; set; }

        public CreateViewModel(Alert alert)
        {
            this.alert = alert;
        }
    }
}
