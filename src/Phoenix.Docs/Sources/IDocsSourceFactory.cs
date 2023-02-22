﻿using Phoenix.Docs.Configuration;
using System.Threading.Tasks;

namespace Phoenix.Docs.Sources
{
    public interface IDocsSourceFactory
    {
        Task<IDocsSource?> Create(DocsSourceConfiguration docsSourceConfiguration);
    }
}