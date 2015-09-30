using System.IO;

namespace Dorado.Utilities
{
    internal class TemplateResolver<T> : IResolver<T>
    {
        private readonly IRenderer<T> Renderer;
        private readonly IResolverConfiguration Configuration;

        internal TemplateResolver(IResolverConfiguration Configuration)
        {
            this.Configuration = Configuration;
            Renderer = new TemplateRenderer<T>(Configuration);
        }

        public string ResolveTemplate(string name, T model)
        {
            string directory = string.Format("{0}\\{1}\\{2}", Configuration.Location, Configuration.Directory, name);
            if (!Directory.Exists(directory))
                throw new DirectoryNotFoundException();

            string path = string.Format("{0}\\{1}.cshtml", directory, Configuration.TemplateHandle);
            if (!File.Exists(path))
                throw new FileNotFoundException(string.Format("File '{0}' could not be found at specified location '{1}'.", Configuration.TemplateHandle, directory));

            return Renderer.Render(name, path, model);
        }
    }
}
