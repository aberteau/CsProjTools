# CsProjTools
Some tools for Visual Studio csproj files.
## CsProjInspector
The CsProjInspector scans a tree in search of csproj, extracts some information and generates an excel file.
This excel file (xlsx format) contains 2 sheets:
* OutputPaths: OutputPath per project and configuration. It contains columns for the project information (name, full path) and one column per configuration found.
* References: References by project (ProjectReferences are not included). It contains columns for the project information (name, full path) and references (SpecificVersion, Private, HintPath, AbsolutePath)

The console application (CsProjInspector.ConsoleApp) is not usable on their own and it is better to run them in Visual Studio to be able to modify the execution parameters in the code (path of csproj, doc generation path, ...)

The required parameters are:
* The path to the tree containing the csproj files to inspect
* The excel output file path

## Getting Started
### Prerequisites

Visual Studio

## Authors

* **Amael BERTEAU**

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
