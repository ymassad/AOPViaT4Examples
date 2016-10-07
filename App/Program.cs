using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Logging;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var documentSource =
                new DocumentSource()
                    .AsLoggable(
                        new ConsoleLogger(),
                        new LoggingData { Name = "Department", Value = "A" })
                    .ApplyRetryAspect(
                        numberOfRetries: 3,
                        waitTimeBetweenRetries: TimeSpan.FromSeconds(5));

            var result = documentSource.GetDocuments("docx");

            Console.ReadLine();
        }
    }
}
