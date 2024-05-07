using Nagarro.VendingMachine;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.UseCases;
using VendingMachine.Business.Logging;
using VendingMachine.Business.ReportsDocuments;
using VendingMachine.Business.SerializedObjects;

namespace VendingMachine.Business.UseCases
{
    internal class VolumeReportUseCase : IUseCase
    {
        private readonly ISaleRepository saleRepository;
        private readonly IReportView reportView;
        private readonly IReportService reportService;
        private readonly ILogger<VolumeReportUseCase> logger;
        public VolumeReportUseCase(ISaleRepository saleRepository, IReportView reportView, IReportService reportService, ILogger<VolumeReportUseCase> logger)
        {
            this.saleRepository = saleRepository ?? throw new ArgumentNullException(nameof(saleRepository));
            this.reportView = reportView ?? throw new ArgumentNullException(nameof(reportView));
            this.reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Execute()
        {
            logger.Info("VolumeReport usecase initialized.");

            reportView.ReportHeader("Sales");

            DateTime startDate = reportView.AskForStartDate();
            DateTime endDate = reportView.AskForEndDate();

            VolumeReport volumeReport = new VolumeReport(startDate, endDate, saleRepository.GetVolumeInAPeriod(startDate, endDate));
            string fileName = "VolumeReport-" + DateTime.Now.ToString("yyyy-MM-dd-HHmmss");

            reportService.GenerateReport(volumeReport, fileName);

            logger.Info("Volume report generated succesfully");

            reportView.SuccesfullGeneration();
        }
    }
}
