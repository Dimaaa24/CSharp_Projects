using RemoteLearning.BooksAndNews.Application.Publications;

namespace RemoteLearning.BooksAndNews.Application.DataAccess
{
    public interface IBookRepository
    {
        Book GetRandom();
    }
}