using Octokit;
using Phoenix.Docs.Configuration;
using System;
using System.Threading.Tasks;

namespace Phoenix.Docs.DocsSources
{
    internal class GithubDocsSource : IDocsSource
    {
        private readonly GitHubClient client;

        public GithubDocsSource()
        {
            client = new GitHubClient(new ProductHeaderValue("Phoenix.Docs.Client"));
        }

        public Task Configure(Documentation sourceConfiguration)
        {
            return Task.CompletedTask;
        }

        public Task<DocsFile?> GetFile(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
