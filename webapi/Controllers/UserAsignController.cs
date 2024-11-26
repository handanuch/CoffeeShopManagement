using System.Data;
using System.Data.SqlClient;
using Dapper;
using CoffeeShop.Models;
using CoffeeShop.Utils.Api;
using CoffeeShop.Utils.Attributes;
using CoffeeShop.Utils.Session;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers;

public class UserAsignController : BaseController
{
    [HttpPost, Route("viewdata"), PMS(P_TYPE.P_VIEW_DATA)]
    public IActionResult ViewData(ROLE dto)
    {
        try
        {
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("FILTER", dto.FILTER);

                var query = db.Query("USR.VW_USRA", param, commandType: CommandType.StoredProcedure);
                return Ok(query);
            }
        }
        catch (Exception ex)
        {
            return Status500(ex.Message);
        }
    }
    [HttpPost, Route("getdata"), PMS(P_TYPE.P_VIEW_DATA)]
    public IActionResult getData(ROLE dto){
        try
        {
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("UR_ID", dto.UR_ID);
                
                var query = db.Query("USR.GET_US_AROLE", param, commandType: CommandType.StoredProcedure).ToList();
                if (query.Count > 0) return Ok(query[0]);
                return Status418(new { locale = "data_not_found" });
            }
        }
        catch (Exception ex)
        {
            return Status500(ex.Message);
        }
    }
    [HttpPost, Route("save"), PMS(P_TYPE.P_VIEW_DATA)]
    public IActionResult Save(ROLE dto)
    {
        try
        {
            var session = SessionHelper.GetSession(HttpContext);
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("UR_ID", dto.UR_ID);
                param.Add("US_ID", dto.US_ID);
                  param.Add("ROL_ID", dto.ROL_ID);
               
                param.Add("US_NAME", dto.TR_US);

                var query = db.Query("USR.SV_USASIGN_SAVE", param, commandType: CommandType.StoredProcedure);
                return Ok(query);
            }
        }
        catch (Exception ex)
        {
            return Status500(ex.Message);
        }
    }

    

    
}