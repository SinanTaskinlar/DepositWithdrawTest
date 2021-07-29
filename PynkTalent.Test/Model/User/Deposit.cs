using NUnit.Framework;
using System;
using PynkTalent.Models.User;
using PynkTalent.Factory.Deposit.Strategy;

namespace PynkTalent.Test.Model.User
{
    [TestFixture]
    public class Deposit
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Deposit_DepositWithBaseUser_ReturnsZero()
        {
            // Arrange
            var fee = 6;

            // Act
            var strategy = new BaseStrategy();

            // Assert
            Assert.AreEqual(strategy.Fee, fee);
        }

        [Test]
        public void Deposit_DepositWithUKUser_ReturnsZero()
        {
            // Arrange
            var fee = 0;

            // Act
            var strategy = new UKStrategy();

            // Assert
            Assert.AreEqual(strategy.Fee, fee);
        }

        [Test]
        public void Deposit_DepositWithUSUser_ReturnsZero()
        {
            // Arrange
            var fee = 5;

            // Act
            var strategy = new USStrategy();

            // Assert
            Assert.AreEqual(strategy.Fee, fee);
        }

        [Test]
        [TestCase(100, "Base", 94)]
        [TestCase(101, "US", 96)]
        [TestCase(102, "UK", 102)]
        [TestCase(103,"DE",93)]
        [TestCase(5, "Base", -1)]
        [TestCase(3, "US", -1)]
        [TestCase(1, "UK", 1)]
        [TestCase(5,"DE",-1)]

        public void Deposit_CalculateDepositAmount_ReturnFeeDeducted(decimal amount, string strategy, decimal result)
        {
            // Arrange
            var deposit_strategy = new BaseStrategy();
            switch (strategy)
            {
                case "US":
                    deposit_strategy = new USStrategy();
                    break;

                case "UK":
                    deposit_strategy = new UKStrategy();
                    break;

                case "DE":
                    deposit_strategy = new DEStrategy();
                    break;
            }

            // Assert
            Assert.AreEqual(deposit_strategy.DepositAmount(amount), result);
        }
    }
}