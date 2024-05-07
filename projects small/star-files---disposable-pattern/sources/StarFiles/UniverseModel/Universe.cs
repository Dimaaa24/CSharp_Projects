using System;
using System.Collections.Generic;

namespace RemoteLearning.StarFiles.UniverseModel
{
    internal sealed class Universe : IDisposable
    {
        private readonly List<SimpleStar> stars = new List<SimpleStar>();
        private bool disposedValue;

        public string CreateStarFromTemplate(string name)
        {
            if(disposedValue)
            {
                throw new ObjectDisposedException(nameof(CreateStarFromTemplate));
            }

            SimpleStar star = new SimpleStar(name);
            stars.Add(star);

            return star.FileName;
        }

        public Tuple<string, string> CreateBinaryStar(string name)
        {
            if(disposedValue)
            {
                throw new ObjectDisposedException(nameof(CreateBinaryStar));
            }

            BinaryStar star = new BinaryStar(name);
            stars.Add(star);

            return new Tuple<string, string>(star.FileName, star.AdditionalFilename);
        }

        private void Dispose(bool disposing)
        {
            if (disposedValue)
            {
                return;
            }

            if (disposing)
            {
               foreach(SimpleStar star in stars) 
               {
                    star.Dispose();
               }
            }

            disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}