# CsprojScan

CsprojScan scans folders for csproj files and extracts all project references, package references and references (directly referenced DLLs).
It then exports those to a CSV to be visualized in an HTML pivot grid. It allows for simple analysis of all references / nuget packages over different solutions
which is very useful when you have many different solutions sharing common software libraries like in a microservice architecture.

# Usage

`CsprojScan.Console.exe <search-paths> <export-file> [<search-pattern>]"
* <search-paths> is the start search path. Multiple paths can be separated by ; (no whitespaces allowed)"
* <export-file> is the file name to export to (will be overwritten)"
* optional <search-pattern> (defaults to *.csproj)"}