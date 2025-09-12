# GitHub Copilot Instructions

## Prerequisites

This repository requires .NET 9 SDK. If you encounter issues with project creation or building, please ensure .NET 9 SDK is installed on your system and report any setup problems to the user for manual resolution according to your organization's development environment policies.

## .NET Version Requirements

- **Always use .NET 9**: When creating new projects, writing code, or suggesting solutions, always target the latest .NET 9 framework.
- **Target Framework**: Use `net9.0` as the target framework in all project files (.csproj).
- **SDK Version**: Use .NET 9 SDK for all development activities.

= **Documentation**: Documentation is always from Microsoft Learn only.   Use the MCP server to look up information first before implementation.  https://learn.microsoft.com/en-us/dotnet/maui/?view=net-maui-9.0

## Application Architecture Guidelines

- **Structure** TThe application is MVVM and follow the folder guidelines always.

/MyMvvmApp  
│  
├── Models/  
│   └── User.cs  
│   └── Product.cs  
│   └── ...  
│  
├── ViewModels/  
│   └── MainViewModel.cs  
│   └── UserViewModel.cs  
│   └── ProductViewModel.cs  
│   └── ...  
│  
├── Views/  
│   └── MainView.xaml  
│   └── UserView.xaml  
│   └── ProductView.xaml  
│   └── ...  
│  
├── Services/  
│   └── IDataService.cs  
│   └── DataService.cs  
│   └── NavigationService.cs  
│   └── ...  
│  
├── Helpers/  
│   └── ValidationHelper.cs  
│   └── ...  
│  
├── Tests/  
│   └── ViewModelTests.cs  
│   └── ServiceTests.cs  
│   └── ...  
  
└── README.md  

- **Framework** Always use CommunityToolkit.Mvvm

ViewModel Commands must always use AsyncRelayCommand
Models and ViewModels are always inheriting fdrom ObservableObject

## Code Quality Requirements

- **Standards**:  You MUST study the existing codebase to understand the architecture and design patterns used.
- **Compilation**: Ensure all code suggestions and generated code compile successfully.
- **Build Verification**: Code must build without errors before being considered complete.
- **Best Practices**: Follow .NET 9 best practices and latest language features.

## Project Setup Guidelines

When creating new .NET projects:
1. Use `dotnet new` commands with .NET 9 templates
2. Verify the target framework is set to `net9.0`
3. Test compilation with `dotnet build` before finalizing
4. Use the latest C# language version supported by .NET 9


## Additional Notes

- Prioritize .NET 9 specific features and APIs when available
- Suggest migration paths from older .NET versions to .NET 9 when appropriate
- Ensure compatibility with .NET 9 runtime and libraries