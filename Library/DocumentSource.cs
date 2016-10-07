using System.Linq;
using LoggingAOP;

namespace Library
{
    public class DocumentSource : IDocumentSource
    {
        [return: LogCount]
        [MethodDescription("Get Documents")]
        public Document[] GetDocuments([Log("Document Format")] string format)
        {
            return
                Enumerable
                    .Range(0, 10)
                    .Select(x => new Document("document" + x, "content" + x))
                    .ToArray();
        }
    }
}