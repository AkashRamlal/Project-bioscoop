public static class SeatLogic
{
    public static decimal ApplySeniorDiscount(decimal originalPrice)
        => originalPrice * 0.80m;

    public static decimal ApplyYouthDiscount(decimal originalPrice)
        => originalPrice * 0.50m;

    public static decimal RemoveDiscount(decimal originalPrice)
        => originalPrice;
}