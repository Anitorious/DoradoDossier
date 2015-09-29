using DoradoDossier.Components;
using System.IO;
using System.Text;

namespace DoradoDossier.Utilities
{
    internal class TemplateResolver<T> : IResolver<T>
    {
        private readonly IRenderer<T> Renderer;
        private readonly IResolverConfiguration Configuration;

        internal TemplateResolver(IResolverConfiguration configuration)
        {
            Renderer = new TemplateRenderer<T>();
            Configuration = configuration;
        }

        public string ResolveTemplate(string name, T model)
        {
            StringBuilder path = new StringBuilder(FetchDossierDirectoryPath(name));
            path.Append(Resources.IO.DefaultTemplatePath);

            return Renderer.Render(name, path.ToString(), model);
        }

        private string FetchDossierDirectoryPath(string name)
        {
            string path = Configuration.MapFilePath(name);

            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException();

            return path;
        }
    }
}
