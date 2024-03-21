using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RemoteLearning.BooksAndNews.Application.DataAccess;
using RemoteLearning.BooksAndNews.Application.Publications;

namespace RemoteLearning.BooksAndNews.DataAccess
{
    public class NewspaperRepository : INewspaperRepository
    {
        private static readonly List<Newspaper> newspapers;

        static NewspaperRepository()
        {
            string json = File.ReadAllText("Data\\newspapers.json");
            newspapers = JsonConvert.DeserializeObject<List<Newspaper>>(json);
        }

        private readonly Random random;

        public NewspaperRepository()
        {
            random = new Random();
        }

        public Newspaper GetRandom()
        {
            if (newspapers.Count == 0)
                return null;

            int index = random.Next(newspapers.Count);
            return newspapers[index];
        }
    }
}