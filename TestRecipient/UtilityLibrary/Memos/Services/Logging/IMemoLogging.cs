using Digst.DigitalPost.UtilityLibrary.Receipts.Models;
using Dk.Digst.Digital.Post.Memolib.Model;

namespace Digst.DigitalPost.UtilityLibrary.Memos.Services.Logging
{
    public interface IMemoLogging
    {
        void LogMemoSuccessfullyParsed(Receipt businessReceipt, MessageHeader memoMessageHeader);
        void LogMemoUnsuccessfullyParsed(Receipt businessReceipt, string fileName);
    }
}