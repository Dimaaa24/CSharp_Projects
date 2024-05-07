using Newtonsoft.Json;

namespace VendingMachine.Business.ReportsDocuments
{
    internal class JSONReportSerializer : IReportSerializer
    {
        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
