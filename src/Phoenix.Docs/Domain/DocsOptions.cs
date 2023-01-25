using System.Collections.Generic;

namespace Phoenix.Docs.Domain;

public class DocsOptions
{
    public const string CONFIG_KEY = "Phoenix:Docs";

    /// <summary>
    /// Gets or sets the template that will be used for rendering the documentation.
    /// </summary>
    /// <value>
    /// The template.
    /// </value>
    public string Template { get; set; } = "Default";

    /// <summary>
    /// Gets or sets the folder where the final documentation will be stored. This folder is relative to the wwwroot folder.
    /// </summary>
    /// <value>
    /// The publish folder.
    /// </value>
    public string PublishFolder { get; set; } = "docs";

    /// <summary>
    /// Gets or sets the temporary folder. This folder is relative to the content root folder.
    /// </summary>
    /// <value>
    /// The temporary folder.
    /// </value>
    /// <remarks>
    ///   <para>The documentation files will be downloaded from the documentationstore. They are stored in this folder until everything is completed. Only then will the documentation be published to the publisch folder.</para>
    /// </remarks>
    public string TempFolder { get; set; } = "phoenix-docs-temp";

    /// <summary>
    /// Gets or sets the projects for whose documentations should be generated.
    /// </summary>
    /// <value>
    /// The projects.
    /// </value>
    public ICollection<Project> Projects { get; set; } = new List<Project>();

    /// <summary>
    /// Gets the URL base path for all docs.
    /// </summary>
    /// <value>
    /// The URL base path.
    /// </value>
    /// <example>
    /// If the PublishFolder is set to /docs and you have a project call Foo, then the url will be /docs/foo.
    /// <code></code></example>
    public string UrlBasePath => PublishFolder.Replace("\\", "/");
}