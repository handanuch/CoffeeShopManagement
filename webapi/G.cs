using CoffeeShop.Utils.Helpers;

namespace CoffeeShop;

public static class G
{
    public static bool CREDENTIAL { get; set; } = Environment.GetEnvironmentVariable("CREDENTIAL") == "true";
    public static double SESSION_TIMEOUT { get; set; } = Environment.GetEnvironmentVariable("SESSION_TIMEOUT") == null
    ? 1440 : Convert.ToDouble(Environment.GetEnvironmentVariable("SESSION_TIMEOUT"));

    public static string DBC(HttpContext httpContext)
    {
        if (G.CREDENTIAL == false) return Environment.GetEnvironmentVariable("CONNECTION") ?? "";
        return DBCHelper.HOLDER[httpContext.Request.Headers["x-crd"].ToString().ToUpper()];
    }
}