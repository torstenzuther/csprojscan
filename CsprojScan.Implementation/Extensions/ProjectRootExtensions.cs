using Microsoft.Build.Construction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CsprojScan.Implementation.Extensions
{
    public static class ProjectRootExtensions
    {
        public static IEnumerable<KeyValuePair<string, string>> GetReferences(this ProjectRootElement projectRoot)
        {
            var result = new List<KeyValuePair<string, string>>();
            var itemGroups = projectRoot.ItemGroups;
            foreach (var itemGroup in itemGroups)
            {
                foreach (var item in itemGroup.Children)
                {
                    if (item is ProjectItemElement projectItemElement)
                    {
                        if (new[] { "PackageReference", "ProjectReference" }.Contains(projectItemElement.ItemType))
                        {
                            var versionPropElem = projectItemElement.Metadata
                                .FirstOrDefault(c => c.Name == "Version");
                            result.Add(new KeyValuePair<string, string>(projectItemElement.Include, versionPropElem?.Value ?? "yes"));
                        } else if (projectItemElement.ItemType == "Reference")
                        {
                            var splitted = projectItemElement.Include?.Split(',');
                            var name = splitted?.FirstOrDefault();
                            var version = splitted?.FirstOrDefault(s => s.TrimStart().StartsWith("Version="))?.TrimStart()?.Trim("Version=".ToArray());
                            if (name != null)
                            {
                                result.Add(new KeyValuePair<string, string>(name, version ?? "yes"));

                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
