# BuildSdk
BuildSdk is a custom build sdk for msbuild. It automaticly generates nuget packages for release/debug with automatic versioning for debug. After a successful build the nuget package is published to a local or public nuget-feed.

## How to use

### Local Nuget Source
* Download the nuget package
* Add download path as nuget source
* Reference the package in your project

### Remote Nuget-Source

Add the following remote nuget source to your nuget.config file.

```xml
<configuration>

  <packageSources>
    <add key="github" value="https://nuget.pkg.github.com/byCrookie/index.json" />
  </packageSources>

  <packageSourceCredentials>
    <github>
      <add key="Username" value="byCrookie" />
      <add key="ClearTextPassword" value="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" />
    </github>
  </packageSourceCredentials>

</configuration>
```

### Dev

* Clone the git repository
* Change the "localPackages" path in the nuget.config

## Contributing / Issues
All contributions are welcome! If you have any issues or feature requests, either implement it yourself or create an issue, thank you.

## Donation
If you like this project, feel free to donate and support the further development. Thank you.

Bitcoin (BTC) Donations using Bitcoin (BTC) Network -> 14vZ2rRTEWXhvfLrxSboTN15k5XuRL1AHq 

## Docs
BuildSdk makes it very easy to have a local or public prerelease flow. It generates automatic prerelase versions for packages. The BuildSdk nuget-package has to be added to a project. That is everything needed.

### Configuration

You can customize the build process using a Directory.Build.props file.

```xml
<Project>
    <PropertyGroup>
        <GeneratePackageOnBuild>true</GeneratePackageOnBuild>
        <PublishPackage>true</PublishPackage>
        <PackagePublishType>local</PackagePublishType>
        <PackagePublishLocalLocation>M:\Development\Nuget\Packages</PackagePublishLocalLocation>
        <VersionPrefix>1.0.3</VersionPrefix>
    </PropertyGroup>
</Project>
```