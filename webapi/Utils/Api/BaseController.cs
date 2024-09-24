using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Utils.Api;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    private const bool B = true;

    [NonAction]
    public IActionResult Status500(object data)
    {
        return StatusCode(500, data);
    }

    [NonAction]
    public IActionResult Status418(object data)
    {
        return StatusCode(418, data);
    }
    public String ToKhmerMonth(int m, bool kh = true)
    {
        string rst = "មករា";
        if (kh)
        {
            switch (m)
            {
                case 2:
                    {
                        rst = "កុម្ភៈ";
                        break;
                    }

                case 3:
                    {
                        rst = "មីនា";
                        break;
                    }

                case 4:
                    {
                        rst = "មេសា";
                        break;
                    }

                case 5:
                    {
                        rst = "ឧសភា";
                        break;
                    }

                case 6:
                    {
                        rst = "មិថុនា";
                        break;
                    }

                case 7:
                    {
                        rst = "កក្កដា";
                        break;
                    }

                case 8:
                    {
                        rst = "សីហា";
                        break;
                    }

                case 9:
                    {
                        rst = "កញ្ញា";
                        break;
                    }

                case 10:
                    {
                        rst = "តុលា";
                        break;
                    }

                case 11:
                    {
                        rst = "វិច្ឆិកា";
                        break;
                    }

                case 12:
                    {
                        rst = "ធ្នូ";
                        break;
                    }
            }
        }
        else
        {
            rst = "Junuary";
            switch (m)
            {
                case 2:
                    {
                        rst = "February";
                        break;
                    }

                case 3:
                    {
                        rst = "March";
                        break;
                    }

                case 4:
                    {
                        rst = "April";
                        break;
                    }

                case 5:
                    {
                        rst = "May";
                        break;
                    }

                case 6:
                    {
                        rst = "June";
                        break;
                    }

                case 7:
                    {
                        rst = "July";
                        break;
                    }

                case 8:
                    {
                        rst = "August";
                        break;
                    }

                case 9:
                    {
                        rst = "September";
                        break;
                    }

                case 10:
                    {
                        rst = "October";
                        break;
                    }

                case 11:
                    {
                        rst = "November";
                        break;
                    }

                case 12:
                    {
                        rst = "December";
                        break;
                    }
            }
        }
        return rst;
    }
    public string cIntToKhmerNumber(int val)
    {
        string rst = "០";
        switch (val)
        {
            case 0:
                {
                    rst = "០";
                    break;
                }

            case 1:
                {
                    rst = "១";
                    break;
                }

            case 2:
                {
                    rst = "២";
                    break;
                }

            case 3:
                {
                    rst = "៣";
                    break;
                }

            case 4:
                {
                    rst = "៤";
                    break;
                }

            case 5:
                {
                    rst = "៥";
                    break;
                }

            case 6:
                {
                    rst = "៦";
                    break;
                }

            case 7:
                {
                    rst = "៧";
                    break;
                }

            case 8:
                {
                    rst = "៨";
                    break;
                }

            case 9:
                {
                    rst = "៩";
                    break;
                }
        }
        return rst;
    }
    public string ToKhmerNumber(int val, bool b = false)
    {
        string rst = "";
        char[] ch = (val + "").ToCharArray();
        for (var i = 0; i <= ch.Length - 1; i++)
            rst += cIntToKhmerNumber(System.Convert.ToInt32(ch[i] + ""));
        if (val < 10 & b)
            rst = "០" + rst;
        return rst;
    }
    public string ToKhmerDate(DateTime d)
    {
        string rst = "";
        int dd = Int32.Parse(d.ToString("dd"));
        int MM = Int32.Parse(d.ToString("MM"));
        int yy = Int32.Parse(d.ToString("yyyy"));
        rst = "ថ្ងៃទី " + ToKhmerNumber(dd, true) + " ខែ " + ToKhmerMonth(MM, true) + " ឆ្នាំ " + ToKhmerNumber(yy, B);
        return rst;
    }
    public string SQLString(string ST)
    {
        if (ST == null)
            ST = "";
        ST = ST.Replace("'", "''");
        return "N'" + ST + "'";
    }
    //Must Overide
}