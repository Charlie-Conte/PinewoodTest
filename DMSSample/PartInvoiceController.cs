namespace Pinewood.DMSSample.Business
{
    public class PartInvoiceController
    {
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

            CustomerRepositoryDB _CustomerRepository = new CustomerRepositoryDB();
            Customer? _Customer = _CustomerRepository.GetByName(customerName);
            int _CustomerID = _Customer?.ID ?? 0;
            if (_CustomerID <= 0)
            {
                return new CreatePartInvoiceResult(false);
            }

            using (PartAvailabilityClient _PartAvailabilityService = new PartAvailabilityClient())
            {
                int _Availability = await _PartAvailabilityService.GetAvailability(stockCode);
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


            PartInvoiceRepositoryDB _PartInvoiceRepository = new PartInvoiceRepositoryDB();
            _PartInvoiceRepository.Add(_PartInvoice);

            return new CreatePartInvoiceResult(true);
        }
    }
}
