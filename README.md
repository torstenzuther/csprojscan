# CsprojScan

CsprojScan crawls folders for csproj files and extracts all project references, package references and direct references to one pivot grid / CSV.
Its main purpose is to detect different package versions over more than one .sln.

# Usage

`CsprojScan.Console.exe <search-paths> [<search-pattern>]`

**<search-paths>** is the start search path. Multiple paths can be separated by ; (no whitespaces allowed)

optional **<search-pattern>** (defaults to *.csproj)}

CsprojScan scans all given search paths using the search pattern and exports all found referenceses to a file in CSV format. 
It also generates a html file containing the pivottable.js library from https://pivottable.js.org/. The html uses the CSV file as its data source.

![Pivot table](csprojscan.png)