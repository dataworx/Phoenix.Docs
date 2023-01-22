using System.Collections.Generic;

namespace Phoenix.Docs.Domain;

/// <summary>
///   <para>Defines a documentation project. Each project generates a independent single documentation site.</para>
/// </summary>
public class Project
{
    /// <summary>
    /// Gets or sets the friendly name of the project. 
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the short name of the project. This name will be used in the url path to access the documentation site.
    /// </summary>
    /// <value>
    /// The short name.
    /// </value>
    public string ShortName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the default document that will be loaded when the root of the documentation site is requested.
    /// If it is not set the first item in the navigation file will be used.
    /// </summary>
    /// <value>
    /// The index document.
    /// </value>
    public string? IndexDocument { get; set; }

    /// <summary>
    /// Gets or sets the navigation document that contains the structure of the site.
    /// </summary>
    /// <value>
    /// The navigation document.
    /// </value>
    public string NavigationDocument { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the source properties that will be passed to the DocsSource implementation.
    /// </summary>
    /// <remarks>
    /// Here you can store settings that are required by the DocsSource.
    /// </remarks>
    /// <value>
    /// The source properties.
    /// </value>
    public Dictionary<string, string> SourceProperties { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// Gets the temporary files path.
    /// </summary>
    /// <value>
    /// Get the absolute path to the temporary file location
    /// </value>
    public string TempPath { get; internal set; } = string.Empty;

    /// <summary>
    /// Gets the publish files path.
    /// </summary>
    /// <value>
    /// Get the absolute path to the published files location
    /// </value>
    public string PublishPath { get; internal set; } = string.Empty;

    /// <summary>
    /// Gets the URL base path for the projects' docs.
    /// </summary>
    /// <value>
    /// The URL base path.
    /// </value>
    /// <example>
    /// If the PublishFolder is set to /docs and you have a project call Foo, then the url will be /docs/foo.
    /// <code></code></example>
    public string UrlPath { get; internal set; } = string.Empty;
}