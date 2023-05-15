// See https://aka.ms/new-console-template for more information

using Pinewood.DMSSample.Business;
using Pinewood.DMSSample.Business.APIs;
using Pinewood.DMSSample.Business.DataAccess;

PartAvailabilityClient partAvailabilityService = new();
CustomerRepositoryDB customerRepository = new();
PartInvoiceRepositoryDB partInvoiceRepository = new();

DMSClient dmsClient = new(partAvailabilityService, partInvoiceRepository, customerRepository);

await dmsClient.CreatePartInvoiceAsync("1234", 10, "John Doe");