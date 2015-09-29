using DoradoDossier.Components;
using DoradoDossier.Utilities;
using System;
using System.Linq;
using System.Reflection;

namespace DoradoDossier
{
    public class Dossier<T>
    {
        public string BindDossier(string name)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            string location = assembly.Location.Remove(assembly.Location.IndexOf(Resources.IO.Bin));
            TemplateResolver<T> resolver = new TemplateResolver<T>(new ResolverConfiguration(location));

            Type type = assembly.GetTypes().SingleOrDefault(x => x.Name == string.Format(Resources.IO.DefaultQueryPath, name));
            if (type == null)
                throw new NullReferenceException();

            var queryResolver = (IDossierQuery<T>)Activator.CreateInstance(type);
            T model = queryResolver
                .ResolveTemplateQuery();

            return resolver.ResolveTemplate(name, model);
        }
    }
}
