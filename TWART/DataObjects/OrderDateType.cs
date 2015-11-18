namespace TWART.DataObjects
{
    // This is a Enum for specifiy when you want to search for a order.
    // Places - The date the order was placed.
    // Received - The date that we (the company) recived the order from the customer.
    // Delivered - The date we plan delivering or the date we did deliver the order for the customer.
    public enum OrderDateType
    {
        Placed,
        Received,
        Delivered
    }
}