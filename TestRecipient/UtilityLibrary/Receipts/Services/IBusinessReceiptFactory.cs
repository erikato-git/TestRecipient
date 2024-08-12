using Digst.DigitalPost.UtilityLibrary.Receipts.Models;

namespace Digst.DigitalPost.UtilityLibrary.Receipts.Services
{
    public interface IBusinessReceiptFactory
    {
        Receipt CreatePositiveBusinessReceipt(string memoUuid);

        Receipt CreateNegativeBusinessReceipt(string memoUuid = null);
    }
}