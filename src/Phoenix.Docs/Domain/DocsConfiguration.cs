using System.Collections.Generic;

namespace Phoenix.Docs.Domain;

public class DocsConfiguration
{
    public const string CONFIG_KEY = "Phoenix:Docs";

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
    ///   <para>The documentation files will be downloaded from the <see cref="IDocsSource"/>. They are stored in this folder until everything is completed. Only then will the documentation be published to the publisch folder.</para>
    /// </remarks>
    public string TempFolder { get; set; } = "phoenix-docs-temp";

    /// <summary>
    /// Gets or sets the documentation source for projects for whose documentations should be generated.
    /// </summary>
    /// <value>
    /// The projects.
    /// </value>
    public ICollection<ProjectSourceConfiguration> Sources { get; set; } = new List<ProjectSourceConfiguration>();

    public string UrlBasePath => PublishFolder.Replace("\\", "/");
}