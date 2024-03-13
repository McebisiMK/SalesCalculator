namespace SalesCalculator.Core.Interfaces
{
    public interface ITaxCalculatorService
    {
        decimal Calculate(decimal price, bool hasExemption, bool isImported);
    }
}
