using System.IO;
using Digst.DigitalPost.UtilityLibrary.Memos.Services.Logging;
using Digst.DigitalPost.UtilityLibrary.Memos.Services.Parser;
using Digst.DigitalPost.UtilityLibrary.Receipts.Models;
using Digst.DigitalPost.UtilityLibrary.Receipts.Sender;
using Digst.DigitalPost.UtilityLibrary.Receipts.Services;
using Dk.Digst.Digital.Post.Memolib.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPTestRecipient.Controllers
{
    [Route("recipient-system")]
    [ApiController]
    public class RecipientSystemMemoEndpointController : ControllerBase
    {
        private readonly IBusinessReceiptFactory businessReceiptFactory;

        private readonly IBusinessReceiptService businessReceiptService;

        private readonly IMemoLogging memoLoggingService;

        private readonly IMemoService memoService;

        public RecipientSystemMemoEndpointController(
            IMemoLogging memoLoggingSerice,
            IMemoService memoService,
            IBusinessReceiptFactory businessReceipt,
            IBusinessReceiptService businessReceiptService)
        {
            memoLoggingService = memoLoggingSerice;
            this.memoService = memoService;
            businessReceiptFactory = businessReceipt;
            this.businessReceiptService = businessReceiptService;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok("Dang yo code bad.");
        }

        [HttpPost]
        public IActionResult RecipientSystemMemoEndpoint([FromForm] IFormFile file)
        {
            if (file == null)
            {
                return StatusCode(400, "MeMo is not present in request");
            }

            Stream memoFile = file.OpenReadStream();
            MessageHeader memoMessageHeader = memoService.ParseMemoHeader(memoFile);

            Receipt receipt;
            if (memoMessageHeader != null)
            {
                receipt = businessReceiptFactory.CreatePositiveBusinessReceipt(file.FileName);
                memoLoggingService.LogMemoSuccessfullyParsed(receipt, memoMessageHeader);
            }
            else
            {
                receipt = businessReceiptFactory.CreateNegativeBusinessReceipt(file.FileName);
                memoLoggingService.LogMemoUnsuccessfullyParsed(receipt, file.FileName);
            }

            businessReceiptService.SendRestBusinessReceiptToNgDP(receipt, file.FileName);

            return Ok(memoMessageHeader != null ? memoMessageHeader.messageUUID : "Unable to parse MeMo");
        }
    }
}
