using System.Net;
using System.Net.Http;
using Digst.DigitalPost.UtilityLibrary.Receipts.Models;
using Microsoft.Extensions.Logging;

namespace Digst.DigitalPost.UtilityLibrary.Receipts.Services
{
    public class SentBusinessReceiptLoggingService : ISentBusinessReceiptLoggingService
    {
        private readonly ILogger logger;

        public SentBusinessReceiptLoggingService(ILogger<SentBusinessReceiptLoggingService> logger)
        {
            this.logger = logger;
        }

        public HttpResponseMessage LogSentReceiptResponse(Receipt receipt, HttpResponseMessage response,
            string fileName)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                logger.LogInformation(
                    "Business Receipt with ReceiptStatus: {} for MeMo with uuid: {} sent to NgDP.",
                    receipt.ReceiptStatus,
                    fileName,
                    response.StatusCode.ToString());
            }
            else
            {
                logger.LogError(
                    "Unable to send Business Receipt with ReceiptStatus: {} for MeMo with uuid: {}, httpStatus: {}",
                    receipt.ReceiptStatus,
                    fileName,
                    response.StatusCode.ToString());
            }

            return response;
        }
    }
}