using Phoenix.Docs.Configuration;
using System;
using System.Threading.Tasks;

namespace Phoenix.Docs.Publish
{
    public class IDocsStorage
    {
        internal Task Publish(Documentation documentation, object projectConfiguration)
        {
            throw new NotImplementedException();
        }

        internal Task SaveTempFile(Documentation documentation, object projectConfiguration, DocsFile? configurationFile)
        {
            throw new NotImplementedException();
        }
    }
}
