using DiscortReceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscortReceipt.Domain.Interfaces
{
    public interface IReceiptRepository
    {
        Task saveAsync(Receipt receipt);
        Task<IEnumerable<Receipt>> GetMonthlyReceiptsAsync(int year, int month);
    }
}
