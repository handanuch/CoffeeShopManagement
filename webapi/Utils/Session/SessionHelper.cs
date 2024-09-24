using Dapper;
using CoffeeShop.Utils.Api;
using Microsoft.Data.Sqlite;

namespace CoffeeShop.Utils.Session;

public static class SessionHelper
{
    private static string sqlroot = "Data Source=.sqlite3";
    private static string sqlinit = "CREATE TABLE IF NOT EXISTS sessions (Token TEXT PRIMARY KEY, Credential TEXT, CreatedDate DATETIME, ExpireDate DATETIME, US_ID TEXT, EMP_ID INTEGER, USER_NAME TEXT);";

    public static string? Generate(HttpContext httpContext, SessionModel dto)
    {

        using (var db = new SqliteConnection(sqlroot))
        {
            db.Execute(sqlinit);
            string token = Guid.NewGuid().ToString("N");
            string sql = "INSERT INTO sessions (Token, Credential, CreatedDate, ExpireDate, US_ID, EMP_ID, USER_NAME) VALUES (@Token, @Credential, @CreatedDate, @ExpireDate, @US_ID, @EMP_ID, @USER_NAME);";
            var param = new DynamicParameters();
            param.Add("Token", token);
            param.Add("Credential", G.CREDENTIAL ? httpContext.Request.Headers["x-crd"] : "");
            param.Add("CreatedDate", DateTime.Now);
            param.Add("ExpireDate", DateTime.Now.AddMinutes(G.SESSION_TIMEOUT));
            param.Add("US_ID", dto.US_ID);
            param.Add("EMP_ID", dto.EMP_ID);
            param.Add("USER_NAME", dto.USER_NAME);
            var i = db.Execute(sql, param);
            if (i > 0) return token;
            return null;
        }
    }

    public static SessionModel? GetSession(HttpContext httpContext)
    {
        using (var db = new SqliteConnection(sqlroot))
        {
            db.Execute(sqlinit);
            string sql = "SELECT * FROM sessions WHERE Token = @Token AND Credential = @Credential;";
            var param = new DynamicParameters();
            param.Add("Token", httpContext.Request.Headers["x-token"]);
            param.Add("Credential", G.CREDENTIAL ? httpContext.Request.Headers["x-crd"] : "");
            var session = db.QueryFirstOrDefault<SessionModel>(sql, param);
            return session;
        }
    }

    public static void ClearExpires()
    {
        using (var db = new SqliteConnection(sqlroot))
        {
            db.Execute(sqlinit);
            string? sql = "DELETE FROM sessions WHERE ExpireDate <= @CurrentDate; VACUUM;";
            var param = new DynamicParameters();
            param.Add("CurrentDate", DateTime.Now);
            db.Execute(sql, param);
        }
    }
}