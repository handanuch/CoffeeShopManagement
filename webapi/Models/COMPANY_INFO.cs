using CoffeeShop.Utils.Api;

namespace CoffeeShop.Models;

public class COMPANY_INFO : BaseModel
{
    public decimal COM_ID { get; set; }
    public int COM_NO { get; set; }
    public string? COM_CODE { get; set; }
    public string? COM_INITIAL_KH { get; set; }
    public string? COM_INITIAL_EN { get; set; }
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