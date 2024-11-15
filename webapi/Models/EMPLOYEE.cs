using CoffeeShop.Utils.Api;

namespace CoffeeShop.Models;

public class EMPLOYEE : BaseModel
{
    public decimal COM_ID { get; set; }
    public decimal POS_ID {get; set;}
    public decimal DEP_ID  {get; set;}
    public decimal EMP_ID {get; set;}
    public string? EMP_CODE {get; set;}
    public string? NAME_EN {get; set;}
    public string? PHONE {get; set;}
    public string? MOBILE {get; set;}
    public string? EMP_STS {get; set;}
    public DateTime? START_DATE {get; set;}
    public string? NAME_KH {get; set;}
    public string? GENDER {get; set;}
    
}