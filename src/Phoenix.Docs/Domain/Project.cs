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
    /// Gets or sets the template that will be used for rendering the documentation.
    /// </summary>
    /// <value>
    /// The template.
    /// </value>
    public string Template { get; set; } = "Default";

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

    public ICollection<MenuItem> Navigation { get; set; }
}