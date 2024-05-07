namespace VendingMachine.Business.ReportsDocuments
{
    internal class FileService : IFileService
    {
        private readonly string folderAddress;
        public FileService(string folderAddress)
        {
            this.folderAddress = folderAddress ?? throw new ArgumentNullException(nameof(folderAddress));
        }

        public void Save(string content, string fileAddress)
        {
            using (StreamWriter writer = new StreamWriter(folderAddress + fileAddress))
            {
                writer.WriteLine(content);
            }
        }
    }
}
