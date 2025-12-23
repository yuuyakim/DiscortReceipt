using DiscortReceipt.Domain.Interfaces;
using DiscortReceipt.Domain.Models;
using DiscortReceipt.Domain.Services;
using Moq;

namespace DiscortReceipt.Tests
{
    public class ReceiptServiceTests
    {
        [Fact]
        public async Task ProcessReceiptAsyn_ShouldSaveReceipt_WhenOcrSucceeds()
        {
            // Arrange
            var mockOcrService = new Mock<IReceiptOcrService>();
            var mockReceiptRepository = new Mock<IReceiptRepository>();
            var receiptService = new ReceiptService(mockOcrService.Object, mockReceiptRepository.Object);

            var imageUrl = "http://example.com/receipt.jpg";
            mockOcrService.Setup(x => x.ExtractTotalAmountAsync(imageUrl))
                          .ReturnsAsync(1000m);

            // Act
            var result = await receiptService.ProcessReceiptAsync(imageUrl);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1000m, result.Amount);

            // saveAsyncが一度だけ呼び出されることを検証
            mockReceiptRepository.Verify(x => x.saveAsync(It.IsAny<Receipt>()), Times.Once);
        }
    }
}
