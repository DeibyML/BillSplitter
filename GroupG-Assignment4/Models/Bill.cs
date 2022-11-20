using System.ComponentModel.DataAnnotations;

namespace GroupG_Assignment4.Models;

public class Bill
{
    [Required(ErrorMessage = "Please enter an amount")]
    public decimal Amount { get; set; }

    [Required]
    public int QuantityPeople { get; set; }
    
    [Required(ErrorMessage = "Tip values should be in range of 1 to 50")]
    [Range(1, 50, ErrorMessage = "Tip values should be in range of 1 to 50")]
    public decimal Tip { get; set; }
    public decimal Total { get; set; }
    public decimal IndividualAmount { get; set; }

    public decimal CalculateTotalAmount()
    {
        Amount = Amount < 0 ? 0 : Amount;
        return Math.Round(Amount + (Amount * ((Tip < 0 ? 0 : Tip)/100)), 2);
    }
    
    public decimal CalculateIndividualAmount()
    {
        if (QuantityPeople <= 0)
        {
            return Amount;
        }

        Total = CalculateTotalAmount();
        return Math.Round(Total / (QuantityPeople <= 0 ? 0 : QuantityPeople), 2);
    }
}