using Pinewood.DMSSample.Business;
using Pinewood.DMSSample.Business.APIs;
using Pinewood.DMSSample.Business.DataAccess;

namespace Pinewood.DMSSample.Tests
{
    public class DMSClientTests
    {
        private DMSClient client;
        public DMSClientTests()
        {
            client = new DMSClient(new PartAvailabilityClient(), 
                new PartInvoiceRepositoryDB(),
                new CustomerRepositoryDB());
        }

        [Theory]
        [InlineData("code1",2,"testCustomer")]
        public void CreatePartInvoice(string stockCode, int quantity, string customer)
        {
            var newClient = client.CreatePartInvoiceAsync(stockCode, quantity, customer).Result;
            Assert.NotNull(newClient);
            Assert.True(newClient.Success);
        }
    }
}