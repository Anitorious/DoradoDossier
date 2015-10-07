using Dorado.Components;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Dorado
{
    public class Dossier
    {
        private readonly IResolverConfiguration Configuration;
        private readonly Assembly Assembly;
        private readonly string Location;

        public Dossier()
        {
            Assembly = Assembly.GetCallingAssembly();
            Location = Assembly.Location.Remove(Assembly.Location.IndexOf(Resources.IO.Bin));
            Configuration = new ResolverConfiguration(Location);
        }

        public Dossier(IResolverConfiguration Configuration)
        {
            Assembly = Assembly.GetCallingAssembly();
            Location = Assembly.Location.Remove(Assembly.Location.IndexOf(Resources.IO.Bin));

            this.Configuration = Configuration;
            Configuration.Location = Location;
        }

        public string BindDossier<T>(string name)
        {
            var handle = string.Format("{0}{1}", name, Configuration.SubjectHandle);

            ITopic<T> topic = InstantiateInstance<T>(handle);
            TemplateResolver<T> resolver = new TemplateResolver<T>(Configuration);

            T model = topic
                .ResolveTopicQuery();

            return resolver.ResolveTemplate(name, model);
        }

        private ITopic<T> InstantiateInstance<T>(string handle)
        {
            var type = Assembly.GetTypes().SingleOrDefault(x => x.Name == handle);
            if (type == null)
                throw new FileNotFoundException(string.Format("Dossier subject '{0}' could not be instantiated. The file '{0}' could not be found at the specified location '{1}'.", handle, string.Format("{0}\\{1}\\{2}", Location, Configuration.Directory, handle)));

            return (ITopic<T>)Activator.CreateInstance(type);
        }
    }
}
