using Pinewood.DMSSample.Business.Models;

namespace Pinewood.DMSSample.Business.DataAccess;

public interface ICustomerRepositoryDB
{
    Customer? GetByName(string name);
}