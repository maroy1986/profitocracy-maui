# .NET 10.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that an .NET 10.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 10.0 upgrade.
3. Upgrade src/Profitocracy.Core/Profitocracy.Core.csproj
4. Upgrade src/Profitocracy.Infrastructure/Profitocracy.Infrastructure.csproj
5. Upgrade test/Profitocracy.Infrastructure.Tests/Profitocracy.Infrastructure.Tests.csproj
6. Upgrade test/Profitocracy.Core.Tests/Profitocracy.Core.Tests.csproj
7. Upgrade src/Profitocracy.Mobile/Profitocracy.Mobile.csproj


## Settings

This section contains settings and data used by execution steps.

### Excluded projects

Table below contains projects that do belong to the dependency graph for selected projects and should not be included in the upgrade.

| Project name                                   | Description                 |
|:-----------------------------------------------|:---------------------------:|


### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                                   | Current Version | New Version | Description                                   |
|:-----------------------------------------------|:---------------:|:-----------:|:----------------------------------------------|
| Microsoft.Extensions.DependencyInjection       |   9.0.7         |  10.0.0     | Recommended update to match .NET 10.0         |
| Microsoft.Extensions.DependencyInjection.Abstractions |   9.0.7 |  10.0.0     | Recommended update to match .NET 10.0         |
| Microsoft.Extensions.Logging.Debug             |   9.0.7         |  10.0.0     | Recommended update to match .NET 10.0         |
| Xamarin.AndroidX.Work.Runtime                  |   2.10.2        |             | Incompatible with target frameworks; no supported version found (remove or replace) |


### Project upgrade details
This section contains details about each project upgrade and modifications that need to be done in the project.

#### src/Profitocracy.Core/Profitocracy.Core.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net10.0`

NuGet packages changes:
  - `Microsoft.Extensions.DependencyInjection.Abstractions` should be updated from `9.0.7` to `10.0.0` (recommended for .NET 10.0)

Feature upgrades:
  - None detected beyond target framework and package updates.

Other changes:
  - Review APIs used from updated Microsoft.Extensions.* packages for any breaking changes after package update.

#### src/Profitocracy.Infrastructure/Profitocracy.Infrastructure.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net10.0`

NuGet packages changes:
  - No package changes were recommended specifically for this project by analysis, but verify transitive dependencies after other package updates.

Feature upgrades:
  - None detected.

Other changes:
  - Run full build and tests after framework update to identify API breaking changes.

#### test/Profitocracy.Infrastructure.Tests/Profitocracy.Infrastructure.Tests.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net10.0`

NuGet packages changes:
  - No package changes were recommended specifically for this project by analysis.

Feature upgrades:
  - Ensure test SDK and test runner are compatible with .NET 10.0.

Other changes:
  - Update test project's package references if test run failures indicate incompatible packages.

#### test/Profitocracy.Core.Tests/Profitocracy.Core.Tests.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net10.0`

NuGet packages changes:
  - `Microsoft.Extensions.DependencyInjection` should be updated from `9.0.7` to `10.0.0` (recommended for .NET 10.0)

Feature upgrades:
  - Ensure test SDK and test runner are compatible with .NET 10.0.

Other changes:
  - Run tests and address API changes after package updates.

#### src/Profitocracy.Mobile/Profitocracy.Mobile.csproj modifications

Project properties changes:
  - Target frameworks should be changed from `net9.0-android;net9.0-ios` to `net10.0-ios;net10.0-android`

NuGet packages changes:
  - `Microsoft.Extensions.Logging.Debug` should be updated from `9.0.7` to `10.0.0` (recommended for .NET 10.0)
  - `Xamarin.AndroidX.Work.Runtime` version `2.10.2` is incompatible and there is no supported version found for the target; plan to remove or replace this package. Investigate replacement packages or update mobile code to avoid dependency.

Feature upgrades:
  - Mobile project is a .NET MAUI project; ensure MAUI workloads for .NET 10.0 are available and verify Android/iOS specific compatibility.

Other changes:
  - Update Android/iOS workload targets and test on device/emulator after the upgrade.


