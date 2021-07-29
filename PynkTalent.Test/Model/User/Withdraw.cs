using NUnit.Framework;
using System;
using PynkTalent.Models.User;
using PynkTalent.Factory.Withdraw.Strategy;

namespace PynkTalent.Test.Model.User
{
    [TestFixture]
    public class Withdraw
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        [TestCase(100,20, "Base", 80)]
        [TestCase(100,21, "Base", 79)]
        [TestCase(0,21,"Base",0)]
        [TestCase(100,11, "UK", 89)]
        [TestCase(100,9,"UK",0)]
        [TestCase(0,21,"UK",0)]
        [TestCase(100,21, "DE",0)]
        [TestCase(100,9, "DE",0)]
        [TestCase(100,5,"DE",0)]
        [TestCase(0,5,"DE",0)]
        [TestCase(100,5,"US",0)]
        [TestCase(100,21,"US",79)]
        [TestCase(0,5,"US",0)]
        public void Withdraw_CalculateWithdrawAmount(decimal balance,decimal amount, string strategy, decimal result)
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
            Assert.AreEqual(deposit_strategy.WithdrawAmount(balance,amount,strategy), result);
        }
    }
}