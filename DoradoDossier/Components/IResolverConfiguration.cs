namespace DoradoDossier.Components
{
    internal interface IResolverConfiguration
    {
        string Location { get; set; }
        string Directory { get; set; }
        string MapFilePath(string name);
    }
}
