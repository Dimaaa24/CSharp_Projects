namespace Nagarro.VendingMachine.PresentationLayer
{
    internal interface IReportView
    {
        void ReportHeader(string name);
        DateTime AskForEndDate();
        DateTime AskForStartDate();
        void SuccesfullGeneration();
    }
}