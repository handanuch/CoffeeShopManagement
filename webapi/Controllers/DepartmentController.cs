using System.Data;
using System.Data.SqlClient;
using Dapper;
using CoffeeShop.Models;
using CoffeeShop.Utils.Api;
using CoffeeShop.Utils.Attributes;
using CoffeeShop.Utils.Session;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers;

public class DepartmentController : BaseController
{
    [HttpPost, Route("viewdata"), PMS(P_TYPE.P_VIEW_DATA)]
    public IActionResult ViewData(DEPARTMENT dto)
    {
        try
        {
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("FILTER", dto.FILTER);

                var query = db.Query("COM.VW_DEPARTMENT", param, commandType: CommandType.StoredProcedure);
                return Ok(query);
            }
        }
        catch (Exception ex)
        {
            return Status500(ex.Message);
        }
    }
    [HttpPost, Route("getdata"), PMS(P_TYPE.P_VIEW_DATA)]
    public IActionResult getData(DEPARTMENT dto){
        try
        {
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("DEP_ID", dto.DEP_ID);
                
                var query = db.Query("COM.GET_DEPRTMENT", param, commandType: CommandType.StoredProcedure).ToList();
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
    public IActionResult Save(DEPARTMENT dto)
    {
        try
        {
            var session = SessionHelper.GetSession(HttpContext);
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("DEP_ID", dto.DEP_ID);
                param.Add("COM_ID", dto.COM_ID);
                param.Add("DEP_NO", dto.DEP_NO);
                param.Add("DEP_CODE", dto.DEP_CODE);
                param.Add("DEP_NAME_LOCAL", dto.DEP_NAME_LOCAL);
                param.Add("DEP_NAME_ENG", dto.DEP_NAME_ENG);
               
                param.Add("US_NAME", dto.TR_US);

                var query = db.Query("COM.SV_DEPARTMENT_SAVE", param, commandType: CommandType.StoredProcedure);
                return Ok(query);
            }
        }
        catch (Exception ex)
        {
            return Status500(ex.Message);
        }
    }

    

    [HttpPost, Route("delete"), PMS(P_TYPE.P_DELETE)]
    public IActionResult DeleteData(COMPANY_INFO dto)
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

                var i = db.Execute("CMF.SP_COMPANY_INFO_DELETE", param, commandType: CommandType.StoredProcedure);
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