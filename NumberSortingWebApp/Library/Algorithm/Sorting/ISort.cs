namespace NumberSortingWebApp.Library.Algorithm.Sorting
{
    public interface ISort<T>
    {
        T[] Sort(T[] array, int sortDirection);
    }
}
