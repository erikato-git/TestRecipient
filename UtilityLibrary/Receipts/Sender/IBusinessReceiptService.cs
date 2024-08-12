using System.Net.Http;
using System.Threading.Tasks;
using Digst.DigitalPost.UtilityLibrary.Receipts.Models;

namespace Digst.DigitalPost.UtilityLibrary.Receipts.Sender
{
    public interface IBusinessReceiptService
    {
        Task<HttpResponseMessage> SendRestBusinessReceiptToNgDP(Receipt receipt, string memoUuid);
    }
}