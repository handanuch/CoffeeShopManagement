namespace CoffeeShop.Utils.Api;

public class BaseModel
{
    public decimal US_ID { get; set; }
    public decimal TR_US { get; set; }
    public string? PC_NAME { get; set; } = "";
    public string? IP_ADDRESS { get; set; } = "";
    public string? MAC_ADDRESS { get; set; } = "";
    public string? FILTER { get; set; } = "";

    public string? PMS_CODE { get; set; }
    public string? LTR_STS { get; set; } = "";
    public string? TR_DVAL { get; set; }
    public decimal CMI_ID { get; set; } = 1;
    public string? CMI_CODE { get; set; } = "";
    public decimal BR_ID { get; set; }
    public string? BR_CODE { get; set; }
    public string? CCY { get; set; }
    public int? ROW_NUM { get; set; }
    public int? ROW { get; set; }
    public string? RPT_ID { get; set; }
    public string? RPT_TYPE { get; set; }
}