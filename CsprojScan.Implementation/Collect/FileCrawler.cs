using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsprojScan.Contracts;

namespace CsprojScan.Implementation.Collect
{
    /// <summary>
    /// Default implementation of a file crawler
    /// </summary>
    public class FileCrawler : IFileCrawler
    {
        private readonly FileCrawlerSettings settings;

        /// <summary>
        /// Creates a file crawler
        /// </summary>
        /// <param name="settings">the settings for the file crawler to use</param>
        public FileCrawler(FileCrawlerSettings settings)
        {
            this.settings = settings;
        }

        /// <summary>
        /// Returns all files found depending on the given settings
        /// </summary>
        /// <returns>All files (full paths and they are distinct)</returns>
        public IEnumerable<string> GetFiles()
        {
            var files = settings.BasePaths
                .Select(path => GetFiles(path, settings.SearchPattern))
                .SelectMany(f => f)
                .Distinct();
            return files;
        }

        /// <summary>
        /// https://stackoverflow.com/questions/1393178/unauthorizedaccessexception-cannot-resolve-directory-getfiles-failure/9831340#9831340
        /// </summary>
        /// <param name="path"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        private IEnumerable<string> GetFiles(string path, string searchPattern)
        {
            return Directory.EnumerateFiles(path, searchPattern)
                .Union(Directory
                .EnumerateDirectories(path).SelectMany(d =>
                {
                    try
                    {
                        return GetFiles(d, searchPattern);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        return Enumerable.Empty<String>();
                    }
                }));
        }
    }
}