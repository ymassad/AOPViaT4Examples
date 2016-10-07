
namespace Library
{
    using System;
    using System.Threading;

    public class DocumentSourceRetryDecorator : Library.IDocumentSource
    {
        private readonly Library.IDocumentSource decorated;
        private readonly int numberOfRetries;
        private readonly TimeSpan waitTimeBetweenRetries;

        public DocumentSourceRetryDecorator(
            Library.IDocumentSource decorated,
            int numberOfRetries,
            TimeSpan waitTimeBetweenRetries)
        {
            this.decorated = decorated;
            this.numberOfRetries = numberOfRetries;
            this.waitTimeBetweenRetries = waitTimeBetweenRetries;
        }

        public Library.Document[] GetDocuments(System.String format)
        {
            int retries = 0;
        
            while(true)
            {
                try
                {
                    return decorated.GetDocuments(format);
                }
                catch
                {
                    retries++;
        
                    if(retries == numberOfRetries)
                        throw;
        
                    Thread.Sleep(waitTimeBetweenRetries);
                }
            }
        }
        
    }

    public static class ExtensionMethodsForRetryAspectForDocumentSource
    {
        public static Library.IDocumentSource ApplyRetryAspect(this Library.IDocumentSource instance, int numberOfRetries, TimeSpan waitTimeBetweenRetries)
        {
            return new DocumentSourceRetryDecorator(instance, numberOfRetries, waitTimeBetweenRetries);
        }
    }
}
