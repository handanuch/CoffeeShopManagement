using CoffeeShop.Utils.Api;

namespace CoffeeShop.Models;

public class PRODUCT : BaseModel
{
    public decimal PRO_ID { get; set; }
    public decimal EMP_ID {get; set;}
    public string? PRO_CODE { get; set; }
    public string? PRO_NAME_KH { get; set; }
    public string? PRO_NAME_EN { get; set; }
    public string? PRO_PRICE { get; set; }
    public string? PRO_STS { get; set; }
    public DateTime CREATION_DATE { get; set; }
    public DateTime MODIFY_DATE  { get; set; }
    
}