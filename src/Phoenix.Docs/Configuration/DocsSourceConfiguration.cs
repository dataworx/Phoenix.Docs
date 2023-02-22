﻿using Phoenix.Docs.Sources;
using System.Collections.Generic;

namespace Phoenix.Docs.Configuration
{
    /// <summary>
    ///   <para>Defines the settings for a documentation.</para>
    /// </summary>
    public class DocsSourceConfiguration
    {
        /// <summary>
        /// The id is used to identity the project during the publishing process.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the source like gitlab, github, etc. This is used to find the appropriate <see cref="IDocsSource" /> implementation.
        /// </summary>
        /// <value>
        /// The type of the source.
        /// </value>
        public string? SourceType { get; set; }

        /// <summary>
        /// Gets or sets the path to the docs' json configuration file.
        /// </summary>
        public string? SettingsFilePath { get; set; }


        /// <summary>
        /// Gets or sets additional properties required by the <see cref="IDocsSource" /> implementation.
        /// </summary>
        /// <value>
        /// The source properties.
        /// </value>
        public Dictionary<string, string> SourceProperties { get; set; } = new Dictionary<string, string>();
    }
}
