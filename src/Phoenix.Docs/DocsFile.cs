namespace Phoenix.Docs
{
    public class DocsFile
    {
        public string Filename { get; set; }

        public string FullPath { get; set; }

        public string Encoding { get; set; }

        public byte[] Content { get; set; }
    }
}
