using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace CoffeeShop.Utils.Helpers;

public static class DBCHelper
{
    public static Dictionary<string, string> HOLDER { get; set; } = new Dictionary<string, string>();

    public static void Load()
    {
        if (G.CREDENTIAL == false) return;
        // using (var db = new SqlConnection(Environment.GetEnvironmentVariable("CONNECTION") ?? ""))
        // {
        //     var query = db.Query("CMF.SPV_CREDENTIAL", commandType: CommandType.StoredProcedure);
        //     DBCHelper.HOLDER = query.ToDictionary(row => (string)row.CRD, row => (string)row.DBC);
        // }
    }
}