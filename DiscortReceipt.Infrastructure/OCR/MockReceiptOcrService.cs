using DiscortReceipt.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscortReceipt.Infrastructure.OCR
{
    public class MockReceiptOcrService : IReceiptOcrService
    {
        public async Task<decimal?> ExtractTotalAmountAsync(string imageUrl)
        {
            // Mock implementation that always returns a fixed amount for testing purposes
            await Task.Delay(100); // Simulate some async work

            if (string.IsNullOrEmpty(imageUrl))
            {
                return null; // Simulate failure to extract amount
            }

            return 1234m; // Return a mock amount
        }

    }
}
