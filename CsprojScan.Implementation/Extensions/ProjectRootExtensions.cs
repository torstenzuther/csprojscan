using Microsoft.Build.Construction;
using System;
using System.Collections.Generic;
using System.Linq;
using CsprojScan.Contracts;
using CsprojScan.Implementation.Collect;

namespace CsprojScan.Implementation.Extensions
{
    public static class ProjectRootExtensions
    {
        private const string KeyName = "Name";
        private const string VersionName = "Version";
        private const string RefTypeName = "ReferenceType";
        private const string Ref = "Reference";
        private const string PackageRef = "PackageReference";
        private const string ProjectRef = "ProjectReference";

        public static IEnumerable<IResultRow> GetReferences(this ProjectRootElement projectRoot)
        {
            var result = new List<IResultRow>();
            var itemGroups = projectRoot.ItemGroups;
            foreach (var itemGroup in itemGroups)
            {
                foreach (var item in itemGroup.Children)
                {
                    if (item is ProjectItemElement projectItemElement)
                    {
                        if (new[] { PackageRef, ProjectRef }.Contains(projectItemElement.ItemType))
                        {
                            var versionPropElem = projectItemElement.Metadata
                                .FirstOrDefault(c => c.Name == "Version");
                            result.Add(GetResultRow(projectItemElement.Include, versionPropElem?.Value, projectItemElement.ItemType));

                        } else if (projectItemElement.ItemType == Ref)
                        {
                            var splitted = projectItemElement.Include?.Split(',');
                            var name = splitted?.FirstOrDefault();
                            var version = splitted?.FirstOrDefault(s => s.TrimStart().StartsWith("Version="))?.TrimStart()?.Trim("Version=".ToArray());
                            if (name != null)
                            {
                                result.Add(GetResultRow(name, version, projectItemElement.ItemType));
                            }
                        }
                    }
                }
            }
            return result;
        }

        private static IResultRow GetResultRow(string name, string version, string itemType)
        {
            return new ResultRow(new List<Tuple<string, string>> {
                                new Tuple<string, string>(KeyName, name),
                                new Tuple<string, string>(VersionName, version ?? "unspecified"),
                                new Tuple<string, string>(RefTypeName, itemType)});
        }
    }
}
