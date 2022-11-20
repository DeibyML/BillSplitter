using System.ComponentModel.DataAnnotations;
using GroupG_Assignment4.Models;

namespace GroupG_Assignment4.Tests.Models;

public class BillTests
{
    [Test]
    public void GroupGTest01_AmountEqualsContriIf1Person()
    {
        Bill splitBill = new Bill();
        splitBill.QuantityPeople = 1;
        splitBill.Tip = 0;
        splitBill.Amount = 1234567890;
        Assert.That(1234567890, Is.EqualTo(splitBill.CalculateTotalAmount()));
    }

    [Test]
    public void GroupGTest02_TipWhenPeopleSplit1Person()
    {
        Bill splitBill = new Bill
        {
            QuantityPeople = 1,
            Tip = 5,
            Amount = 100m
        };
        Assert.That(105d, Is.EqualTo(splitBill.CalculateIndividualAmount()));
    }

    [Test]
    public void GroupGTest03_AmountEqualsContriIfSplitFound0Person()
    {
        Bill splitBill = new Bill();
        splitBill.QuantityPeople = 0;
        splitBill.Tip = 0;
        splitBill.Amount = 1234567890;
        Assert.That(1234567890, Is.EqualTo(splitBill.CalculateTotalAmount()));
    }

    [Test]
    public void GroupGTest04_AmountPayWhenContriSplit2Person()
    {
        Bill splitBill = new Bill();
        splitBill.QuantityPeople = 2;
        splitBill.Tip = 10;
        splitBill.Amount = 200m;
        Assert.That(splitBill.CalculateIndividualAmount(), Is.EqualTo(110d));
    }

    [Test]
    public void GroupGTest05_TWhenPeopleSplit4Person()
    {
        Bill splitBill = new Bill
        {
            QuantityPeople = 4,
            Tip = 40,
            Amount = 200m
        };
        Assert.That(splitBill.CalculateIndividualAmount(), Is.EqualTo(70d));
    }

    [Test]
    public void GroupGTest06_TipWhenContriSplit5Person()
    {
        Bill splitBill = new Bill();
        splitBill.QuantityPeople = 5;
        splitBill.Tip = 50;
        splitBill.Amount = 200m;
        Assert.That(60d, Is.EqualTo(splitBill.CalculateIndividualAmount()));
    }


    [Test]
    public void GroupGTest07_PayAmountWhenContriSplitNegativeAndTip0()
    {
        Bill splitBill = new Bill();
        splitBill.QuantityPeople = -1;
        splitBill.Tip = 0;
        splitBill.Amount = 200m;
        Assert.That(200m, Is.EqualTo(splitBill.CalculateTotalAmount()));
    }

    [Test]
    public void GroupGTest08_PayAmountWhenPeopleSplit0AndTipNegative()
    {
        Bill splitBill = new Bill();
        splitBill.QuantityPeople = 0;
        splitBill.Tip = -10; // Considering it as 0
        splitBill.Amount = 100m;
        Assert.That(100m, Is.EqualTo(splitBill.CalculateTotalAmount()));
    }

    [Test]
    public void GroupGTest09_AmountPayWhenContriSplitNegative()
    {
        Bill splitBill = new Bill();
        splitBill.QuantityPeople = -1; // considering it as 0
        splitBill.Tip = 10;
        splitBill.Amount = 200m;
        Assert.That(220m, Is.EqualTo(splitBill.CalculateTotalAmount()));
    }

    [Test]
    public void GroupGTest10_AmountPayWhenContriSplit1TipNegative()
    {
        Bill splitBill = new Bill();
        splitBill.QuantityPeople = 2;
        splitBill.Tip = -10; // considering it as 0
        splitBill.Amount = 200m;
        Assert.AreEqual(splitBill.CalculateIndividualAmount(), 100m);
    }

    [Test]
    public void GroupGTest11_AmountPayWhenContriSplit1TipNegative()
    {
        Bill splitBill = new Bill();
        splitBill.QuantityPeople = 4;
        splitBill.Tip = -10; // considering it as 0
        splitBill.Amount = 200m;
        Assert.That(50m, Is.EqualTo(splitBill.CalculateIndividualAmount()));
    }


    [Test]
    public void GroupGTest12_AmountPayWhenBothContriSplit1TipNegative()
    {
        Bill splitBill = new Bill();
        splitBill.QuantityPeople = -5; // considering it as 0
        splitBill.Tip = -20; // considering it as 0
        splitBill.Amount = 200m;
        Assert.That(200m, Is.EqualTo(splitBill.CalculateIndividualAmount()));
    }

    [Test]
    public void GroupGTest13_AmountPayTipFoundGreaterThan50()
    {
        // Arrange 
        Bill splitBill = new Bill
        {
            QuantityPeople = 1,
            Tip = 70,
            Amount = 100
        };
        // Act 
        var validateValue = new List<ValidationResult>();
        var testContext = new ValidationContext(splitBill, null, null);
        Validator.TryValidateObject(splitBill, testContext, validateValue, true);

        // Assert
        Assert.That(validateValue[0].ErrorMessage, Is.EqualTo("Tip values should be in range of 1 to 50"));
    }


    [Test]
    public void GroupGTest14_AmountPayAmountFoundNegative()
    {
        // Arrange 
        Bill splitBill = new Bill();
        splitBill.QuantityPeople = 3;
        splitBill.Tip = 30;
        splitBill.Amount = -10;
        splitBill.CalculateTotalAmount();

        Assert.That(0m, Is.EqualTo(splitBill.Amount));
    }

    [Test]
    public void GroupGTest15_AmountPayAmountFound0()
    {
        // Arrange 
        Bill splitBill = new Bill();
        splitBill.QuantityPeople = 2;
        splitBill.Tip = 0;
        splitBill.Amount = 0;
        // Act 
        splitBill.CalculateTotalAmount();

        Assert.That(0m, Is.EqualTo(splitBill.Amount));
    }

    [Test]
    public void GroupGTest16_AmountPayAmountFound0()
    {
        // Arrange 
        Bill splitBill = new Bill();
        splitBill.QuantityPeople = 2;
        splitBill.Tip = 10;
        splitBill.Amount = 100;
        // Act 
        var results = new List<ValidationResult>();
        var testContext = new ValidationContext(splitBill, null, null);
        Validator.TryValidateObject(splitBill, testContext, results, true);

        // Assert
        Assert.That(0, Is.EqualTo(results.Count));
    }

    [Test]
    public void GroupGTest17_TestNominal()
    {
        // Arrange
        Bill tipCalculator = new Bill();
        tipCalculator.Tip = 12.5m;
        tipCalculator.Amount = 25.05m;
        tipCalculator.QuantityPeople = 5;

        // Act
        decimal result = tipCalculator.CalculateIndividualAmount();

        // Assert
        Assert.That(result, Is.EqualTo(5.64m));
    }
}
