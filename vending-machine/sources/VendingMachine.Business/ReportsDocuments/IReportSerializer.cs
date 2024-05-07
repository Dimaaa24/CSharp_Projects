namespace VendingMachine.Business.ReportsDocuments
{
    internal interface IReportSerializer
    {
        string Serialize<T>(T obj);
    }
}