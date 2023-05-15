// See https://aka.ms/new-console-template for more information

using Pinewood.DMSSample.Business;
using Pinewood.DMSSample.Business.APIs;
using Pinewood.DMSSample.Business.DataAccess;
using Microsoft.Extensions.DependencyInjection;

class SampleConsole
{
    static void Main(string[] args)
    {
        PartAvailabilityClient partAvailabilityService = new();
        CustomerRepositoryDB customerRepository = new();
        PartInvoiceRepositoryDB partInvoiceRepository = new();

        DMSClient dmsClient = new(partAvailabilityService, partInvoiceRepository, customerRepository);

        var partInvoiceResult = dmsClient.CreatePartInvoiceAsync("1234", 10, "John Doe").Result;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IPartAvailabilityClient, PartAvailabilityClient>();
        services.AddSingleton<ICustomerRepositoryDB, CustomerRepositoryDB>();
        services.AddSingleton<IPartInvoiceRepositoryDB, PartInvoiceRepositoryDB>();
    }

}


