using System;

namespace net.effects.Utils
{
    /// <summary>
    /// Utils for faste resources access
    /// </summary> 
    internal static class ResourceUtils
    {
        public static Uri GetPackageUri(string path)
        {
            return new Uri("pack://application:,,, /net.effects;component/" + path);
        }
    }
}
