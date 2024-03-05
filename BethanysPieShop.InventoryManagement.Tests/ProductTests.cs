using BethanysPieShop.InventoryManagement.Domain.General;
using BethanysPieShop.InventoryManagement.Domain.ProductManagement;

namespace BethanysPieShop.InventoryManagement.Tests
{
    public class ProductTests
    {
        [Fact]
        public void UseProduct_Reduces_AmountInStock()
        {
            //Arrange - set a product dummy to teste the method
            Product product = new Product(1, "Sugar", "Lorem ipsum", new Price() { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerKg, 100);
            product.IncreaseStock(100);

            //Act - call the method to test
            product.UseProduct(20);

            //Assert - verify the end value is as expected
            Assert.Equal(80, product.AmountInStock);
        }

        [Fact]
        public void UseProduct_ItemsHigherThanStock_NoChangeToStock()
        {
            //Arrange - set a product dummy to teste the method
            Product product = new Product(1, "Sugar", "Lorem ipsum", new Price() { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerKg, 100);
            product.IncreaseStock(10);

            //Act - call the method to test
            product.UseProduct(100);

            //Assert - verify the end value is as expected
            Assert.Equal(10, product.AmountInStock);
        }

        [Fact]
        public void UseProduct_Reduces_AmountInStock_StockBelowThreshold()
        {
            //Arrange - set a product dummy to teste the method
            Product product = new Product(1, "Sugar", "Lorem ipsum", new Price() { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerKg, 100);
            int increaseValue = 100;
            product.IncreaseStock(increaseValue);

            //Act - call the method to test
            product.UseProduct(increaseValue - 1);

            //Assert - verify the end value is as expected
            Assert.True(product.IsBelowStockTreshold);
        }
        [Fact]
        public void IncreaseStock_AddsOne()
        {
            //Arrange
            Product product = new Product(1, "Sugar", "Lorem ipsum", new Price() { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerKg, 100);

            //Act
            product.IncreaseStock();

            //Assert
            Assert.Equal(1, product.AmountInStock);
        }

        [Fact]
        public void IncreaseStock_AddsPassedInValue_BelowMaxAmount()
        {
            //Arrange
            Product product = new Product(1, "Sugar", "Lorem ipsum", new Price() { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerKg, 100);

            //Act
            product.IncreaseStock(20);

            //Assert
            Assert.Equal(20, product.AmountInStock);
        }

        [Fact]
        public void IncreaseStock_AddsPassedInValue_AboveMaxAmount()
        {
            //Arrange
            Product product = new Product(1, "Sugar", "Lorem ipsum", new Price() { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerKg, 100);

            //Act
            product.IncreaseStock(300);

            //Assert
            Assert.Equal(100, product.AmountInStock);
        }
    }
}
