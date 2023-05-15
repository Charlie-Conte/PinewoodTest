using Pinewood.DMSSample.Business.APIs;
using Pinewood.DMSSample.Business.DataAccess;
using Pinewood.DMSSample.Business.Models;

namespace Pinewood.DMSSample.Business.Controllers
{
    public class PartInvoiceController
    {
        private readonly IPartAvailabilityClient _partAvailabilityService;
        private readonly ICustomerRepositoryDB _customerRepository;
        private readonly IPartInvoiceRepositoryDB _partInvoiceRepository;

        public PartInvoiceController(IPartAvailabilityClient partAvailabilityService,
            IPartInvoiceRepositoryDB partInvoiceRepository,
            ICustomerRepositoryDB customerRepository)
        {
            _partAvailabilityService = partAvailabilityService;
            _partInvoiceRepository = partInvoiceRepository;
            _customerRepository = customerRepository;
        }

        public async Task<CreatePartInvoiceResult> CreatePartInvoiceAsync(string stockCode, int quantity, string customerName)
        {
            if (string.IsNullOrEmpty(stockCode))
            {
                return new CreatePartInvoiceResult(false);
            }

            if (quantity <= 0)
            {
                return new CreatePartInvoiceResult(false);
            }

            Customer? _Customer = _customerRepository.GetByName(customerName);
            int _CustomerID = _Customer?.ID ?? 0;
            if (_CustomerID <= 0)
            {
                return new CreatePartInvoiceResult(false);
            }


            using (_partAvailabilityService)
            {
                int _Availability = await _partAvailabilityService.GetAvailability(stockCode);
                if (_Availability <= 0)
                {
                    return new CreatePartInvoiceResult(false);
                }
            }

            PartInvoice _PartInvoice = new PartInvoice(
                stockCode: stockCode,
                quantity: quantity,
                customerID: _CustomerID
            );


            _partInvoiceRepository.Add(_PartInvoice);

            return new CreatePartInvoiceResult(true);
        }
    }
}
