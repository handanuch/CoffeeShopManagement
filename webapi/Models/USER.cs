using CoffeeShop.Utils.Api;

namespace CoffeeShop.Models;

public class USER : BaseModel
{
    public decimal COM_ID { get; set; }
    // public decimal US_ID {get; set;}
    public string? USER_NAME {get; set;}
    public string? DISPLAY_NAME {get; set;}
    public string? PASS {get; set;}
    public decimal EMP_ID {get; set;}
    public bool IS_LOCK {get; set;}
    public DateTime LOCK_DATE {get; set;}
    public string? LOGIN_STATUS {get; set;}
    public string? LLOG_IN { get; set;}
    public string? IS_ONLINE { get; set;}
    public string? LLOG_OUT { get; set;}
    public string? EMAIL { get; set;}
    public string? IMG {get; set;}
    
}