# LoaderExceptionsRepro
This program reproduces [issue #2060](https://github.com/Azure/azure-webjobs-sdk/issues/2060) from the Azure Webjobs SDK.
## Steps to reproduce:
1. Using Visual Studio 2019, create a new console app, using the .net framework template.
2. Install the latest version of the Microsoft.Azure.WebJobs nuget package (3.0.16.0 at this time).
3. Install the latest version of the Microsoft.Extensions.Logging.Console package (3.1.3 at this time).
4. Install the latest version of the Microsoft.Azure.WebJobs.Extensions.Storage package (3.0.10 at this time).
5. Add a Functions.cs file, and add a dummy function inside it, using the `[NoAutomaticTrigger]` attribute.
6. In the Main method, create a HostBuilder, configure the logging and webjobs, and run the program.
## The problem:
The application runs fine, but on startup we get some warnings in the console about finding partial types from the assembly `Microsoft.Azure.WebJobs.Extensions.Storage`

    warn: Host.Startup[0]
      Warning: Only got partial types from assembly: Microsoft.Azure.WebJobs.Extensions.Storage, Version=3.0.10.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
      The following loader failures occured when trying to load the assembly:
         - Method 'Commit' in type 'Microsoft.Azure.WebJobs.Host.Blobs.Bindings.DelegatingCloudBlobStream' from assembly 'Microsoft.Azure.WebJobs.Extensions.Storage, Version=3.0.10.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35' does not have an implementation.
         - Method 'Commit' in type 'Microsoft.Azure.WebJobs.Host.Blobs.Bindings.DelegatingCloudBlobStream' from assembly 'Microsoft.Azure.WebJobs.Extensions.Storage, Version=3.0.10.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35' does not have an implementation.
         - Method 'Commit' in type 'Microsoft.Azure.WebJobs.Host.Blobs.Bindings.DelegatingCloudBlobStream' from assembly 'Microsoft.Azure.WebJobs.Extensions.Storage, Version=3.0.10.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35' does not have an implementation.
         - Method 'Commit' in type 'Microsoft.Azure.WebJobs.Host.Blobs.Bindings.DelegatingCloudBlobStream' from assembly 'Microsoft.Azure.WebJobs.Extensions.Storage, Version=3.0.10.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35' does not have an implementation.
         - Could not load type 'Microsoft.WindowsAzure.Storage.Table.TableQuerySegment' from assembly 'Microsoft.WindowsAzure.Storage, Version=9.3.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
      This can occur if the assemblies listed above are missing, outdated or mismatched.
      Exception message: System.Reflection.ReflectionTypeLoadException: Unable to load one or more of the requested types. Retrieve the LoaderExceptions property for more information.
         at System.Reflection.RuntimeModule.GetTypes(RuntimeModule module)
         at System.Reflection.RuntimeModule.GetTypes()
         at System.Reflection.Assembly.GetTypes()
         at Microsoft.Azure.WebJobs.Host.Indexers.DefaultTypeLocator.FindTypes(Assembly assembly, IEnumerable`1 extensionAssemblies) in C:\projects\azure-webjobs-sdk-rqm4t\src\Microsoft.Azure.WebJobs.Host\Indexers\DefaultTypeLocator.cs:line 115
