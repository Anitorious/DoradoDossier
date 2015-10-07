using Dorado.Isolation;
using RazorEngine.Templating;
using System.IO;

namespace Dorado.Components
{
    internal class TemplateRenderer<T>
    {
        private readonly IResolverConfiguration Configuration;

        public TemplateRenderer(IResolverConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public string Render(string name, string path, T model)
        {
            string hash = name.GetHashCode().ToString("X8");

            using (var service = IsolatedService.Service)
            {
                if (!service.IsTemplateCached(hash, typeof(T)))
                    service.Compile(File.ReadAllText(path), hash, typeof(T));

                return service.Run(hash, typeof(T), model);
            }
        }
    }
}
