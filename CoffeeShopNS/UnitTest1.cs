using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeShop;

namespace CoffeShopNS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CoffePrice_CustomerHasNotEnoughMoney_UpdatesBalance()
        {
            double AmountPaid = 11.99;
            double Amountdeducted = 4.55;
            double change = 7.44;
            Coffeshop account = new Coffeshop("MS. ", AmountPaid);

            account.Debit(Amountdeducted);

            double actual = account.Balance;
            Assert.AreEqual(change, actual, 0.001, "Sorry, Amount not paid succesfully");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CoffePrice_CustomersAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double AmountPaid = 11.99;
            double AccountIsEmpty = -100.00;
            Coffeshop account = new Coffeshop("MS. SUNDAS", AmountPaid);

            account.Debit(AccountIsEmpty);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CoffePrice_TransactionNotSuccesfull_ShouldThrowArgumentOutOfRange()
        {
            double AmountPaid = 11.99;
            double AccountIsEmpty = -100.00;
            Coffeshop account = new Coffeshop("MS. SUNDAS", AmountPaid);

            account.Debit(AccountIsEmpty);

        }


        [TestMethod]
        public void CoffePrice_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            double AmountPaid = 11.99;
            double ActualAmount = 20.0;
            Coffeshop account = new Coffeshop("MS. SUNDASj", AmountPaid);

            try
            {
                account.Debit(ActualAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, Coffeshop.DebitAmountExceedsBalanceMessage);
            }
        }
    }
}

