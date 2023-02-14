# Phoenix.Docs Documentation

The goal of Phoenix.Docs is to provide an easy and convenient way to publish your project documentation. 

The most annoying but not the least important part of any project is providing comprehensive documentation. Even if you have 
well-written documentation, it needs to be published in a form that customers can easily use. Otherwise it becomes useless. 
This is where Phoenix.Docs comes into play. 

The main purpose is to publish the documentation and provide additional functionality for the users. This should be possible without 
hindering you in creating the documentation. There are only two requirements. 
Write your documentation in Markdown and create a single simple configuration file.

## Overview

The process of making your documentation available to users consists of two stages, Publish and Server.

### Publish

The publish stage downloads the source files (Configuration, Markdown, Content) from 
the source (github, gitlab, etc.) using a `IDocsSource` implementation. The downloaded markdown files are
converted to html. When all files a downloaded and processed they will be stored in the configured publish location.

### Serve

The published files are not served directly. You have to provide a Razor Page or Mvc View supported by designated services 
to render (serve) the documentation.

Next step: [Configuration](configuration.md)

## Configuration

### Server side configuration

The server side needs some basic configuration to be able to fetch and publish your documentations. This configuration 
is stored in the appsettings file. 

#### Configuration Settings

##### General

|Name|Description|
|---|---|
|**TempFolder**|During the publish process the files downloaded from the source are stored in this temporary folder. This folder is relative to the [IHostEnvironment.ContentRootPath](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostenvironment.contentrootpath?view=dotnet-plat-ext-7.0#microsoft-extensions-hosting-ihostenvironment-contentrootpath). |
|**PublishFolder**|This is the public folder where all processed files are store. This folder is relative to the [IWebHostEnvironment.WebRootPath](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostenvironment.contentrootpath?view=dotnet-plat-ext-7.0#microsoft-extensions-hosting-ihostenvironment-contentrootpath).|
|**Documentations**|Individual configuration settings for each documentation that should be published|

##### Documentation
|Name|Description|
|---|---|
|**Id**|Unique Id of the documentation setting|
|**SourceType**|The type of the source like gitlab, github, etc. This is used to find the appropriate `IDocsSource` implementation|
|**ConfigurationFilePath**|The path to the documentation configuration file within the source.|
|**SourceProperties**|Custom settings for the given SourceType as key value pairs|

##### Example configuration file

```json
{
  "Phoenix": {
    "Docs": {
      "TempFolder": "Temp_Data\\docs\\",
      "PublishFolder": "docs",
      "Documentations": [
        {
          "Id": "1",
          "SourceType": "github",
          "ConfigurationFilePath": "docs/phoenix.docs.project.yml",
          "SourceProperties": {
            "BaseUrl": "",
            "Branch": "",
            "RepositoryName": ""
          }
        }
      ]
    }
  }
}

```

## tbd...

- Document the config file format
- Document the source providers
- Create a roadmap
- Add a changelog as part of the documentation
