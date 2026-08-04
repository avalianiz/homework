namespace homework17.Models;

public class Address
{
    public Guid Id { get; set; }

    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string HomeNumber { get; set; } = string.Empty;
}