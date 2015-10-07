namespace Dorado
{
    public interface ITopic<T>
    {
        T ResolveTopicQuery();
    }
}
