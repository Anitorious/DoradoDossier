using DoradoDossier.Enumerations;

namespace DoradoDossier
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
