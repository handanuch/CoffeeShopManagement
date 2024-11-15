using System.Data;
using System.Data.SqlClient;
using Dapper;
using CoffeeShop.Models;
using CoffeeShop.Utils.Api;
using CoffeeShop.Utils.Attributes;
using CoffeeShop.Utils.Session;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers;

public class EmployeeController : BaseController
{
    [HttpPost, Route("viewdata"), PMS(P_TYPE.P_VIEW_DATA)]
    public IActionResult ViewData(EMPLOYEE dto)
    {
        try
        {
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("FILTER", dto.FILTER);

                var query = db.Query("USR.VW_EMPLOYEE", param, commandType: CommandType.StoredProcedure);
                return Ok(query);
            }
        }
        catch (Exception ex)
        {
            return Status500(ex.Message);
        }
    }
    [HttpPost, Route("getdata"), PMS(P_TYPE.P_VIEW_DATA)]
    public IActionResult getData(EMPLOYEE dto){
        try
        {
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("EMP_ID", dto.EMP_ID);
                
                var query = db.Query("USR.GET_EMPLOYEE", param, commandType: CommandType.StoredProcedure).ToList();
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
    public IActionResult Save(EMPLOYEE dto)
    {
        try
        {
            var session = SessionHelper.GetSession(HttpContext);
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("EMP_ID", dto.EMP_ID);
                param.Add("EMP_CODE", dto.EMP_CODE);
                param.Add("NAME_EN", dto.NAME_EN);
                param.Add("NAME_KH", dto.NAME_KH);
                param.Add("GENDER", dto.GENDER);
                param.Add("PHONE", dto.PHONE);
                param.Add("MOBILE", dto.MOBILE);
                param.Add("EMP_STS", dto.EMP_STS);
                param.Add("START_DATE", dto.START_DATE);
                param.Add("DEP_ID", dto.DEP_ID);
                param.Add("POS_ID", dto.POS_ID);
                param.Add("COM_ID", dto.COM_ID);
                
               
                param.Add("TR_US", dto.TR_US);

                var query = db.Query("USR.SV_EMPLOYEE_SAVE", param, commandType: CommandType.StoredProcedure);
                return Ok(query);
            }
        }
        catch (Exception ex)
        {
            return Status500(ex.Message);
        }
    }

    

    
}