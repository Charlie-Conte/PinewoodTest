namespace Pinewood.DMSSample.Business
{
    public class DMSClient
    {
        private PartInvoiceController __Controller;

        public DMSClient()
        {
            __Controller = new PartInvoiceController();
        }

        public async Task<CreatePartInvoiceResult> CreatePartInvoiceAsync(string stockCode, int quantity, string customerName)
        {
            return await __Controller.CreatePartInvoiceAsync(stockCode, quantity, customerName);
        }
    }
}