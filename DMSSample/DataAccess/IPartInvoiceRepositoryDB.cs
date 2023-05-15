using Pinewood.DMSSample.Business.Models;

namespace Pinewood.DMSSample.Business.DataAccess;

public interface IPartInvoiceRepositoryDB
{
    void Add(PartInvoice invoice);
}