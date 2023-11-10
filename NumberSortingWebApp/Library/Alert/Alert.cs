namespace NumberSortingWebApp.Library.Alert
{
    public class Alert
    {
        public Alert(AlertType type, string message)
        {
            this.Type = type;
            this.Message = message;
        }

        public string Message { get; set; }
        public AlertType Type { get; set; }
    }
}
