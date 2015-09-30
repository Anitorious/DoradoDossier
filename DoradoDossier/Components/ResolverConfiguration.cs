using Dorado.Enumerations;

namespace Dorado.Components
{
    internal sealed class ResolverConfiguration : IResolverConfiguration
    {
        public string Location { get; set; }
        public string Directory { get; set; }
        public string SubjectHandle { get; set; }
        public string TemplateHandle { get; set; }

        public RenderMode RenderMode { get; set; }

        public ResolverConfiguration(string Location)
        {
            this.Location = Location;
            Directory = Resources.IO.DefaultDirectory;
            SubjectHandle = Resources.IO.DefaultSubjectHandle;
            TemplateHandle = Resources.IO.DefaultTemplateHandle;

            RenderMode = RenderMode.Trusted;
        }
    }
}
