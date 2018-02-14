using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsprojScan.Contracts;

namespace CsprojScan.Implementation.Collect
{
    public class FileCrawler : IFileCrawler
    {
        private readonly FileCrawlerSettings settings;

        public FileCrawler(FileCrawlerSettings settings)
        {
            this.settings = settings;
        }

        public IEnumerable<string> GetFiles()
        {
            return GetFiles(settings.BasePath, settings.SearchPattern);
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