namespace TWART.DataObjects
{
    // This is a Enum for specifiy when you want to search for a package.
    // Places - The date the package was placed.
    // Received - The date that we (the company) recived the package from the customer.
    // Delivered - The date we plan delivering or the date we did deliver the package for the customer.
    public enum PackageDateType
    {
        Placed,
        Received,
        Delivered
    }
}