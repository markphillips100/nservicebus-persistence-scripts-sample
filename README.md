Sample solution to demonstrate NServiceBus.Persistence.Sql behaviour when using NuGet packages

## Building the sample

The solution expects samplelib2 to be deployed as a package which is referenced by sampleapp.  To facilitate this do the following:

1. Clone the repository
2. Create a folder at root of local repository called "sample-packages".
3. Open a terminal and change directory to the `<repository-folder>\src\samplelib2`.
4. Run `dotnet build`.  NOTE: This will build the samplelib2 package and create its package.
5. Run `nuget add bin\Debug\samplelib2.1.0.0.nupkg -expand -source ..\..\sample-packages`.
6. Change directory to the root folder of the repository.
6. Run `dotnet build`.


## Observations

1. All projects are referencing NServiceBus.Persistence.Sql.
2. Both library projects' bin and obj folders contain their respective saga sql scripts (located in the subfolder \Debug\NServiceBus.Persistence.Sql\MsSqlServer\Sagas).
3. The sampleapp's bin folder only contains saga scripts for samplelib (the ProjectReference'd project) and nothing for samplelib 2 (the PackageReference'd project).

## Expectations

Expected saga scripts for all reference projects to be available in bin folder of application, whether referenced via ProjectReference or PackageReference.
