using Microsoft.Extensions.Options;
using Phoenix.Docs.Configuration;
using Phoenix.Docs.DocsSources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Phoenix.Docs.Publish
{
    public class Publisher : IPublisher
    {
        #region Fields

        private readonly DocsConfiguration configuration;
        private readonly IDocsSourceFactory sourceFactory;
        private readonly IDocsStorage docsStorage;
        private readonly IConfigurationSerializer serializer;

        #endregion

        #region Constructors

        public Publisher(IOptions<DocsConfiguration> configuration, IDocsSourceFactory sourceFactory, IDocsStorage docsStorage, IConfigurationSerializer serializer)
        {
            this.configuration = configuration.Value;
            this.sourceFactory = sourceFactory;
            this.docsStorage = docsStorage;
            this.serializer = serializer;
        }

        #endregion

        public async Task<Result> Publish(string? id)
        {
            var errors = new List<string>();

            var docsToPublish = this.GetDocsToPublish(id);

            if (!docsToPublish.Any())
            {
                var result = Result.Fail("No documentation configuration(s) found");
            }

            foreach (var documentation in docsToPublish)
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
                //var projectConfiguration = await this.ParseConfiguration(configuration);

                //await this.docsStorage.SaveTempFile(documentation, projectConfiguration, configurationFile);

                // Get linked file from menu in the configuration
                //var linkedFilesFromNavigation = this.GetLinkedNaviationFiles(projectConfiguration);
                //downloadQueue.EnqueueRange(pendingDocsFiles.Select(x => x.Path));

                while (downloadQueue.Any())
                {
                    // Download each file and parse files for other linked files and download them too
                    var nextFile = downloadQueue.Dequeue();

                    try
                    {
                        var file = await docsSource.GetFile(nextFile);
                        if (file == null)
                        {
                            continue;
                        }

                        //await this.docsStorage.SaveTempFile(documentation, projectConfiguration, file);

                        if (Path.GetExtension(file.Filename).ToLower() == ".md")
                        {
                            //downloadQueue.EnqueueRange(this.GetDocumentLinks(document.ContentDecoded));
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }

                //await this.docsStorage.Publish(documentation, projectConfiguration);
            }

            return Result.Ok();
        }

        //private object GetLinkedNaviationFiles(object projectConfiguration)
        //{
        //    var items = source.ToList();
        //    var result = new List<NavigationItem>();

        //    foreach (var item in items)
        //    {
        //        if (!string.IsNullOrWhiteSpace(item.Path))
        //        {
        //            result.Add(item);
        //        }

        //        if (item.Children.Any())
        //        {
        //            result.AddRange(GetPendingDocsFiles(item.Children));
        //        }
        //    }

        //    return result.ToList();

        //}

        //private Project ParseConfiguration(DocsConfiguration configuration)
        //{
        //    var docsConfiguration = this.serializer.Deserialize<Project>(navigationDocument.ContentDecoded);
        //}

        private IEnumerable<string> GetDocumentLinks(string content)
        {
            const string regexMdLinks = @"\[(?<title>[^\[]+)\](\((?<path>.*)\))";
            foreach (Match match in Regex.Matches(content, regexMdLinks))
            {
                yield return match.Groups["path"].Value;
            }
        }

        private IEnumerable<Documentation> GetDocsToPublish(string? id)
        {
            var docsToPublish = new List<Documentation>();
            if (!string.IsNullOrWhiteSpace(id))
            {
                var doc = configuration.Documentations
                    .SingleOrDefault(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));

                if (doc != null)
                {
                    docsToPublish.Add(doc);
                }
            }
            else
            {
                docsToPublish.AddRange(configuration.Documentations);
            }

            return docsToPublish;
        }
    }
}