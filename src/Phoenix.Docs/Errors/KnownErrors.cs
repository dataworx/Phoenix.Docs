﻿namespace Phoenix.Docs.Errors
{
    public static class KnownErrors
    {
        public static Error Unknown = new Error(ErrorCode.Unknown, "Unknown error occurred while executing.");
        
        public static class Project
        {
            public static Error NotFound = new Error(ErrorCode.NotFound, "The request project was not found.");
        }

        public static class DocsSource
        {
            public static Error SourceNotFound = new Error(ErrorCode.NotFound, "The requested IDocsSource was not found.");
        }
    }
}
