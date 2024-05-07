namespace VendingMachine.Business.ReportsDocuments
{
    internal interface IReportService
    {
        void GenerateReport<T>(T obj, string fileName);
    }
}