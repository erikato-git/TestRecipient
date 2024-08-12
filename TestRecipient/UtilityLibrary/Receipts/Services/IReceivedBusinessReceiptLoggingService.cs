using Digst.DigitalPost.UtilityLibrary.Receipts.Models;

namespace Digst.DigitalPost.UtilityLibrary.Receipts.Services
{
    public interface IReceivedBusinessReceiptLoggingService
    {
        void HandleReceivedBusinessReceipt(Receipt businessReceipt);
    }
}