# BuildSdk
BuildSdk is a custom build sdk for dotnet sdk style projects.

## NugetSdk
Standardizes build props and versioning. It automaticly generates nuget packages for release/debug with automatic versioning for debug. After a successful build the nuget package is published to a local or public nuget-feed.

## AppSdk
Standardizes build props and versioning. It automaticly create development and release config files.

## LibrarySdk
Standardizes build props and versioning.

## How to use

### Local Nuget Source
* Download the nuget package
* Add download path as nuget source
* Reference the package in your project

### Remote Nuget-Source

Add remote nuget source to your nuget.config:

* {Token}: Z2hwX1hybmFLaVIyTm1zaGVWRVpqMjVLbHZsNTBjdldKYjMzQ2hPeQ== -> Convert Base64 back to Text First
* Execute: dotnet nuget add source --username byCrookie --password {Token} --name byCrookie_Github --store-password-in-clear-text https://nuget.pkg.github.com/byCrookie/index.json

### Dev

* Clone the git repository
* Change the "localPackages" path in the nuget.config

## Contributing / Issues
All contributions are welcome! If you have any issues or feature requests, either implement it yourself or create an issue, thank you.

## Donation
If you like this project, feel free to donate and support further development. Thank you.

* Bitcoin (BTC) Donations using Bitcoin (BTC) Network -> bc1qygqya2w3hgpvy8hupctfkv5x06l69ydq4su2e2
* Ethereum (ETH) Donations using Ethereum (ETH) Network -> 0x1C0416cC1DDaAEEb3017D4b8Dcd3f0B82f4d94C1

## Docs
BuildSdk makes it very easy to have an full-fleged build flow. BuildSdk nuget-packages have to be added to a project in order to work.

### Configuration

You can customize the build process using a Directory.Build.props file.

```xml
<Project>
    <PropertyGroup>
        <MajorVersion>1</MajorVersion>
        <MinorVersion>0</MinorVersion>
        <PatchVersion>29</PatchVersion>
    </PropertyGroup>

    <PropertyGroup>
        <TargetFramework>net6.0</TargetFramework>
        <ImplicitUsings>enable</ImplicitUsings>
        <Nullable>enable</Nullable>
        <LangVersion>10</LangVersion>

        <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
    </PropertyGroup>
</Project>
```
