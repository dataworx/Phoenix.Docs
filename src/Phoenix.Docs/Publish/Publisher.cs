using Microsoft.Extensions.Options;
using Phoenix.Docs.Configuration;
using Phoenix.Docs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phoenix.Docs.Publish
{
    public class Publisher : IPublisher
    {
        #region Fields

        private readonly DocsConfiguration configuration;
        private readonly IDocsSourceFactory sourceFactory;

        #endregion

        #region Constructors

        public Publisher(IOptions<DocsConfiguration> configuration, IDocsSourceFactory sourceFactory)
        {
            this.configuration = configuration.Value;
            this.sourceFactory = sourceFactory;
        }

        #endregion

        public async Task<Result> Publish(string? id)
        {
            var docsToPublish = this.GetDocsToPublish(id);

            if (!docsToPublish.Any())
            {
                var result = Result.Fail("No documentation configuration(s) found");
            }

            foreach (var documentation in docsToPublish)
            {
                var docsSource = await sourceFactory.Create(documentation);    
            }


            //if (docsSource == null)
            //{
            //    return Result<string>.Fail(KnownErrors.DocsSource.SourceNotFound);
            //}

            // Download config file from repo
            // Enrich config with path information and store
            // Download all content files (.md) referenced in the config file navigation section
            // Parse files for linked content
            // Download linked content
            // Publish 
            return Result.Ok();
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