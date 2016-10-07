namespace Library
{
    public interface IDocumentSource
    {
        Document[] GetDocuments(string format);
    }
}