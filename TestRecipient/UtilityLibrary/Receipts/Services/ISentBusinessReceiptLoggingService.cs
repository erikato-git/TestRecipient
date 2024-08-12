using System.Net.Http;
using Digst.DigitalPost.UtilityLibrary.Receipts.Models;

namespace Digst.DigitalPost.UtilityLibrary.Receipts.Services
{
    public interface ISentBusinessReceiptLoggingService
    {
        HttpResponseMessage LogSentReceiptResponse(Receipt receipt, HttpResponseMessage response, string fileName);
    }
}