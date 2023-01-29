using System.Collections.Generic;

namespace Phoenix.Docs.Domain
{
    public class MenuItem
    {
        public string Text { get; set; }

        public string Path { get; set; }

        public ICollection<MenuItem> Children { get; set; } = new List<MenuItem>();
        
        public bool IsLink => !string.IsNullOrWhiteSpace(Path);

        public bool HasChildren => Children.Count > 0;
        
        public string Url { get; internal set; }
        
        public bool IsActive { get; internal set; }
    }
}
