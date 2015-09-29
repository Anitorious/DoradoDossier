namespace DoradoDossier.Components
{
    internal class ResolverConfiguration : IResolverConfiguration
    {
        public string Location { get; set; }
        public string Directory { get; set; }

        public ResolverConfiguration(string location)
        {
            Location = location;
            Directory = Resources.IO.DefaultDirectory;
        }

        public ResolverConfiguration(string location, string directory)
        {
            Location = location;
            Directory = directory;
        }

        public string MapFilePath(string name)
        {
            return string.Format("{0}\\{1}\\{2}", Location, Directory, name);
        }
    }
}
