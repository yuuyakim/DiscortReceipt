using System;
using System.Collections.Generic;
using System.Text;

namespace DiscortReceipt.Domain.Interfaces
{
    public interface IReceiptOcrService
    {
        Task<decimal?> ExtractTotalAmountAsync(string imageUrl);
    }
}
