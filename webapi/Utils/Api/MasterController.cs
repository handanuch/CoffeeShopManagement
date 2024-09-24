using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Utils.Api;

[Route("api/[controller]")]
[ApiController]
public abstract class MasterController<T> : BaseController
{

    [HttpPost, Route("viewdata")]//User for View Data
    public abstract IActionResult ViewData(T dto);
    [HttpPost, Route("getdata")]//User for Get Data by ID
    public abstract IActionResult GetData(T dto);
    [HttpPost, Route("getstm")]//User for Get Statement History
    public abstract IActionResult GetStm(T dto);
    [HttpPost, Route("getlist")]//User for Dropdown List
    public abstract IActionResult GetList(T dto);
    [HttpPost, Route("getdtl")]//User for Get Data Detail in Sub Table
    public abstract IActionResult GetDTL(T dto);
    [HttpPost, Route("save")] //User for Save Data
    public abstract IActionResult Save(T dto);
    [HttpPost, Route("update")] //Use for Update Data
    public abstract IActionResult Update(T dto);
    [HttpPost, Route("delete")]//Use for Delete Data
    public abstract IActionResult Delete(T dto);
    [HttpPost, Route("clear")]//Use for Clear Data
    public abstract IActionResult Clear(T dto);
    [HttpPost, Route("approve")] //User for Approve
    public abstract IActionResult Approve(T dto);
    [HttpPost, Route("reject")] //Use for Reject
    public abstract IActionResult Reject(T dto);
    [HttpPost, Route("submit")]
    public abstract IActionResult Submit(T dto);
    [HttpPost, Route("reverse")]
    public abstract IActionResult Reverse(T dto);
    [HttpPost, Route("refresh")]
    public abstract IActionResult Refresh(T dto);
    [HttpPost, Route("customize")]
    public abstract IActionResult Customize(T dto);
    [HttpPost, Route("authorize")]
    public abstract IActionResult Authorize(T dto);
    [HttpPost, Route("import")]
    public abstract IActionResult Import(T dto);
    [HttpPost, Route("export")]
    public abstract IActionResult Export(T dto);

}