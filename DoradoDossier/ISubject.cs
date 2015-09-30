namespace Dorado
{
    public interface ISubject<T>
    {
        T ResolveSubjectQuery();
    }
}
