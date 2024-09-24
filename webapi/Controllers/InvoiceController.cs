using System.Data;
using System.Data.SqlClient;
using Dapper;
using CoffeeShop.Models;
using CoffeeShop.Utils.Api;
using CoffeeShop.Utils.Attributes;
using CoffeeShop.Utils.Session;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers;

public class InvoiceController : BaseController
{
    [HttpPost, Route("viewdata"), PMS(P_TYPE.P_VIEW_DATA)]
    public IActionResult ViewData(COMPANY_INFO dto)
    {
        try
        {
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("FILTER", dto.FILTER);

                var query = db.Query("COM.GET_COMPANY_INFO", param, commandType: CommandType.StoredProcedure);
                return Ok(query);
            }
        }
        catch (Exception ex)
        {
            return Status500(ex.Message);
        }
    }
    [HttpPost, Route("getdata"), PMS(P_TYPE.P_VIEW_DATA)]
    public IActionResult getData(COMPANY_INFO dto){
        try
        {
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("COM_ID", dto.COM_ID);
                
                var query = db.Query("COM.GET_COMPANY", param, commandType: CommandType.StoredProcedure).ToList();
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
    public IActionResult Save(COMPANY_INFO dto)
    {
        try
        {
            var session = SessionHelper.GetSession(HttpContext);
            using (var db = new SqlConnection(G.DBC(HttpContext)))
            {
                var param = new DynamicParameters();
                param.Add("COM_ID", dto.COM_ID);
                param.Add("COM_NO", dto.COM_NO);
                param.Add("COM_CODE", dto.COM_CODE);
                param.Add("COM_INITIAL_KH", dto.COM_INITIAL_KH);
                param.Add("COM_INITIAL_EN", dto.COM_INITIAL_EN);
                param.Add("COM_NAME_LOCAL", dto.COM_NAME_LOCAL);
                param.Add("COM_NAME_ENG", dto.COM_NAME_ENG);
                param.Add("ADDR_KH", dto.ADDR_KH);
                param.Add("ADDR_EN", dto.ADDR_EN);
                param.Add("PHONE", dto.PHONE);
                param.Add("EMAIL", dto.EMAIL);
                param.Add("WEBSITE", dto.WEBSITE);
                param.Add("FACEBOOK", dto.FACEBOOK);
                param.Add("LOGO", dto.LOGO);
                param.Add("TR_US", dto.TR_US);

                var query = db.Query("COM.SV_COMPANY_INFO_SAVE", param, commandType: CommandType.StoredProcedure);
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