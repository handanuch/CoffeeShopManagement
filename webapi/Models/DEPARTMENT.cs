using CoffeeShop.Utils.Api;

namespace CoffeeShop.Models;

public class DEPARTMENT : BaseModel
{
    public decimal COM_ID { get; set; }
    public decimal DEP_ID {get; set;}
    public int DEP_NO { get; set; }
    public string? DEP_CODE { get; set; }
    public string? DEP_NAME_LOCAL { get; set; }
    public string? DEP_NAME_ENG { get; set; }
    public string? COM_NAME_LOCAL { get; set; }
    public string? COM_NAME_ENG { get; set; }
    public string? ADDR_KH { get; set; }
    public string? ADDR_EN { get; set; }
    public string? EMAIL { get; set; }
    public string? WEBSITE { get; set; }
    public string? FACEBOOK { get; set; }
    public string? PHONE { get; set; }
    public string? LOGO { get; set; }
    
}