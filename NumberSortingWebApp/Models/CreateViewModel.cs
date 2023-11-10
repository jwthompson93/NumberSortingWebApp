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
        public List<int> NumbersInputArray { get; set; }

        [BindProperty]
        public int NumberInput {  get; set; }


        [BindProperty]
        public int SortDirection { get; set; }

        public Alert Alert { get; set; }

        public CreateViewModel(Alert alert)
        {
            this.Alert = alert;
            this.NumbersInputArray = new List<int>();
        }

        public void NumberInput_onClick()
        {
            NumbersInputArray.Add(NumberInput);
        }
    }
}
