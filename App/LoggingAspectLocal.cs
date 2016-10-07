
namespace Library
{
    using System;
    using Logging;
    using System.Linq;

    public class DocumentSourceLoggingDecorator : Library.IDocumentSource
    {
        private readonly Library.DocumentSource decorated;
        private readonly ILogger logger;
        private readonly LoggingData[] constantLoggingData;

        public DocumentSourceLoggingDecorator(Library.DocumentSource decorated, ILogger logger, params LoggingData[] constantLoggingData)
        {
            this.decorated = decorated;
            this.logger = logger;
            this.constantLoggingData = constantLoggingData;
        }

        public Library.Document[] GetDocuments(System.String format)
        {
            var preInvocationLoggingData =
                    new LoggingData[]
                    {
                        new LoggingData{ Name = "Method", Value = "Get Documents"},
                        new LoggingData{ Name = "Document Format", Value = format},
                    }
                    .Concat(constantLoggingData)
                    .ToArray();
        
            Library.Document[] returnValue;
        
            try
            {
                returnValue = decorated.GetDocuments(format);	
            }
            catch(Exception ex)
            {
                logger.LogError(preInvocationLoggingData, ex);
                throw;
            }
        
            var returnValueLoggingData = new LoggingData[]
            {
                new LoggingData{ Name = "Return Value", Value = returnValue.Length.ToString()},
            };
        
            logger.LogSuccess(preInvocationLoggingData.Concat(returnValueLoggingData).ToArray());
        
            return returnValue;
        
        }
        
    }

    public static class DocumentSourceExtensionMethodsForLoggingAspect
    {
        public static Library.IDocumentSource AsLoggable(this Library.DocumentSource instance, ILogger logger, params LoggingData[] constantLoggingData)
        {
            return new DocumentSourceLoggingDecorator(instance, logger, constantLoggingData);
        }
    }
}
