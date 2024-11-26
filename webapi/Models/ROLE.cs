using CoffeeShop.Utils.Api;

namespace CoffeeShop.Models;

public class ROLE : BaseModel
{
    public decimal COM_ID { get; set; }
    public decimal ROL_ID {get; set;}
    public decimal UR_ID {get; set;}
    
    public decimal ROL_NO  {get; set;}
    public decimal EMP_ID {get; set;}
    public string? ROL_CODE {get; set;}
    public string? ROL_NAME_EN {get; set;}
    public string? ROL_NAME_KH {get; set;}
    public decimal ROL_LEVEL {get; set;}
    public decimal NEXT_LEVEL {get; set;}
     public string? NAME_KH {get; set;}
    public string? GENDER {get; set;}
    
}