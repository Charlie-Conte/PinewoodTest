using Pinewood.DMSSample.Business.APIs;
using Pinewood.DMSSample.Business.Controllers;
using Pinewood.DMSSample.Business.DataAccess;

namespace Pinewood.DMSSample.Business
{
    public class DMSClient
    {
        private PartInvoiceController __Controller;

        public DMSClient(IPartAvailabilityClient partAvailabilityService,
            IPartInvoiceRepositoryDB partInvoiceRepository,
            ICustomerRepositoryDB customerRepository)
        {
            __Controller = new PartInvoiceController(partAvailabilityService,
                partInvoiceRepository,
                customerRepository);
        }

        public async Task<CreatePartInvoiceResult> CreatePartInvoiceAsync(string stockCode, int quantity, string customerName)
        {
            return await __Controller.CreatePartInvoiceAsync(stockCode, quantity, customerName);
        }
    }
}