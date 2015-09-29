namespace DoradoDossier
{
    public interface IDossierQuery<T>
    {
        T ResolveTemplateQuery();
    }
}
