using Microsoft.Extensions.Options;
using Phoenix.Docs.Configuration;
using Phoenix.Docs.Extensions;
using Phoenix.Docs.Sources;
using Phoenix.Docs.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Phoenix.Docs.Publish
{
    public class Publisher : IPublisher
    {
        #region Fields

        private readonly DocsConfiguration configuration;
        private readonly IDocsSourceFactory sourceFactory;
        private readonly IDocsStore docsStore;
        private readonly IConfigurationSerializer serializer;

        #endregion

        #region Constructors

        public Publisher(IOptions<DocsConfiguration> configuration, IDocsSourceFactory sourceFactory, IDocsStore docsStore, IConfigurationSerializer serializer)
        {
            this.configuration = configuration.Value;
            this.sourceFactory = sourceFactory;
            this.docsStore = docsStore;
            this.serializer = serializer;
        }

        #endregion

        public async Task<Result> Publish(string? id)
        {
            var errors = new List<string>();

            var sourceConfigurations = this.GetDocSources(id);

            if (!sourceConfigurations.Any())
            {
                var result = Result.Fail("No documentation configuration(s) found");
            }

            foreach (var documentation in sourceConfigurations)
            {
                var downloadQueue = new Queue<string>();

                // Create documentation source
                var docsSource = await sourceFactory.Create(documentation);
                if (docsSource == null) 
                {
                    errors.Add($"{documentation.Id}: No DocsSource found for SourceType: {documentation.SourceType}");
                    continue;
                }

                // Download configuration file from source
                var configurationFile = await docsSource.GetFile(documentation.ConfigurationFilePath);
                if (configurationFile == null)
                {
                    errors.Add($"{documentation.Id} - Could not load configuration file: {documentation.ConfigurationFilePath}");
                    continue;
                }

                // Parse configuration
                var projectConfiguration = this.ParseConfiguration(configurationFile);
                await this.docsStore.SaveTempFile(documentation, projectConfiguration, configurationFile);

                // Get linked file from menu in the configuration
                var linkedFilesFromNavigation = this.GetLinkedNaviationFiles(projectConfiguration.MenuItems);
                downloadQueue.EnqueueRange(linkedFilesFromNavigation.Select(x => x.Path));

                while (downloadQueue.Any())
                {
                    // Download each file and parse files for other linked files and download them too
                    var nextFile = downloadQueue.Dequeue();

                    try
                    {
                        var file = await docsSource.GetFile(nextFile);
                        if (file == null)
                        {
                            errors.Add($"{documentation.Id} - File not found: {nextFile}");
                            continue;
                        }

                        await this.docsStore.SaveTempFile(documentation, projectConfiguration, file);

                        if (Path.GetExtension(file.Filename).ToLower() == ".md")
                        {
                            downloadQueue.EnqueueRange(this.GetDocumentLinks(file));
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }

                await this.docsStore.Publish(documentation, projectConfiguration);
            }

            return Result.Ok();
        }

        private IEnumerable<MenuItem> GetLinkedNaviationFiles(IEnumerable<MenuItem> menuItems)
        {
            var items = menuItems.ToList();
            var result = new List<MenuItem>();

            foreach (var item in items)
            {
                if (!string.IsNullOrWhiteSpace(item.Path))
                {
                    result.Add(item);
                }

                if (item.Children.Any())
                {
                    result.AddRange(GetLinkedNaviationFiles(item.Children));
                }
            }

            return result.ToList();

        }

        private ProjectConfiguration ParseConfiguration(DocsFile configurationFile)
        {
            var content = Encoding.UTF8.GetString(configurationFile.Content);
            var projectConfiguration = this.serializer.Deserialize<ProjectConfiguration>(content);
            return projectConfiguration;
        }

        private IEnumerable<string> GetDocumentLinks(DocsFile file)
        {
            var links = new List<string>();

            if (!Path.GetExtension(file.Filename).Equals(".md"))
            {
                return links;
            }

            var content = Encoding.UTF8.GetString(file.Content);

            const string regexMdLinks = @"\[(?<title>[^\[]+)\](\((?<path>.*)\))";
            foreach (Match match in Regex.Matches(content, regexMdLinks))
            {
                links.Add(match.Groups["path"].Value);
            }

            return links;
        }

        private IEnumerable<DocsSourceConfiguration> GetDocSources(string? id)
        {
            var docsToPublish = new List<DocsSourceConfiguration>();
            if (!string.IsNullOrWhiteSpace(id))
            {
                var doc = configuration.SourceConfigurations
                    .SingleOrDefault(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));

                if (doc != null)
                {
                    docsToPublish.Add(doc);
                }
            }
            else
            {
                docsToPublish.AddRange(configuration.SourceConfigurations);
            }

            return docsToPublish;
        }
    }
}