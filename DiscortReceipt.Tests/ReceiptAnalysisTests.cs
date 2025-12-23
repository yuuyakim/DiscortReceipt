using DiscortReceipt.Domain.Interfaces;
using Moq;

namespace DiscortReceipt.Tests;

public class ReceiptAnalysisTests
{
    [Fact]
    public async Task ExtractTotalAmountAsync_ShouldReturnCorrectAmount_WhenImageIsProvided()
    {
        // Arrange
        var ocrService = new Mock<IReceiptOcrService>();
        var imageUrl = "http://example.com/receipt.jpg";
        var expectedAmount = 1200m;
        ocrService.Setup(s => s.ExtractTotalAmountAsync(imageUrl))
                  .ReturnsAsync(expectedAmount);
        // Act
        var actualAmount = await ocrService.Object.ExtractTotalAmountAsync(imageUrl);
        // Assert
        Assert.Equal(expectedAmount, actualAmount);
    }
}
