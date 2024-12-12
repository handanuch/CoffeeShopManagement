using System.Data;
using System.Data.SqlClient;
using Dapper;
using CoffeeShop.Models;
using CoffeeShop.Utils.Api;
using CoffeeShop.Utils.Attributes;
using CoffeeShop.Utils.Session;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers;

public class ProductController : BaseController
{
    [HttpPost, Route("viewdata"), PMS(P_TYPE.P_VIEW_DATA)]
    public IActionResult ViewData(PRODUCT dto)
    {
        try
        {
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("FILTER", dto.FILTER);

                var query = db.Query("PRO.VW_PRODUCT", param, commandType: CommandType.StoredProcedure);
                return Ok(query);
            }
        }
        catch (Exception ex)
        {
            return Status500(ex.Message);
        }
    }
    [HttpPost, Route("getdata"), PMS(P_TYPE.P_VIEW_DATA)]
    public IActionResult getData(PRODUCT dto){
        try
        {
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("PRO_ID", dto.PRO_ID);
                
                var query = db.Query("PRO.GET_PRODUCT", param, commandType: CommandType.StoredProcedure).ToList();
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
    public IActionResult Save(PRODUCT dto)
    {
        try
        {
            var session = SessionHelper.GetSession(HttpContext);
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("PRO_ID", dto.PRO_ID);
                param.Add("EMP_ID", dto.EMP_ID);
                param.Add("PRO_CODE", dto.PRO_CODE);
                param.Add("PRO_NAME_KH", dto.PRO_NAME_KH);
                param.Add("PRO_NAME_EN", dto.PRO_NAME_EN);
                param.Add("PRO_PRICE", dto.PRO_PRICE);
                param.Add("TR_US", dto.TR_US );
                param.Add("PRO_STS", dto.PRO_STS);
                param.Add("CREATION_DATE", dto.CREATION_DATE);
                param.Add("MODIFY_DATE", dto.MODIFY_DATE);

                var query = db.Query("PRO.SAVE_SV_PRODUCT", param, commandType: CommandType.StoredProcedure);
                return Ok(query);
            }
        }
        catch (Exception ex)
        {
            return Status500(ex.Message);
        }
    }

    

    [HttpPost, Route("delete"), PMS(P_TYPE.P_DELETE)]
    public IActionResult DeleteData(PRODUCT dto)
    {
        try
        {
            var session = SessionHelper.GetSession(HttpContext);
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("TR_DVAL", dto.TR_DVAL);
                param.Add("US_NAME", session?.US_ID);
                param.Add("PC_NAME", dto.PC_NAME);
                param.Add("IP_ADDRESS", dto.IP_ADDRESS);
                param.Add("MAC_ADDRESS", dto.MAC_ADDRESS);

                var i = db.Execute("PRO.DELETE_PRODUCT", param, commandType: CommandType.StoredProcedure);
                if (i > 0) return Ok(new { locale = "success" });
                return Status418(new { locale = "failed" });
            }
        }
        catch (Exception ex)
        {
            return Status500(ex.Message);
        }
    }
}