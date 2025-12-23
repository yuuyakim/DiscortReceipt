using System;
using System.Collections.Generic;
using System.Text;

namespace DiscortReceipt.Domain.Models
{
    public record Receipt
    {
        public decimal Amount { get; init; }
        public DateTime ReceiptDate { get; init; }
        public string ImageUrl { get; init; } = string.Empty;

    }
}
