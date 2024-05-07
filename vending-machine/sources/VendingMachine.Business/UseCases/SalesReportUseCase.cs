using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.Models;
using Nagarro.VendingMachine.PresentationLayer;
using System.Configuration;
using VendingMachine.Business.Logging;
using VendingMachine.Business.ReportsDocuments;
using VendingMachine.Business.SerializedObjects;

namespace Nagarro.VendingMachine.UseCases
{
    internal class SalesReportUseCase : IUseCase
    {
        private readonly ISaleRepository saleRepository;
        private readonly IReportView reportView;
        private readonly IReportService reportService;
        private readonly ILogger<SalesReportUseCase> logger;
        public SalesReportUseCase(ISaleRepository saleRepository, IReportView reportView, IReportService reportService, ILogger<SalesReportUseCase> logger)
        {
            this.saleRepository = saleRepository ?? throw new ArgumentNullException(nameof(saleRepository));
            this.reportView = reportView ?? throw new ArgumentNullException(nameof(reportView));
            this.reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Execute()
        {
            logger.Info("SalesReport usecase initialized.");

            reportView.ReportHeader("Sales");

            DateTime startDate = reportView.AskForStartDate();
            DateTime endDate = reportView.AskForEndDate();

            SalesReport salesReport = new SalesReport(saleRepository.GetAllInAPeriod(startDate, endDate));
            string fileName = "SalesReport-" + DateTime.Now.ToString("yyyy-MM-dd-HHmmss");

            reportService.GenerateReport(salesReport, fileName);

            logger.Info("Sales report generated succesfully");

            reportView.SuccesfullGeneration();
        }
    }
}
