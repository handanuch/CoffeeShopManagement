
namespace CoffeeShop.Utils.Session;

public class SessionModel
{
    public string? Token { get; set; }
    public string? Credential { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? ExpireDate { get; set; }

    public string? US_ID { get; set; }
    public decimal? EMP_ID { get; set; }
    public string? USER_NAME { get; set; }
}