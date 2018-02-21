# CsprojScan

CsprojScan scans folders for csproj files and extracts all project references, package references and references (directly referenced DLLs).
It exports the references to a CSV file to be visualized in an HTML pivot grid. It allows for simple analysis of all references / nuget packages over different solutions which is very useful when you have many different solutions sharing packages and / or references you want to compare.

# Usage

`CsprojScan.Console.exe <search-paths> <export-file> [<search-pattern>]`
**<search-paths>** is the start search path. Multiple paths can be separated by ; (no whitespaces allowed)
**<export-file>** is the file name to export to (will be overwritten)
optional **<search-pattern>** (defaults to *.csproj)}

CsprojScan then scans all given search paths by using the given search pattern and exports the results to the given export file in CSV format. It also generates a html file using the pivottable.js library from https://pivottable.js.org/ and opens it. The pivot table html is configured to load the generated CSV file. The name of the pivot html is auto generated and follows the pattern **<CSV-filename>_<Ticks>.html**

