using Nagarro.VendingMachine;
using Nagarro.VendingMachine.DataAccess;
using Nagarro.VendingMachine.Models;
using Nagarro.VendingMachine.PresentationLayer;
using Nagarro.VendingMachine.UseCases;
using VendingMachine.Business.Logging;
using VendingMachine.Business.ReportsDocuments;
using VendingMachine.Business.SerializedObjects;

namespace VendingMachine.Business.UseCases
{
    internal class StockReportUseCase : IUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IReportView reportView;
        private readonly IReportService reportService;
        private readonly ILogger<StockReportUseCase> logger;
        public StockReportUseCase(IProductRepository productRepository, IReportView reportView, IReportService reportService, ILogger<StockReportUseCase> logger) 
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.reportView = reportView ?? throw new ArgumentNullException(nameof(reportView));
            this.reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public void Execute()
        {
            logger.Info("StockReport usecase initialized.");

            reportView.ReportHeader("Stock");

            StockReport stockReport = new StockReport(productRepository.GetAll());
            string fileName = "StockReport-" + DateTime.Now.ToString("yyyy-MM-dd-HHmmss");

            reportService.GenerateReport(stockReport, fileName);

            logger.Info("Stock report generated succesfully");

            reportView.SuccesfullGeneration();
        }
    }
}
