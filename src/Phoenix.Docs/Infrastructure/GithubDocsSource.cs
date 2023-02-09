using Phoenix.Docs.Domain;
using System;
using System.Threading.Tasks;
using Octokit;
using Phoenix.Docs.Configuration;

namespace Phoenix.Docs.Infrastructure
{
    internal class GithubDocsSource : IDocsSource
    {
        private readonly GitHubClient client;

        public GithubDocsSource()
        {
            this.client = new Octokit.GitHubClient(new ProductHeaderValue("Phoenix.Docs.Client"));
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
