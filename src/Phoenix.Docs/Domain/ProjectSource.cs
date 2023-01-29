using System.Collections.Generic;

namespace Phoenix.Docs.Domain
{
    /// <summary>
    ///   <para>Defines the source settings of a documentation project.</para>
    /// </summary>
    public class ProjectSource
    {
        /// <summary>
        /// Gets or sets the type of the source like gitlab, github, etc. This is used to find the appropriate <see cref="IDocsSource" /> implementation.
        /// </summary>
        /// <value>
        /// The type of the source.
        /// </value>
        public string? SourceType { get; set; }


        /// <summary>
        /// Gets or sets additional properties required by the <see cref="IDocsSource" /> implementation.
        /// </summary>
        /// <value>
        /// The source properties.
        /// </value>
        public Dictionary<string, string> SourceProperties { get; set; } = new Dictionary<string, string>();
    }
}
