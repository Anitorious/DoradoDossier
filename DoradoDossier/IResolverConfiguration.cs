using Dorado.Enumerations;

namespace Dorado
{
    public interface IResolverConfiguration
    {
        string Location { get; set; }
        string Directory { get; set; }
        string SubjectHandle { get; set; }
        string TemplateHandle { get; set; }

        RenderMode RenderMode { get; set; }
    }
}
