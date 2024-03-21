using RemoteLearning.BooksAndNews.Application.Publishers;
using RemoteLearning.BooksAndNews.Application.Publications;

namespace RemoteLearning.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever a book
    /// is printed.
    ///
    /// Subscribe to the printing office and log each book that was printed.
    /// </summary>
    public class BookLover
    {
        public string name;
        public ILog log;
        public BookLover(string name, PrintingOffice printingOffice, ILog log)
        {
            this.name = name;
            this.log = log;
            printingOffice.NewBookPrintedEvent += HandleBookPrinted;
        }

        private void HandleBookPrinted(Book book)
        {
            log.WriteInfo($"Dear {name}! ~Book '{book.Title}' by {book.Author}-{book.Year} has just been printed!");
        }
    }
}