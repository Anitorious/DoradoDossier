using RazorEngine.Templating;
using System;

namespace Dorado.Isolation
{
    public sealed class IsolatedService
    {
        private static Lazy<IRazorEngineService> Instance =
            new Lazy<IRazorEngineService>(() => Initialise());

        public static IRazorEngineService Service { get { return Instance.Value; } }

        private static IRazorEngineService Initialise()
        {
            return IsolatedRazorEngineService.Create(() => { return IsolatedDomain.Domain; });
        }

        public static void Recycle()
        {
            if (Instance.IsValueCreated)
            {
                IsolatedDomain.Recycle();                
                Instance = new Lazy<IRazorEngineService>(() => Initialise());
            }
        }
    }
}
