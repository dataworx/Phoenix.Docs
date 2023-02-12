using System.Collections.Generic;

namespace Phoenix.Docs.Extensions
{
    public static class QueueExtensions
    {
        public static void EnqueueRange<T>(this Queue<T> source, IEnumerable<T> itemsToEnqueue)
        {
            foreach (var item in itemsToEnqueue)
            {
                if (!source.Contains(item))
                {
                    source.Enqueue(item);
                }
            }
        }
    }

}
