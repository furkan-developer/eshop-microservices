namespace Order.Domain;

internal class DomainException : Exception
{
    internal DomainException(string message) : base(message) { }
}

internal sealed class DomainExceptionMessages{
    internal const string ORDER_QUANTITY_NEGATIFE_OR_ZERO = "Order's quntity should not zero or negatif";
    internal const string ORDER_PRICE_NEGATIFE_OR_ZERO = "Order's quntity should not zero or negatif";
}