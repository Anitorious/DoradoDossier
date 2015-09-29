using RazorEngine;
using RazorEngine.Templating;
using System.IO;

namespace DoradoDossier.Utilities
{
    internal class TemplateRenderer<T> : IRenderer<T>
    {
        public string Render(string name, string path, T model)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(Resources.Exceptions.TemplateCouldNotBeFound);

            string hash = name.GetHashCode().ToString("X8");
            if (!Engine.Razor.IsTemplateCached(hash, typeof(T)))
                Engine.Razor.Compile(File.ReadAllText(path), hash, typeof(T));

            return Engine.Razor.Run(hash, typeof(T), model);
        }
    }
}
