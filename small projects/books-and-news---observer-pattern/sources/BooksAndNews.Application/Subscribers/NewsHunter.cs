using RemoteLearning.BooksAndNews.Application.Publications;
using RemoteLearning.BooksAndNews.Application.Publishers;

namespace RemoteLearning.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever news
    /// are printed.
    ///
    /// Subscribe to the printing office and log each news that was printed.
    /// </summary>
    public class NewsHunter
    {
        public string name;
        public ILog log;
        public NewsHunter(string name, PrintingOffice printingOffice, ILog log)
        {
            this.name = name;
            this.log = log;
            printingOffice.NewNewspaperPrintedEvent += HandleNewspaperPrinted;
        }

        private void HandleNewspaperPrinted(Newspaper newspaper)
        {
            log.WriteInfo($"Dear {name}! ~Newspaper '{newspaper.Title}'-{newspaper.Number} has been printed!");
        }
    }
}