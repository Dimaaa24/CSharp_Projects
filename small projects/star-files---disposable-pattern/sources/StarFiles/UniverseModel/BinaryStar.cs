﻿using System;

namespace RemoteLearning.StarFiles.UniverseModel
{
    /// <summary>
    /// A binary star is a star system consisting of two stars orbiting around their common barycenter.
    /// Out BinaryStar instance will create two files (the main one from the base class and an additional one).
    /// </summary>
    internal class BinaryStar : SimpleStar
    {
        private readonly Random random = new Random();
        private WinApiFile additionalFile;

        private bool disposedValue;

        public string AdditionalFilename => additionalFile.FileName;

        public BinaryStar(string name)
            : base(name)
        {
            CreateAndOpenAdditionalFile();
            GenerateAdditionalContent();
        }

        private void CreateAndOpenAdditionalFile()
        {
            Guid guid = Guid.NewGuid();
            string filePath = $"star-{guid:D}.txt";
            additionalFile = new WinApiFile(filePath);

            GenerateContentInAdditionalFile();
        }

        private void GenerateContentInAdditionalFile()
        {
            if(disposedValue)
            {
                throw new ObjectDisposedException(nameof(GenerateContentInAdditionalFile));
            }

            string content = $"This is the star 2 of the binary named '{Name}'" + Environment.NewLine;
            additionalFile.Write(content);
        }

        protected override void GenerateContent()
        {
            if(disposedValue)
            {
                throw new ObjectDisposedException(nameof(GenerateContent));
            }

            string content = $"This is the star 1 of the binary named '{Name}'" + Environment.NewLine +
                             "This star is made up mostly of Hydrogen and some Helium atoms." + Environment.NewLine;

            File.Write(content);
        }

        private void GenerateAdditionalContent()
        {
            for (int i = 0; i < 10; i++)
            {
                int atomicMass = random.Next(1, 26);
                AddContent($"Some atoms with atomic mass {atomicMass} have been found in this star." + Environment.NewLine);
            }
        }

        private void AddContent(string content)
        {
            if (disposedValue)
            {
                throw new ObjectDisposedException(nameof(AddContent));
            }

            int fileIndex = random.Next(1, 3);

            switch (fileIndex)
            {
                case 1:
                    File.Write(content);
                    break;

                case 2:
                    additionalFile.Write(content);
                    break;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposedValue)
            {
                return;
            }

            if (disposing)
            {
               additionalFile?.Dispose();
               base.Dispose(disposing);
            }

            disposedValue = true;
        }
    }
}