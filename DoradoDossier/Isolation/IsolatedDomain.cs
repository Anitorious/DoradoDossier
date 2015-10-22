using System;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;

namespace Dorado.Isolation
{
    internal sealed class IsolatedDomain
    {
        private static Lazy<AppDomain> Instance =
            new Lazy<AppDomain>(() => Initialise());

        public static AppDomain Domain { get { return Instance.Value; } }

        private static AppDomain Initialise()
        {
            PermissionSet permissions = new PermissionSet(PermissionState.Unrestricted);
            StrongName[] assemblies = new StrongName[0];

            AppDomainSetup setup = new AppDomainSetup()
            {
                ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase
            };

            return AppDomain.CreateDomain("Razor", null, setup, permissions, assemblies);
        }

        public static void Recycle()
        {
            if (Instance.IsValueCreated)
            {
                AppDomain.Unload(Instance.Value);
                Instance = new Lazy<AppDomain>(() => Initialise());
            }
        }
    }
}
