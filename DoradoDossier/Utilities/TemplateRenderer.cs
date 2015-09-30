using DoradoDossier.Enumerations;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using System.IO;

namespace DoradoDossier.Utilities
{
    internal class TemplateRenderer<T> : IRenderer<T>
    {
        private readonly IResolverConfiguration Configuration;

        public TemplateRenderer(IResolverConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public string Render(string name, string path, T model)
        {
            string hash = name.GetHashCode().ToString("X8");

            switch(Configuration.RenderMode)
            {
                case RenderMode.Trusted:
                    return RenderTrusted(hash, path, model);
                default:
                    return RenderTrusted(hash, path, model);
            }
        }

        private string RenderTrusted(string hash, string path, T model)
        {
            var configuration = new TemplateServiceConfiguration()
            {
                DisableTempFileLocking = true,
                CachingProvider = new DefaultCachingProvider(x => { })
            };

            using (var service = RazorEngineService.Create(configuration))
            {
                if (!service.IsTemplateCached(hash, typeof(T)))
                    service.Compile(File.ReadAllText(path), hash, typeof(T));

                return service.Run(hash, typeof(T), model);
            }
        }
    }
}
