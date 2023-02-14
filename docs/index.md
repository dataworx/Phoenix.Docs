# Phoenix.Docs Documentation

The goal of Phoenix.Docs is to provide an easy and convenient way to publish your project documentation. 

The most annoying but not the least important part of any project is providing comprehensive documentation. Even if you have 
well-written documentation, it needs to be published in a form that customers can easily use. Otherwise it becomes useless. 
This is where Phoenix.Docs comes into play. 

The main purpose is to publish the documentation and provide additional functionality for the users. This should be possible without 
hindering you in creating the documentation. There are only two requirements. 
Write your documentation in Markdown and create a single simple configuration file.

The process of making your documentation available to users consists of two stages, Publish and Server.

### Publish

The publish stage downloads the source files (Configuration, Markdown, Content) from 
the source (github, gitlab, etc.) using a `IDocsSource` implementation. The downloaded markdown files are
converted to html. When all files a downloaded and processed they will be stored in the configured publish location.

### Serve

The published files are not served directly. You have to provide a Razor Page or Mvc View supported by designated services 
to render (serve) the documentation.

Next step: [Configuration](configuration.md)
