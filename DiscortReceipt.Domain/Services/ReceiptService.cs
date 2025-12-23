using DiscortReceipt.Domain.Interfaces;
using DiscortReceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscortReceipt.Domain.Services
{
    public class ReceiptService
    {
        private readonly IReceiptOcrService _ocrService;
        private readonly IReceiptRepository _receiptRepository;

        public ReceiptService(IReceiptOcrService ocrService, IReceiptRepository receiptRepository)
        {
            _ocrService = ocrService;
            _receiptRepository = receiptRepository;
        }

        public async Task<Receipt?> ProcessReceiptAsync(string imageUrl)
        {
            var totalAmount = await _ocrService.ExtractTotalAmountAsync(imageUrl);

            if (totalAmount == null) return null;
            
            var receipt = new Receipt
            {
                Amount = totalAmount.Value,
                ReceiptDate = DateTime.UtcNow,
                ImageUrl = imageUrl
            };

            await _receiptRepository.saveAsync(receipt);

            return receipt;
        }
    }
}
