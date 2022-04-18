using System.IO;
using System.Reflection;

namespace ToyRobotSimulation.Tests
{
    public static class EmbededResourceUtils
    {
        private static readonly Assembly CurrentAssembly = typeof(EmbededResourceUtils).Assembly;
        public static string? GetEmbededResource(string name)
        {
            var resourceNames = CurrentAssembly.GetManifestResourceNames();
            foreach (string resourceName in resourceNames)
            {
                if (resourceName.EndsWith(name))
                {
                    using Stream? stream = CurrentAssembly.GetManifestResourceStream(resourceName);
                    if (stream is not null)
                    {
                        using var reader = new StreamReader(stream);
                        return reader.ReadToEnd();
                    }
                }
            }
            return null;
        }
    }
}
