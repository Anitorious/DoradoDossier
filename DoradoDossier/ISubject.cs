namespace DoradoDossier
{
    public interface ISubject<T>
    {
        T ResolveSubjectQuery();
    }
}
