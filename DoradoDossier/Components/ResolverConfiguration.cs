namespace Dorado.Components
{
    internal class ResolverConfiguration : IResolverConfiguration
    {
        public string Location { get; set; }
        public string Directory { get; set; }
        public string SubjectHandle { get; set; }
        public string TemplateHandle { get; set; }

        public ResolverConfiguration(string Location)
        {
            this.Location = Location;
            Directory = Resources.IO.DefaultDirectory;
            SubjectHandle = Resources.IO.DefaultSubjectHandle;
            TemplateHandle = Resources.IO.DefaultTemplateHandle;
        }
    }
}
