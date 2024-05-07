namespace VendingMachine.Business.ReportsDocuments
{
    internal interface IFileService
    {
        void Save(string content, string fileAddress);
    }
}