namespace NumberSortingWebApp.Library.Process
{
    public interface IProcess<IN,OUT>
    {
        public OUT Process(IN input);
    }
}
