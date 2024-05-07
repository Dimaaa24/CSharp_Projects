namespace VendingMachine.Business.ReportsDocuments
{
    internal class ReportService : IReportService
    {
        private readonly IReportSerializer reportSerializer;
        private readonly IFileService fileService;

        public ReportService(IFileService fileService, IReportSerializer reportSerializer)
        {
            this.reportSerializer = reportSerializer ?? throw new ArgumentNullException(nameof(reportSerializer));
            this.fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public void GenerateReport<T>(T obj, string fileName)
        {
            string serializedObj = reportSerializer.Serialize(obj);
            fileService.Save(serializedObj, fileName);
        }
    }
}
