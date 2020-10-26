using System;
using System.Linq;
using System.Reflection;

namespace BookInfoApp.WebAPI.AppStart.AutoFac
{
    public static class AssemblyHelper
    {
        public static Assembly FindAssemblyByName(Assembly[] assemblies, string name)
        {
            if (assemblies == null)
                throw new ArgumentNullException(nameof(assemblies));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var normalizeName = name.ToLower();
            return assemblies.FirstOrDefault(assembly => ContainsName(assembly, normalizeName));
        }

        private static bool ContainsName(Assembly assembly, string name)
            => assembly.FullName.ToLower().Contains(name);
    }
}
