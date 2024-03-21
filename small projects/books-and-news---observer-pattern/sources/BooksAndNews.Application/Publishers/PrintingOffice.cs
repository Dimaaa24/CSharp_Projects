using RemoteLearning.BooksAndNews.Application.DataAccess;
using RemoteLearning.BooksAndNews.Application.Subscribers;
using System;
using System.Collections.Generic;

namespace RemoteLearning.BooksAndNews.Application.Publishers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is the class that will publish books and newspapers.
    /// It must offer a mechanism through which different other classes can subscribe ether
    /// to books or to newspaper.
    /// When a book or newspaper is published, the PrintingOffice must notify all the corresponding
    /// subscribers.
    /// </summary>
    public class PrintingOffice
    {
        public event NewBookPrintedEventHandler NewBookPrintedEvent;
        public event NewNewspaperPrintedEventHandler NewNewspaperPrintedEvent;

        private readonly IBookRepository bookRepository;
        private readonly INewspaperRepository newspaperRepository;
        private readonly ILog log;

        public PrintingOffice(IBookRepository bookRepository, INewspaperRepository newspaperRepository, ILog log)
        {
            this.bookRepository = bookRepository;
            this.newspaperRepository = newspaperRepository;
            this.log = log;
        }

        public void PrintRandom(int bookCount, int newspaperCount)
        {
            for (int i=1; i<=bookCount; i++)
            {
                if (NewBookPrintedEvent != null)
                {
                    NewBookPrintedEvent(bookRepository.GetRandom());
                }
            }
            for(int i=1; i<=newspaperCount; i++)
            {
                if(NewNewspaperPrintedEvent != null)
                {
                    NewNewspaperPrintedEvent(newspaperRepository.GetRandom());
                }
            }
        }
    }
}