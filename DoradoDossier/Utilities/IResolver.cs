namespace DoradoDossier.Utilities
{
    internal interface IResolver<T>
    {
        string ResolveTemplate(string name, T model);
    }
}