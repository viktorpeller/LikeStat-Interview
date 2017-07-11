namespace Peller.Interview.CSharp.LikeStatistics
{
    using System;
    using System.IO;

    internal static class FileSystem
    {
        internal static string[] GetFiles(string path, string extension)
        {
            return Directory.GetFiles(path, "*." + extension);
        }

        internal static string[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }
    }
}
